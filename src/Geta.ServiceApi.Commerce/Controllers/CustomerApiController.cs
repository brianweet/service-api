using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Script.Serialization;
using EPiServer.ServiceApi.Configuration;
using EPiServer.ServiceApi.Util;
using Geta.ServiceApi.Commerce.Extensions;
using Geta.ServiceApi.Commerce.Models;
using Mediachase.BusinessFoundation.Data;
using Mediachase.Commerce.Customers;

namespace Geta.ServiceApi.Commerce.Controllers
{
    [AuthorizePermission("EPiServerServiceApi", "WriteAccess"), RequireHttps, RoutePrefix("episerverapi/commerce/customer")]
    public class CustomerApiController : ApiController
    {
        private static readonly ApiCallLogger Logger = new ApiCallLogger(typeof(OrderApiController));

        // Problems with using default JSON.NET (seems to be related to ScriptIgnoreAttribute)
        private static readonly JavaScriptSerializer Serializer = new JavaScriptSerializer();

        [AuthorizePermission("EPiServerServiceApi", "ReadAccess"), HttpGet, Route("contact/{contactId}")]
        public virtual IHttpActionResult GetContact(Guid contactId)
        {
            Logger.LogGet("GetContact", Request, new[] { contactId.ToString()});

            string json;

            try
            {
                CustomerContact contact = CustomerContext.Current.GetContactById(contactId);
                
                json = Serializer.Serialize(contact);
            }
            catch (Exception exception)
            {
                Logger.Error(exception.Message, exception);
                return InternalServerError(exception);
            }

            return Ok(json);
        }

        [AuthorizePermission("EPiServerServiceApi", "ReadAccess"), HttpGet, Route("contact")]
        public virtual IHttpActionResult GetContact()
        {
            Logger.LogGet("GetContact", Request);

            string json;

            try
            {
                var contacts = CustomerContext.Current.GetContacts();

                json = Serializer.Serialize(contacts);
            }
            catch (Exception exception)
            {
                Logger.Error(exception.Message, exception);
                return InternalServerError(exception);
            }

            return Ok(json);
        }

        [AuthorizePermission("EPiServerServiceApi", "ReadAccess"), HttpGet, Route("organization/{orgId}")]
        public virtual IHttpActionResult GetOrganization(string orgId)
        {
            Logger.LogGet("GetOrganization", Request, new []{orgId});

            string json;

            try
            {
                Organization organization = CustomerContext.Current.GetOrganizationById(orgId);
                json = Serializer.Serialize(organization);
            }
            catch (Exception exception)
            {
                Logger.Error(exception.Message, exception);
                return InternalServerError(exception);
            }

            return Ok(json);
        }

        [AuthorizePermission("EPiServerServiceApi", "ReadAccess"), HttpGet, Route("organization")]
        public virtual IHttpActionResult GetOrganization()
        {
            Logger.LogGet("GetOrganization", Request);

            string json;

            try
            {
                var organizations = CustomerContext.Current.GetOrganizations();
                json = Serializer.Serialize(organizations);
            }
            catch (Exception exception)
            {
                Logger.Error(exception.Message, exception);
                return InternalServerError(exception);
            }

            return Ok(json);
        }

        [AuthorizePermission("EPiServerServiceApi", "WriteAccess"), HttpPut, Route("contact/{contactId}")]
        public virtual IHttpActionResult PutCustomer(Guid contactId, [FromBody] Contact contact)
        {
            Logger.LogPut("PutCustomer", Request, new []{ contactId.ToString()});

            var existingContact = CustomerContext.Current.GetContactById(contactId);

            if (existingContact == null)
            {
                return NotFound();
            }

            try
            {
                existingContact.FirstName = contact.FirstName;
                existingContact.LastName = contact.LastName;
                existingContact.Email = contact.Email;
                existingContact.UserId = "String:" + contact.Email; // The UserId needs to be set in the format "String:{email}". Else a duplicate CustomerContact will be created later on.
                existingContact.RegistrationSource = contact.RegistrationSource;

                if (contact.Addresses != null)
                {
                    foreach (var address in contact.Addresses)
                    {
                        CreateOrUpdateCustomerAddress(existingContact, address);
                    }
                }

                existingContact.SaveChanges();
            }
            catch (Exception exception)
            {
                Logger.Error(exception.Message, exception);
                return InternalServerError(exception);
            }

            return Ok();
        }

        [AuthorizePermission("EPiServerServiceApi", "WriteAccess"), HttpPut, Route("organization")]
        public virtual IHttpActionResult PutOrganization([FromBody] Organization organization)
        {
            Logger.LogPut("PutOrganization", Request);

            try
            {
                organization.SaveChanges();
            }
            catch (Exception exception)
            {
                Logger.Error(exception.Message, exception);
                return InternalServerError(exception);
            }

            return Ok();
        }

