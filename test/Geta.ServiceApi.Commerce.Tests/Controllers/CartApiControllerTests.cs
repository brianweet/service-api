using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Script.Serialization;
using Geta.ServiceApi.Commerce.Models;
using Mediachase.Commerce;
using Newtonsoft.Json;
using Xunit;
using Cart = Mediachase.Commerce.Orders.Cart;

namespace Geta.ServiceApi.Commerce.Tests.Controllers
{
    public class CartApiControllerTests : ApiControllerBase
    {
        [Fact]
        public void get_returns_cart()
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            var customerId = Guid.Parse("2A40754D-86D5-460B-A5A4-32BC87703567"); // admin contact;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(IntegrationUrl);

                Authenticate(client);
                Get(customerId, client);
                Get(client);
            }
        }

        [Fact]
        public void post_creates_new_cart()
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            int orderGroupId = 12345;
            var contactId = Guid.Parse("2A40754D-86D5-460B-A5A4-32BC87703567"); // admin contact
            string cartName = Cart.DefaultName;

            var model = new OrderGroup();
            model.Name = cartName;

            model.CustomerId = contactId;

            // Add address info
            // Add LineItems

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(IntegrationUrl);

                Authenticate(client);
                Post(model, client);
            }
        }

        private static void Get(Guid customerId, HttpClient client)
        {
            var response = client.GetAsync($"/episerverapi/commerce/cart/{customerId}/default").Result;

            string message = response.Content.ReadAsStringAsync().Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Get failed! Status: {response.StatusCode}. Message: {message}");
            }
        }

        private static void Get(HttpClient client)
        {
            var response = client.GetAsync("/episerverapi/commerce/cart/search/1/10").Result;

            string message = response.Content.ReadAsStringAsync().Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Get failed! Status: {response.StatusCode}. Message: {message}");
            }
        }

        // TODO delete

        // TODO put

        private static void Post(OrderGroup model, HttpClient client)
        {
            // Problems with using JavaScript Serializer circular reference exception. Works with JSON.NET
            var serializer = new JavaScriptSerializer();
            //var json = serializer.Serialize(model);

            var json = JsonConvert.SerializeObject(model);

            var response = client.PostAsync($"/episerverapi/commerce/cart", new StringContent(json, Encoding.UTF8, "application/json")).Result;

            string message = response.Content.ReadAsStringAsync().Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Post failed! Status: {response.StatusCode}. Message: {message}");
            }
        }
    }
}