using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Script.Serialization;
using Mediachase.Commerce.Orders;
using Newtonsoft.Json;
using OrderGroup = Geta.ServiceApi.Commerce.Models.OrderGroup;
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

            var model = new OrderGroup();

            model.CustomerId = contactId;
            model.Name = cartName;

            // Add address info
            // Add LineItems

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(IntegrationUrl);

                Authenticate(client);
                OrderReference orderReference = Post(model, client);
                Delete(orderReference.OrderGroupId, client);
            }
        }

        [Fact]
        public void post_creates_new_order_and_searches_it()
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            var orderGroupId = 66666;
            var contactId = Guid.Parse("2A40754D-86D5-460B-A5A4-32BC87703567"); // admin contact
            var cartName = Cart.DefaultName;

            var model = new OrderGroup();

            model.CustomerId = contactId;
            model.Name = cartName;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(IntegrationUrl);

                Authenticate(client);
                var orderReference = Post(model, client);

                Search(OrderShipmentStatus.Packing, Guid.Empty, client);

                Delete(orderReference.OrderGroupId, client);
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

        private static void Search(OrderShipmentStatus orderShipmentStatus, Guid shippingMethodId, HttpClient client)
        {
            var response = client.GetAsync($"/episerverapi/commerce/order/0/100/search/{orderShipmentStatus}/{shippingMethodId}").Result;

            var message = response.Content.ReadAsStringAsync().Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Get failed! Status: {response.StatusCode}. Message: {message}");
            }
        }

        private static OrderReference Post(OrderGroup model, HttpClient client)
        {
            // Problems with using JavaScript Serializer circular reference exception. Works with JSON.NET
            var serializer = new JavaScriptSerializer();
            //var json = serializer.Serialize(model);

            var json = JsonConvert.SerializeObject(model);

            var response = client.PostAsync($"/episerverapi/commerce/order/isPaymentPlan=false", new StringContent(json, Encoding.UTF8, "application/json")).Result;

            string message = response.Content.ReadAsStringAsync().Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Post failed! Status: {response.StatusCode}. Message: {message}");
            }

            return JsonConvert.DeserializeObject<OrderReference>(message);
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