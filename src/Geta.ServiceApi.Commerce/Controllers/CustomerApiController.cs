using System;
using System.Linq;
using System.Web.Http;
using System.Web.Script.Serialization;
using EPiServer.ServiceApi.Configuration;
using EPiServer.ServiceApi.Util;
using Geta.ServiceApi.Commerce.Extensions;
using Geta.ServiceApi.Commerce.Models;
using Mediachase.Commerce.Customers;

namespace Geta.ServiceApi.Commerce.Controllers
{
    [AuthorizePermission("EPiServerServiceApi", "WriteAccess"), RequireHttps, RoutePrefix("episerverapi/commerce/customer")]
    public class CustomerApiController : ApiController
    {
        private static readonly ApiCallLogger Logger = new ApiCallLogger(typeof(OrderApiController));

        [AuthorizePermission("EPiServerServiceApi", "ReadAccess"), HttpGet, Route("contact/{contactId}")]
        public virtual IHttpActionResult GetContact(Guid contactId)
        {
            CustomerContact contact = CustomerContext.Current.GetContactById(contactId);

            // Problems with using default JSON.NET (seems to be related to ScriptIgnoreAttribute)
            var serializer = new JavaScriptSerializer();

            return Ok(serializer.Serialize(contact));
        }

        [AuthorizePermission("EPiServerServiceApi", "ReadAccess"), HttpGet, Route("contact")]
        public virtual IHttpActionResult GetContact()
        {
            var contacts = CustomerContext.Current.GetContacts();

            // Problems with using default JSON.NET (seems to be related to ScriptIgnoreAttribute)
            var serializer = new JavaScriptSerializer();

            return Ok(serializer.Serialize(contacts));
        }

        [AuthorizePermission("EPiServerServiceApi", "WriteAccess"), HttpPut, Route]
        public virtual IHttpActionResult PutCustomer([FromBody] Contact contact, EPiServer.DataAccess.SaveAction action = EPiServer.DataAccess.SaveAction.Save)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!contact.PrimaryKeyId.HasValue)
            {
                return NotFound();
            }

            CustomerContact customerContact = CustomerContext.Current.GetContactById(contact.PrimaryKeyId.Value);

            if (customerContact == null)
            {
                return NotFound();
            }

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

            return Ok();
        }

        [AuthorizePermission("EPiServerServiceApi", "WriteAccess"), HttpDelete, Route("contact/{contactId}")]
        public virtual IHttpActionResult DeleteContact(Guid contactId)
        {
            CustomerContact contact = CustomerContext.Current.GetContactById(contactId);

            if (contact == null)
            {
                return NotFound();
            }

            contact.DeleteWithAllDependents();

            //contact.DeleteCustomerContactOnly();

            //Mediachase.BusinessFoundation.Data.Business.BusinessManager.Delete(contact);

            return Ok();
        }

        [AuthorizePermission("EPiServerServiceApi", "WriteAccess"), HttpPost, Route("contact/{userId}")]
        public virtual IHttpActionResult PostContact(Guid userId, [FromBody] Contact contact, EPiServer.DataAccess.SaveAction action = EPiServer.DataAccess.SaveAction.Save)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CustomerContact customerContact = CustomerContact.CreateInstance();

            customerContact.PrimaryKeyId = new Mediachase.BusinessFoundation.Data.PrimaryKeyId(userId);
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

            return Ok();
        }
    }
}