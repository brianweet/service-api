using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Script.Serialization;
using Mediachase.Commerce.Orders;
using Newtonsoft.Json;
using Xunit;

namespace Geta.ServiceApi.Commerce.Tests.Controllers
{
    public class OrderApiControllerTests : ApiControllerBase
    {
        [Fact]
        public void get_returns_order()
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            int orderId = 121121; // not valid order id
            var customerId = Guid.NewGuid();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(IntegrationUrl);

                Authenticate(client);
                Get(orderId, client);
                Get(customerId, client);
            }
        }

        [Fact]
        public void post_creates_new_order()
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            int orderGroupId = 12345;
            var contactId = Guid.Parse("2A40754D-86D5-460B-A5A4-32BC87703567"); // admin contact
            string cartName = Cart.DefaultName;

            var model = new Cart(cartName, contactId);
            {
            };

            // Add customer
            model.CustomerId = contactId;

            // Add address info
            // Add LineItems

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(IntegrationUrl);

                Authenticate(client);
                // TODO fix configuration exception
                Post(model, client);
                Delete(orderGroupId, client);
            }
        }

        private static void Get(int orderId, HttpClient client)
        {
            var response = client.GetAsync($"/episerverapi/commerce/order/{orderId}").Result;

            string message = response.Content.ReadAsStringAsync().Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Get failed! Status: {response.StatusCode}. Message: {message}");
            }
        }

        private static void Get(Guid customerId, HttpClient client)
        {
            var response = client.GetAsync($"/episerverapi/commerce/order/{customerId}/all").Result;

            string message = response.Content.ReadAsStringAsync().Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Get failed! Status: {response.StatusCode}. Message: {message}");
            }
        }

        private static void Post(Cart model, HttpClient client)
        {
            // Problems with using JavaScript Serializer circular reference exception. Works with JSON.NET
            var serializer = new JavaScriptSerializer();
            //var json = serializer.Serialize(model);

            var json = JsonConvert.SerializeObject(model);

            var response = client.PostAsync($"/episerverapi/commerce/order", new StringContent(json, Encoding.UTF8, "application/json")).Result;

            string message = response.Content.ReadAsStringAsync().Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Post failed! Status: {response.StatusCode}. Message: {message}");
            }
        }

        private static void Delete(int orderGroupId, HttpClient client)
        {
            var response = client.DeleteAsync($"/episerverapi/commerce/order/{orderGroupId}").Result;

            string message = response.Content.ReadAsStringAsync().Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Delete failed! Status: {response.StatusCode}. Message: {message}");
            }
        }

        // TODO put
    }
}