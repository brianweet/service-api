using System;
using System.Web.Http;
using EPiServer.Commerce.Marketing;
using EPiServer.Commerce.Order;
using EPiServer.ServiceApi.Configuration;
using EPiServer.ServiceApi.Util;
using Geta.ServiceApi.Commerce.Mappings;
using Mediachase.Commerce.Orders;
using Mediachase.Commerce.Orders.Search;
using OrderGroup = Geta.ServiceApi.Commerce.Models.OrderGroup;

namespace Geta.ServiceApi.Commerce.Controllers
{
    [AuthorizePermission("EPiServerServiceApi", "WriteAccess"), RequireHttps, RoutePrefix("episerverapi/commerce/cart")]
    public class CartApiController : ApiController
    {
        private readonly string _defaultName = Cart.DefaultName;

        private static readonly ApiCallLogger Logger = new ApiCallLogger(typeof(OrderApiController));

        private readonly IOrderRepository _orderRepository;
        private readonly IPromotionEngine _promotionEngine;

        public CartApiController(IOrderRepository orderRepository, IPromotionEngine promotionEngine)
        {
            this._orderRepository = orderRepository;
            this._promotionEngine = promotionEngine;
        }

        [AuthorizePermission("EPiServerServiceApi", "ReadAccess"), HttpGet, Route("{customerId}/{name}")]
        public virtual IHttpActionResult GetCart(Guid customerId, string name)
        {
            Logger.LogGet("GetCart", Request, new []{ customerId .ToString(), name});

            if (string.IsNullOrEmpty(name))
            {
                name = _defaultName;
            }

            IOrderGroup cart;

            try
            {
                cart = this._orderRepository.LoadOrCreate<Cart>(customerId, name);
            }
            catch (Exception exception)
            {
                Logger.Error(exception.Message, exception);
                return InternalServerError(exception);
            }

            return Ok(cart);
        }

        [AuthorizePermission("EPiServerServiceApi", "ReadAccess"), HttpGet, Route("search/{start}/{maxCount}")]
        public virtual IHttpActionResult GetCarts(int start, int maxCount)
        {
            Logger.LogGet("GetCarts", Request, new []{start.ToString(), maxCount.ToString()});

            if (maxCount < 1 || maxCount > 100)
            {
                maxCount = 10;
            }

            Cart[] carts;

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
                searchOptions.Classes.Add("LineItemEx");
                parameters.SqlWhereClause = "OrderGroupId IN (Select ObjectId FROM OrderGroup_ShoppingCart)";
                carts = OrderContext.Current.FindCarts(parameters, searchOptions);
            }
            catch (Exception exception)
            {
                Logger.Error(exception.Message, exception);
                return InternalServerError(exception);
            }

            return Ok(carts);
        }

        [AuthorizePermission("EPiServerServiceApi", "WriteAccess"), HttpPut, Route]
        public virtual IHttpActionResult PutCart([FromBody] Cart cart)
        {
            Logger.LogPut("PutCart", Request);

            OrderReference orderReference;

            try
            {
                orderReference = _orderRepository.Save(cart);
            }
            catch (Exception exception)
            {
                Logger.Error(exception.Message, exception);
                return InternalServerError(exception);
            }

            return Ok(orderReference);
        }

        [AuthorizePermission("EPiServerServiceApi", "WriteAccess"), HttpDelete, Route("{customerId}/{name}")]
        public virtual IHttpActionResult DeleteCart(Guid customerId, string name)
        {
            Logger.LogDelete("DeleteCart", Request, new []{customerId.ToString(), name});

            if (string.IsNullOrEmpty(name))
            {
                name = _defaultName;
            }

            var existingCart = this._orderRepository.LoadOrCreate<Cart>(customerId, name);

            if (existingCart == null)
            {
                return NotFound();
            }

            try
            {
                this._orderRepository.Delete(new OrderReference(existingCart.OrderGroupId, name, customerId, typeof(Cart)));
            }
            catch (Exception exception)
            {
                Logger.Error(exception.Message, exception);
                return InternalServerError(exception);
            }

            return Ok();
        }

        [AuthorizePermission("EPiServerServiceApi", "WriteAccess"), HttpPost, Route]
        public virtual IHttpActionResult PostCart([FromBody] OrderGroup orderGroup)
        {
            Logger.LogPost("PostCart", Request);

            try
            {
                if (string.IsNullOrEmpty(orderGroup.Name))
                {
                    throw new ArgumentNullException(nameof(orderGroup.Name));
                }

                if (orderGroup.CustomerId == Guid.Empty)
                {
                    throw new ArgumentNullException(nameof(orderGroup.CustomerId));
                }

                var cart = _orderRepository.Create<Cart>(orderGroup.CustomerId, orderGroup.Name);

                cart = orderGroup.ConvertToCart(cart);

                _promotionEngine.Run(cart);
                cart.AcceptChanges();

                return Ok(cart);
            }
            catch (Exception exception)
            {
                Logger.Error(exception.Message, exception);
                return InternalServerError(exception);
            }
        }
    }
}