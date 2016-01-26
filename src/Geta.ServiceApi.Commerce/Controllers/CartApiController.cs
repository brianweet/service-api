﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Web.Http;
using EPiServer.ServiceApi.Configuration;
using EPiServer.ServiceApi.Util;
using Mediachase.Commerce.Website.Helpers;

namespace Geta.ServiceApi.Commerce.Controllers
{
    [AuthorizePermission("EPiServerServiceApi", "WriteAccess"), RequireHttps, RoutePrefix("episerverapi/commerce/cart")]
    public class CartApiController : ApiController
    {
        private readonly Func<string, CartHelper> _cartHelper;

        private readonly string _cartName = Mediachase.Commerce.Orders.Cart.DefaultName;

        private static readonly ApiCallLogger Logger = new ApiCallLogger(typeof(OrderApiController));


        public CartApiController(Func<string, CartHelper> cartHelper)
        {
            this._cartHelper = cartHelper;
        }

        [AuthorizePermission("EPiServerServiceApi", "ReadAccess"), HttpGet, Route("{customerId}")]
        public virtual IHttpActionResult GetCart(string customerId)
        {
            // update to initialize cart with Guid user ID
            var cart = CartHelper.Cart;

            return Ok(cart);
        }

        [AuthorizePermission("EPiServerServiceApi", "ReadAccess"), HttpGet, Route()]
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