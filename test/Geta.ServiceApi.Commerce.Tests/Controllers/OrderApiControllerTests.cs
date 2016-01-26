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

            string orderId = "order id";

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(IntegrationUrl);

                Authenticate(client);
                Get(orderId, client);
            }
        }

        private static void Get(string orderId, HttpClient client)
        {
            var response = client.GetAsync($"/episerverapi/commerce/order/{orderId}").Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Get failed! Status: {response.StatusCode}");
            }
        }
    }
}