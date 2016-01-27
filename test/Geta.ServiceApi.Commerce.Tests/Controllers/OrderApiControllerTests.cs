using System;
using System.Net;
using System.Net.Http;
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
    }
}