using System;
using System.Collections.Generic;
using System.Web.Http;
using EPiServer.Commerce.Order;
using EPiServer.ServiceApi.Configuration;
using EPiServer.ServiceApi.Util;
using Geta.ServiceApi.Commerce.Mappings;
using Geta.ServiceApi.Commerce.Models;
using Mediachase.Commerce.Orders;
using Mediachase.Commerce.Orders.Search;
using Cart = Mediachase.Commerce.Orders.Cart;

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
            _orderRepository = orderRepository;
        }

        [AuthorizePermission("EPiServerServiceApi", "ReadAccess"), HttpGet, Route("{orderGroupId}")]
        public virtual IHttpActionResult GetOrder(int orderGroupId)
        {
            Logger.LogGet("GetOrders", Request, new[] { orderGroupId.ToString() });

            PurchaseOrder order;

            try
            {
                order = _orderRepository.Load<PurchaseOrder>(orderGroupId);
            }
            catch (Exception exception)
            {
                Logger.Error(exception.Message, exception);
                return InternalServerError(exception);
            }

            if (order == null)
            {
                return NotFound();
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
                orders = _orderRepository.Load(customerId, _defaultName);
            }
            catch (Exception exception)
            {
                Logger.Error(exception.Message, exception);
                return InternalServerError(exception);
            }

            return Ok(orders);
        }

        [AuthorizePermission("EPiServerServiceApi", "ReadAccess"), HttpGet, Route("{start}/{maxCount}/search")]
        public virtual IHttpActionResult SearchOrders(int start, int maxCount, [FromUri] SearchOrdersRequest request)
        {
            Logger.LogGet("GetOrders", Request, new[] {start.ToString(), maxCount.ToString(), $"{request?.OrderShipmentStatus}", $"{request?.ShippingMethodId}"});

            if (maxCount < 1 || maxCount > 100)
            {
                maxCount = 10;
            }

            PurchaseOrder[] orders;

            try
            {
                var searchOptions = new OrderSearchOptions
                {
                    CacheResults = false,
                    StartingRecord = start,
                    RecordsToRetrieve = maxCount,
                    Namespace = "Mediachase.Commerce.Orders"
                };

                var parameters = new OrderSearchParameters();
                searchOptions.Classes.Add("PurchaseOrder");
                parameters.SqlMetaWhereClause = string.Empty;

                if (request?.OrderShipmentStatus != null && request.ShippingMethodId != null && request.ShippingMethodId != Guid.Empty)
                {
                    parameters.SqlWhereClause =
                        $"[OrderGroupId] IN (SELECT [OrderGroupId] FROM [Shipment] WHERE [Status] = '{request.OrderShipmentStatus}' AND [ShippingMethodId] = '{request.ShippingMethodId}')";
                }
                else if (request?.OrderShipmentStatus != null)
                {
                    parameters.SqlWhereClause = $"[OrderGroupId] IN (SELECT [OrderGroupId] FROM [Shipment] WHERE [Status] = '{request.OrderShipmentStatus}')";
                }
                else if (request?.ShippingMethodId != null && request.ShippingMethodId != Guid.Empty)
                {
                    parameters.SqlWhereClause = $"[OrderGroupId] IN (SELECT [OrderGroupId] FROM [Shipment] WHERE [ShippingMethodId] = '{request.ShippingMethodId}')";
                }

                orders = OrderContext.Current.FindPurchaseOrders(parameters, searchOptions);
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

        [AuthorizePermission("EPiServerServiceApi", "WriteAccess"), HttpPut, Route("{orderGroupId}")]
        public virtual IHttpActionResult PutOrder(int orderGroupId, [FromBody] Models.OrderGroup orderGroup)
        {
            OrderReference orderReference;

            try
            {
                var order = _orderRepository.Load<PurchaseOrder>(orderGroupId);
                order = orderGroup.ConvertToPurchaseOrder(order);
                orderReference = _orderRepository.Save(order);
            }
            catch (Exception exception)
            {
                Logger.Error(exception.Message, exception);
                return InternalServerError(exception);
            }

            return Ok(orderReference);
        }

        [AuthorizePermission("EPiServerServiceApi", "WriteAccess"), HttpDelete, Route("{orderGroupId}")]
        public virtual IHttpActionResult DeleteOrder(int orderGroupId)
        {
            Logger.LogDelete("DeleteOrder", Request, new[] {orderGroupId.ToString()});

            var existingOrder = _orderRepository.Load<PurchaseOrder>(orderGroupId);

            if (existingOrder == null)
            {
                return NotFound();
            }

            try
            {
                var orderReference = new OrderReference(orderGroupId, existingOrder.Name, existingOrder.CustomerId, typeof (PurchaseOrder));

                _orderRepository.Delete(orderReference);
            }
            catch (Exception exception)
            {
                Logger.Error(exception.Message, exception);
                return InternalServerError(exception);
            }

            return Ok();
        }

        [AuthorizePermission("EPiServerServiceApi", "WriteAccess"), HttpPost, Route("{isPaymentPlan}")]
        public virtual IHttpActionResult PostOrder(bool? isPaymentPlan, [FromBody] Models.OrderGroup orderGroup)
        {
            Logger.LogPost("PostOrder", Request, new []{ isPaymentPlan.ToString() });

            OrderReference orderReference;

            try
            {
                if (isPaymentPlan.HasValue && isPaymentPlan.Value)
                {
                    var paymentPlan = _orderRepository.Create<PaymentPlan>(orderGroup.CustomerId, orderGroup.Name);
                    paymentPlan = orderGroup.ConvertToPaymentPlan(paymentPlan);
                    orderReference = _orderRepository.SaveAsPaymentPlan(paymentPlan);
                }
                else
                {
                    var purchaseOrder = _orderRepository.Create<PurchaseOrder>(orderGroup.CustomerId, orderGroup.Name);
                    purchaseOrder = orderGroup.ConvertToPurchaseOrder(purchaseOrder);
                    orderReference = _orderRepository.SaveAsPurchaseOrder(purchaseOrder);
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