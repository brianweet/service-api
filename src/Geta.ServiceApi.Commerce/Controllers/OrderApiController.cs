using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Web.Http;
using EPiServer.ServiceApi.Configuration;
using Mediachase.Commerce.Orders;

namespace Geta.ServiceApi.Commerce.Controllers
{
    [/*AuthorizePermission("EPiServerServiceApi", "WriteAccess"),*/ RequireHttps, RoutePrefix("episerverapi/order")]
    public class OrderApiController : ApiController
    {
        public virtual IHttpActionResult GetOrder(string orderId)
        {
            return Ok();
        }

        public virtual IHttpActionResult GetOrders(Guid customerId)
        {
            var orders = OrderContext.Current.GetPurchaseOrders(customerId);

            return Ok(orders);
        }

        [AuthorizePermission("EPiServerServiceApi", "WriteAccess"), HttpPut, Route("{Reference}")]
        public virtual IHttpActionResult PutOrder([FromBody] ExpandoObject Updated, EPiServer.DataAccess.SaveAction action = EPiServer.DataAccess.SaveAction.Save)
        {


            return Ok();
        }

        [AuthorizePermission("EPiServerServiceApi", "WriteAccess"), HttpDelete, Route("{orderId}")]
        public virtual IHttpActionResult DeleteOrder(string orderId)
        {
            return Ok();
        }

        [AuthorizePermission("EPiServerServiceApi", "WriteAccess"), HttpPost, Route("")]
        public virtual IHttpActionResult CreateOrder([FromBody] ExpandoObject order, EPiServer.DataAccess.SaveAction action = EPiServer.DataAccess.SaveAction.Save)
        {
            var properties = order as IDictionary<string, object>;

            return Ok();
        }
    }
}