using System.Collections.Generic;
using System.Dynamic;
using System.Web.Http;
using EPiServer.ServiceApi.Configuration;

namespace Geta.ServiceApi.Commerce.Controllers
{
    [/*AuthorizePermission("EPiServerServiceApi", "WriteAccess"),*/ RequireHttps, RoutePrefix("episerverapi/cart")]
    public class CartApiController : ApiController
    {
        public virtual IHttpActionResult GetCart(string customerId)
        {
            return Ok();
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
    }
}