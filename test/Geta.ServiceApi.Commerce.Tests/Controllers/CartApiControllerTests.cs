using System;
using System.Net.Http;
using System.Text;
using Geta.ServiceApi.Commerce.Models;
using Geta.ServiceApi.Commerce.Tests.Base;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;
using Cart = Mediachase.Commerce.Orders.Cart;

namespace Geta.ServiceApi.Commerce.Tests.Controllers
{
    public class CartApiControllerTests : ApiTestsBase
    {
        [Fact]
        public void get_returns_cart()
        {
            var customerId = Guid.Parse("2A40754D-86D5-460B-A5A4-32BC87703567"); // admin contact;

            Get(customerId);
            Get();
        }

        [Fact]
        public void post_creates_new_cart()
        {
            var contactId = Guid.Parse("6F1640B8-6DD2-4B36-8C87-BDC2A9C29580"); // admin contact

            var model = new OrderGroup
            {
                Name = Cart.DefaultName,
                CustomerId = contactId
            };

            // Add address info
            // Add LineItems

            var cart = Post(model);
            Delete((Guid)cart.CustomerId, Cart.DefaultName);
        }

        private void Get(Guid customerId)
        {
            var response = Client.GetAsync($"/episerverapi/commerce/cart/{customerId}/default").Result;

            var message = response.Content.ReadAsStringAsync().Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Get failed! Status: {response.StatusCode}. Message: {message}");
            }
        }

        private void Get()
        {
            var response = Client.GetAsync("/episerverapi/commerce/cart/search/1/10").Result;

            var message = response.Content.ReadAsStringAsync().Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Get failed! Status: {response.StatusCode}. Message: {message}");
            }
        }

        // TODO delete

        // TODO put

        private dynamic Post(OrderGroup model)
        {
            var json = JsonConvert.SerializeObject(model);

            var response = Client.PostAsync($"/episerverapi/commerce/cart", new StringContent(json, Encoding.UTF8, "application/json")).Result;

            var message = response.Content.ReadAsStringAsync().Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Post failed! Status: {response.StatusCode}. Message: {message}");
            }

            return JObject.Parse(message);
        }

        private void Delete(Guid customerId, string defaultName)
        {
            var response = Client.DeleteAsync($"/episerverapi/commerce/cart/{customerId}/{defaultName}").Result;

            var message = response.Content.ReadAsStringAsync().Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Delete failed! Status: {response.StatusCode}. Message: {message}");
            }
        }
    }
}