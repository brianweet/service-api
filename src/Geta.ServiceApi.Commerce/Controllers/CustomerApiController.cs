using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Web.Http;
using System.Web.Script.Serialization;
using EPiServer.ServiceApi.Configuration;
using EPiServer.ServiceApi.Util;
using Mediachase.Commerce.Customers;

namespace Geta.ServiceApi.Commerce.Controllers
{
    [AuthorizePermission("EPiServerServiceApi", "WriteAccess"), RequireHttps, RoutePrefix("episerverapi/commerce/customer")]
    public class CustomerApiController : ApiController
    {
        private static readonly ApiCallLogger Logger = new ApiCallLogger(typeof(OrderApiController));

        [AuthorizePermission("EPiServerServiceApi", "ReadAccess"), HttpGet, Route("contact/{contactId}")]
        public virtual IHttpActionResult GetContact(string contactId)
        {
            CustomerContact contact = CustomerContext.Current.GetContactById(Guid.Parse(contactId));

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

        [AuthorizePermission("EPiServerServiceApi", "WriteAccess"), HttpPut, Route("{Reference}")]
        public virtual IHttpActionResult PutCustomer([FromBody] ExpandoObject Updated, EPiServer.DataAccess.SaveAction action = EPiServer.DataAccess.SaveAction.Save)
        {
            return Ok();
        }

        [AuthorizePermission("EPiServerServiceApi", "WriteAccess"), HttpDelete, Route("{customerId}")]
        public virtual IHttpActionResult DeleteCustomer(string customerId)
        {
            return Ok();
        }

        [AuthorizePermission("EPiServerServiceApi", "WriteAccess"), HttpPost, Route("")]
        public virtual IHttpActionResult CreateCustomer([FromBody] ExpandoObject customer, EPiServer.DataAccess.SaveAction action = EPiServer.DataAccess.SaveAction.Save)
        {
            var properties = customer as IDictionary<string, object>;

            return Ok();
        }
    }
}