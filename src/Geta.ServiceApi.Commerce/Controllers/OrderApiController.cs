using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Web.Http;
using EPiServer.ServiceApi.Configuration;
using Mediachase.Commerce.Orders;

namespace Geta.ServiceApi.Commerce.Controllers
{
    [AuthorizePermission("EPiServerServiceApi", "WriteAccess"), RequireHttps, RoutePrefix("episerverapi/commerce/order")]
    public class OrderApiController : ApiController
    {
        [AuthorizePermission("EPiServerServiceApi", "ReadAccess"), HttpGet, Route("{orderId}")]

        public virtual IHttpActionResult GetOrder(string orderId)
        {
            return Ok();
        }

        [AuthorizePermission("EPiServerServiceApi", "ReadAccess"), HttpGet, Route("{customerId}/all")]
        public virtual IHttpActionResult GetOrders(Guid customerId)
        {
            PurchaseOrder[] orders = OrderContext.Current.GetPurchaseOrders(customerId);

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