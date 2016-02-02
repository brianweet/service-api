using System;
using System.Web.Http;
using EPiServer.Commerce.Order;
using EPiServer.ServiceApi.Configuration;
using EPiServer.ServiceApi.Util;
using Mediachase.Commerce.Orders;

namespace Geta.ServiceApi.Commerce.Controllers
{
    [AuthorizePermission("EPiServerServiceApi", "WriteAccess"), RequireHttps, RoutePrefix("episerverapi/commerce/cart")]
    public class CartApiController : ApiController
    {
        private readonly string _defaultName = Cart.DefaultName;

        private static readonly ApiCallLogger Logger = new ApiCallLogger(typeof(OrderApiController));

        private readonly IOrderRepository _orderRepository;

        public CartApiController(IOrderRepository orderRepository)
        {
            this._orderRepository = orderRepository;
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

        [AuthorizePermission("EPiServerServiceApi", "ReadAccess"), HttpGet, Route]
        public virtual IHttpActionResult GetCarts()
        {
            Logger.LogGet("GetCarts", Request);
            // load all carts

            return Ok();
        }

        [AuthorizePermission("EPiServerServiceApi", "WriteAccess"), HttpPut, Route]
        public virtual IHttpActionResult PutCart([FromBody] Cart cart)
        {
            Logger.LogPut("PutCart", Request);

            return Ok();
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
                this._orderRepository.Delete(existingCart.OrderLink);
            }
            catch (Exception exception)
            {
                Logger.Error(exception.Message, exception);
                return InternalServerError(exception);
            }

            return Ok();
        }

        [AuthorizePermission("EPiServerServiceApi", "WriteAccess"), HttpPost, Route]
        public virtual IHttpActionResult PostCart([FromBody] Cart cart)
        {
            Logger.LogPost("PostCart", Request);

            return Ok();
        }
    }
}