using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Web.Http;
using EPiServer.Commerce.Order;
using EPiServer.ServiceApi.Configuration;
using EPiServer.ServiceApi.Util;
using Mediachase.Commerce.Orders;

namespace Geta.ServiceApi.Commerce.Controllers
{
    [AuthorizePermission("EPiServerServiceApi", "WriteAccess"), RequireHttps, RoutePrefix("episerverapi/commerce/order")]
    public class OrderApiController : ApiController
    {
        private static readonly ApiCallLogger Logger = new ApiCallLogger(typeof(OrderApiController));

        private readonly IOrderRepository _orderRepository;

        private readonly string defaultName = Cart.DefaultName;

        public OrderApiController(IOrderRepository orderRepository)
        {
            this._orderRepository = orderRepository;
        }

        [AuthorizePermission("EPiServerServiceApi", "ReadAccess"), HttpGet, Route("{orderGroupId}")]
        public virtual IHttpActionResult GetOrder(int orderGroupId)
        {
            var order = this._orderRepository.Load<OrderGroup>(orderGroupId);

            return Ok(order);
        }

        [AuthorizePermission("EPiServerServiceApi", "ReadAccess"), HttpGet, Route("{customerId}/all")]
        public virtual IHttpActionResult GetOrders(Guid customerId)
        {
            IEnumerable<IOrderGroup> orders = this._orderRepository.Load(customerId, defaultName);

            return Ok(orders);
        }

        [AuthorizePermission("EPiServerServiceApi", "WriteAccess"), HttpPut, Route("{Reference}")]
        public virtual IHttpActionResult PutOrder([FromBody] ExpandoObject Updated, EPiServer.DataAccess.SaveAction action = EPiServer.DataAccess.SaveAction.Save)
        {
            return Ok();
        }

        [AuthorizePermission("EPiServerServiceApi", "WriteAccess"), HttpDelete, Route("{orderGroupId}")]
        public virtual IHttpActionResult DeleteOrder(int orderGroupId)
        {
            var existingOrder = this._orderRepository.Load<OrderGroup>(orderGroupId);

            if (existingOrder == null)
            {
                return NotFound();
            }

            var orderReference = new OrderReference(orderGroupId, existingOrder.Name, existingOrder.CustomerId, typeof(PurchaseOrder));

            this._orderRepository.Delete(orderReference);

            return Ok();
        }

        [AuthorizePermission("EPiServerServiceApi", "WriteAccess"), HttpPost, Route()]
        public virtual IHttpActionResult CreateOrder([FromBody] Cart cart, EPiServer.DataAccess.SaveAction action = EPiServer.DataAccess.SaveAction.Save)
        {
            var orderReference = this._orderRepository.SaveAsPurchaseOrder(cart);

            return Ok(orderReference);
        }
    }
}