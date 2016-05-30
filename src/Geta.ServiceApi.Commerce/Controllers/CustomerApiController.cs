﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using EPiServer.ServiceApi.Configuration;
using EPiServer.ServiceApi.Util;
using Geta.ServiceApi.Commerce.Mappings;
using Geta.ServiceApi.Commerce.Models;
using Mediachase.BusinessFoundation.Data;
using Mediachase.Commerce.Customers;
using Organization = Geta.ServiceApi.Commerce.Models.Organization;

namespace Geta.ServiceApi.Commerce.Controllers
{
    [AuthorizePermission("EPiServerServiceApi", "WriteAccess"), RequireHttps, RoutePrefix("episerverapi/commerce/customer")]
    public class CustomerApiController : ApiController
    {
        private static readonly ApiCallLogger Logger = new ApiCallLogger(typeof(OrderApiController));

        [AuthorizePermission("EPiServerServiceApi", "ReadAccess"), HttpGet, Route("contact/{contactId}")]
        public virtual IHttpActionResult GetContact(Guid contactId)
        {
            Logger.LogGet("GetContact", Request, new[] { contactId.ToString()});

            Contact contact;

            try
            {
                contact = CustomerContext.Current.GetContactById(contactId).ConvertToContact();
            }
            catch (Exception exception)
            {
                Logger.Error(exception.Message, exception);
                return InternalServerError(exception);
            }

            return Ok(contact);
        }

        [AuthorizePermission("EPiServerServiceApi", "ReadAccess"), HttpGet, Route("contact")]
        public virtual IHttpActionResult GetContact()
        {
            Logger.LogGet("GetContact", Request);

            IEnumerable<Contact>  contacts;

            try
            {
                contacts = CustomerContext.Current.GetContacts().Select(c => c.ConvertToContact());
            }
            catch (Exception exception)
            {
                Logger.Error(exception.Message, exception);
                return InternalServerError(exception);
            }

            return Ok(contacts);
        }

        [AuthorizePermission("EPiServerServiceApi", "ReadAccess"), HttpGet, Route("organization/{orgId}")]
        public virtual IHttpActionResult GetOrganization(string orgId)
        {
            Logger.LogGet("GetOrganization", Request, new []{orgId});

            Organization organization;

            try
            {
                organization = CustomerContext.Current.GetOrganizationById(orgId).ConvertToOrganization();
            }
            catch (Exception exception)
            {
                Logger.Error(exception.Message, exception);
                return InternalServerError(exception);
            }

            return Ok(organization);
        }

        [AuthorizePermission("EPiServerServiceApi", "ReadAccess"), HttpGet, Route("organization")]
        public virtual IHttpActionResult GetOrganization()
        {
            Logger.LogGet("GetOrganization", Request);

            IEnumerable<Organization> organizations;

            try
            {
                organizations = CustomerContext.Current.GetOrganizations().Select(o => o.ConvertToOrganization());
            }
            catch (Exception exception)
            {
                Logger.Error(exception.Message, exception);
                return InternalServerError(exception);
            }

            return Ok(organizations);
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
                        CustomerMappings.CreateOrUpdateCustomerAddress(existingContact, address);
                    }
                }

                existingContact.SaveChanges();

                // default address
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
                var newOrganization = Mediachase.Commerce.Customers.Organization.CreateInstance();
                newOrganization.PrimaryKeyId = new PrimaryKeyId(organization.PrimaryKeyId);
                //newOrganization.Addresses
                newOrganization.OrgCustomerGroup = organization.OrgCustomerGroup;
                newOrganization.OrganizationType = organization.OrganizationType;
                //newOrganization.Contacts = 

                newOrganization.SaveChanges();
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

                CustomerMappings.CreateContact(customerContact, userId, contact);
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
                var newOrganization = Mediachase.Commerce.Customers.Organization.CreateInstance();
                newOrganization.PrimaryKeyId = new PrimaryKeyId(organization.PrimaryKeyId);
                //newOrganization.Addresses
                newOrganization.OrgCustomerGroup = organization.OrgCustomerGroup;
                newOrganization.OrganizationType = organization.OrganizationType;
                //newOrganization.Contacts = 

                newOrganization.SaveChanges();
            }
            catch (Exception exception)
            {
                Logger.Error(exception.Message, exception);
                return InternalServerError(exception);
            }

            return Ok();
        }
    }
}