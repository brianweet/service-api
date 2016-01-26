using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Web.Http;
using EPiServer.ServiceApi.Configuration;
using Mediachase.Commerce.Customers;

namespace Geta.ServiceApi.Commerce.Controllers
{
    [AuthorizePermission("EPiServerServiceApi", "WriteAccess"), RequireHttps, RoutePrefix("episerverapi/commerce/customer")]
    public class CustomerApiController : ApiController
    {
        public virtual IHttpActionResult GetCustomer(string customerId)
        {
            var customer = CustomerContext.Current.GetContactById(Guid.Parse(customerId));

            return Ok(customer);
        }

        public virtual IHttpActionResult GetCustomers()
        {
            return Ok();
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