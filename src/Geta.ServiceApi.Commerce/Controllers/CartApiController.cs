using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Web.Http;
using EPiServer.ServiceApi.Configuration;
using Mediachase.Commerce.Website.Helpers;

namespace Geta.ServiceApi.Commerce.Controllers
{
    [AuthorizePermission("EPiServerServiceApi", "WriteAccess"), RequireHttps, RoutePrefix("episerverapi/commerce/cart")]
    public class CartApiController : ApiController
    {
        private readonly Func<string, CartHelper> _cartHelper;

        private readonly string _cartName = Mediachase.Commerce.Orders.Cart.DefaultName;

        public CartApiController(Func<string, CartHelper> cartHelper)
        {
            this._cartHelper = cartHelper;
        }

        public virtual IHttpActionResult GetCart(string customerId)
        {
            // update to initialize cart with Guid user ID
            var cart = CartHelper.Cart;

            return Ok(cart);
        }

        public virtual IHttpActionResult GetCarts()
        {
            return Ok();
        }

        [AuthorizePermission("EPiServerServiceApi", "WriteAccess"), HttpPut, Route("{Reference}")]
        public virtual IHttpActionResult PutCart([FromBody] ExpandoObject Updated, EPiServer.DataAccess.SaveAction action = EPiServer.DataAccess.SaveAction.Save)
        {
            return Ok();
        }

        [AuthorizePermission("EPiServerServiceApi", "WriteAccess"), HttpDelete, Route("{cartId}")]
        public virtual IHttpActionResult DeleteCart(string cartId)
        {
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
            get { return _cartHelper(_cartName); }
        }
    }
}