using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Web.Http;
using EPiServer.Commerce.Order;
using EPiServer.ServiceApi.Configuration;
using EPiServer.ServiceApi.Util;
using Mediachase.Commerce.Orders;
using Mediachase.Commerce.Website.Helpers;

namespace Geta.ServiceApi.Commerce.Controllers
{
    [AuthorizePermission("EPiServerServiceApi", "WriteAccess"), RequireHttps, RoutePrefix("episerverapi/commerce/cart")]
    public class CartApiController : ApiController
    {
        private readonly Func<string, CartHelper> _cartHelper;

        private readonly string defaultName = Cart.DefaultName;

        private static readonly ApiCallLogger Logger = new ApiCallLogger(typeof(OrderApiController));

        private readonly IOrderRepository _orderRepository;

        public CartApiController(IOrderRepository orderRepository)
        {
            this._orderRepository = orderRepository;
        }

        public CartApiController(Func<string, CartHelper> cartHelper)
        {
            this._cartHelper = cartHelper;
        }

        [AuthorizePermission("EPiServerServiceApi", "ReadAccess"), HttpGet, Route("{customerId}/{name}")]
        public virtual IHttpActionResult GetCart(Guid customerId, string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                name = defaultName;
            }

            var cart = this._orderRepository.LoadOrCreate<Cart>(customerId, name);

            return Ok(cart);
        }

        [AuthorizePermission("EPiServerServiceApi", "ReadAccess"), HttpGet, Route()]
        public virtual IHttpActionResult GetCarts()
        {
            // load all carts

            return Ok();
        }

        [AuthorizePermission("EPiServerServiceApi", "WriteAccess"), HttpPut, Route("{Reference}")]
        public virtual IHttpActionResult PutCart([FromBody] ExpandoObject Updated, EPiServer.DataAccess.SaveAction action = EPiServer.DataAccess.SaveAction.Save)
        {
            return Ok();
        }

        [AuthorizePermission("EPiServerServiceApi", "WriteAccess"), HttpDelete, Route("{customerId}/{name}")]
        public virtual IHttpActionResult DeleteCart(Guid customerId, string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                name = defaultName;
            }

            var existingCart = this._orderRepository.LoadOrCreate<Cart>(customerId, name);

            if (existingCart == null)
            {
                return NotFound();
            }

            this._orderRepository.Delete(existingCart.OrderLink);

            return Ok();
        }

        [AuthorizePermission("EPiServerServiceApi", "WriteAccess"), HttpPost, Route("")]
        public virtual IHttpActionResult CreateCart([FromBody] ExpandoObject cart, EPiServer.DataAccess.SaveAction action = EPiServer.DataAccess.SaveAction.Save)
        {
            var properties = cart as IDictionary<string, object>;

            return Ok();
        }

        private CartHelper CartHelper
        {
            get { return _cartHelper(defaultName); }
        }
    }
}