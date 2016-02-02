using System;
using System.Collections.Generic;
using System.Web.Http;
using EPiServer.Commerce.Order;
using EPiServer.ServiceApi.Configuration;
using EPiServer.ServiceApi.Util;
using Mediachase.Commerce.Orders;
using Mediachase.Commerce.Orders.Search;

namespace Geta.ServiceApi.Commerce.Controllers
{
    [AuthorizePermission("EPiServerServiceApi", "WriteAccess"), RequireHttps, RoutePrefix("episerverapi/commerce/order")]
    public class OrderApiController : ApiController
    {
        private static readonly ApiCallLogger Logger = new ApiCallLogger(typeof(OrderApiController));

        private readonly IOrderRepository _orderRepository;

        private readonly string _defaultName = Cart.DefaultName;

        public OrderApiController(IOrderRepository orderRepository)
        {
            this._orderRepository = orderRepository;
        }

        [AuthorizePermission("EPiServerServiceApi", "ReadAccess"), HttpGet, Route("{orderGroupId}")]
        public virtual IHttpActionResult GetOrder(int orderGroupId)
        {
            Logger.LogGet("GetOrders", Request, new[] { orderGroupId.ToString() });

            PurchaseOrder order;

            try
            {
                order = this._orderRepository.Load<PurchaseOrder>(orderGroupId);
            }
            catch (Exception exception)
            {
                Logger.Error(exception.Message, exception);
                return InternalServerError(exception);
            }

            return Ok(order);
        }

        [AuthorizePermission("EPiServerServiceApi", "ReadAccess"), HttpGet, Route("{customerId}/all")]
        public virtual IHttpActionResult GetOrders(Guid customerId)
        {
            Logger.LogGet("GetOrders", Request, new[] { customerId.ToString() });

            IEnumerable<IOrderGroup> orders;

            try
            {
                orders = this._orderRepository.Load(customerId, _defaultName);
            }
            catch (Exception exception)
            {
                Logger.Error(exception.Message, exception);
                return InternalServerError(exception);
            }

            return Ok(orders);
        }

        [AuthorizePermission("EPiServerServiceApi", "ReadAccess"), HttpGet, Route("{start}/{maxCount}/all")]
        public virtual IHttpActionResult GetOrders(int start, int maxCount)
        {
            Logger.LogGet("GetOrders", Request, new []{start.ToString(), maxCount.ToString()});

            if (maxCount < 1 || maxCount > 100)
            {
                maxCount = 10;
            }

            PurchaseOrder[] orders;

            try
            {
                // http://world.episerver.com/documentation/Items/Developers-Guide/EPiServer-Commerce/9/Orders/Searching-for-orders/
                OrderSearchOptions searchOptions = new OrderSearchOptions
                {
                    CacheResults = false,
                    StartingRecord = start,
                    RecordsToRetrieve = maxCount,
                    Namespace = "Mediachase.Commerce.Orders"
                };

                OrderSearchParameters parameters = new OrderSearchParameters();
                searchOptions.Classes.Add("PurchaseOrder");
                parameters.SqlMetaWhereClause = "META.TrackingNumber LIKE '%PO%'";
                parameters.SqlWhereClause = "OrderGroupId IN (SELECT OrdergroupId FROM Shipment WHERE NOT ShipmentTrackingNumber IS NULL)";

                orders = OrderContext.Current.FindPurchaseOrders(parameters, searchOptions);
            }
            catch (Exception exception)
            {
                Logger.Error(exception.Message, exception);
                return InternalServerError(exception);
            }

            return Ok(orders);
        }

        [AuthorizePermission("EPiServerServiceApi", "WriteAccess"), HttpPut, Route]
        public virtual IHttpActionResult PutOrder([FromBody] PurchaseOrder order)
        {
            return Ok();
        }

        [AuthorizePermission("EPiServerServiceApi", "WriteAccess"), HttpDelete, Route("{orderGroupId}")]
        public virtual IHttpActionResult DeleteOrder(int orderGroupId)
        {
            Logger.LogDelete("DeleteOrder", Request, new[] {orderGroupId.ToString()});

            var existingOrder = this._orderRepository.Load<PurchaseOrder>(orderGroupId);

            if (existingOrder == null)
            {
                return NotFound();
            }

            try
            {
                var orderReference = new OrderReference(orderGroupId, existingOrder.Name, existingOrder.CustomerId, typeof (PurchaseOrder));

                this._orderRepository.Delete(orderReference);
            }
            catch (Exception exception)
            {
                Logger.Error(exception.Message, exception);
                return InternalServerError(exception);
            }

            return Ok();
        }

        [AuthorizePermission("EPiServerServiceApi", "WriteAccess"), HttpPost, Route("{isPaymentPlan}")]
        public virtual IHttpActionResult PostOrder(bool? isPaymentPlan, [FromBody] Cart cart)
        {
            Logger.LogPost("PostOrder", Request, new []{ isPaymentPlan.ToString() });

            OrderReference orderReference = null;

            try
            {
                if (isPaymentPlan.HasValue && isPaymentPlan.Value)
                {
                    orderReference = this._orderRepository.SaveAsPaymentPlan(cart);
                }
                else
                {
                    orderReference = this._orderRepository.SaveAsPurchaseOrder(cart);
                }
            }
            catch(Exception exception)
            {
                Logger.Error(exception.Message, exception);
                return InternalServerError(exception);
            }

            return Ok(orderReference);
        }
    }
}