        [AuthorizePermission("EPiServerServiceApi", "WriteAccess"), HttpDelete, Route("contact/{contactId}")]
        public virtual IHttpActionResult DeleteContact(Guid contactId)
        {
            Logger.LogDelete("DeleteContact", Request, new []{contactId.ToString()});

            CustomerContact contact = CustomerContext.Current.GetContactById(contactId);

            if (contact == null)
            {
                return NotFound();
            }

            try
            {
                // BUG reported to Episerver. #COM-956
                contact.PreferredBillingAddressId = null;
                contact.PreferredShippingAddressId = null;

                contact.SaveChanges();

                contact.DeleteWithAllDependents();
            }
            catch (Exception exception)
            {
                Logger.Error(exception.Message, exception);
                return InternalServerError(exception);
            }

            return Ok();
        }

        [AuthorizePermission("EPiServerServiceApi", "WriteAccess"), HttpDelete, Route("organization/{orgId}")]
        public virtual IHttpActionResult DeleteOrganization(string orgId)
        {
            Logger.LogDelete("DeleteOrganization", Request, new[] { orgId });

            var organization = CustomerContext.Current.GetOrganizationById(orgId);

            if (organization == null)
            {
                return NotFound();
            }

            try
            {
                organization.DeleteWithAllDepends();
            }
            catch (Exception exception)
            {
                Logger.Error(exception.Message, exception);
                return InternalServerError(exception);
            }

            return Ok();
        }

        [AuthorizePermission("EPiServerServiceApi", "WriteAccess"), HttpPost, Route("contact/{userId}")]
        public virtual IHttpActionResult PostContact(Guid userId, [FromBody] Contact contact)
        {
            Logger.LogPost("PostContact", Request, new []{userId.ToString()});

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                CustomerContact customerContact = CustomerContact.CreateInstance();

                customerContact.PrimaryKeyId = new PrimaryKeyId(userId);
                customerContact.FirstName = contact.FirstName;
                customerContact.LastName = contact.LastName;
                customerContact.Email = contact.Email;
                customerContact.UserId = "String:" + contact.Email; // The UserId needs to be set in the format "String:{email}". Else a duplicate CustomerContact will be created later on.
                customerContact.RegistrationSource = contact.RegistrationSource;

                if (contact.Addresses != null)
                {
                    foreach (var address in contact.Addresses)
                    {
                        customerContact.AddContactAddress(address.ConvertToCustomerAddress(CustomerAddress.CreateInstance()));
                    }
                }

                // The contact, or more likely its related addresses, must be saved to the database before we can set the preferred
                // shipping and billing addresses. Using an address id before its saved will throw an exception because its value
                // will still be null.
                customerContact.SaveChanges();

                // Once the contact has been saved we can look for any existing addresses.
                CustomerAddress defaultAddress = customerContact.ContactAddresses.FirstOrDefault();
                if (defaultAddress != null)
                {
                    // If an addresses was found, it will be used as default for shipping and billing.
                    customerContact.PreferredShippingAddress = defaultAddress;
                    customerContact.PreferredBillingAddress = defaultAddress;

                    // Save the address preferences also.
                    customerContact.SaveChanges();
                }
            }
            catch (Exception exception)
            {
                Logger.Error(exception.Message, exception);
                return InternalServerError(exception);
            }

            return Ok();
        }

        [AuthorizePermission("EPiServerServiceApi", "WriteAccess"), HttpPost, Route("organization")]
        public virtual IHttpActionResult PostOrganization([FromBody] Organization organization)
        {
            Logger.LogPost("PostOrganization", Request);

            try
            {
                organization.SaveChanges();
            }
            catch (Exception exception)
            {
                Logger.Error(exception.Message, exception);
                return InternalServerError(exception);
            }

            return Ok();
        }

        private CustomerAddress CreateOrUpdateCustomerAddress(CustomerContact contact, Address address)
        {
            var customerAddress = GetAddress(contact, address.AddressId);
            var isNew = customerAddress == null;
            IEnumerable<PrimaryKeyId> existingId = contact.ContactAddresses.Select(a => a.AddressId).ToList();
            if (isNew)
            {
                customerAddress = CustomerAddress.CreateInstance();
            }

            customerAddress = address.ConvertToCustomerAddress(customerAddress);

            if (isNew)
            {
                contact.AddContactAddress(customerAddress);
            }
            else
            {
                contact.UpdateContactAddress(customerAddress);
            }

            contact.SaveChanges();
            if (isNew)
            {
                customerAddress.AddressId = contact.ContactAddresses
                    .Where(a => !existingId.Contains(a.AddressId))
                    .Select(a => a.AddressId)
                    .Single();
                address.AddressId = customerAddress.AddressId;
            }

            return customerAddress;
        }

        private CustomerAddress GetAddress(CustomerContact contact, Guid? addressId)
        {
            return addressId.HasValue ?
                contact.ContactAddresses.FirstOrDefault(x => x.AddressId == addressId.GetValueOrDefault()) :
                null;
        }
    }
}