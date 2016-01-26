using System;
using System.Net;
using System.Net.Http;
using Xunit;

namespace Geta.ServiceApi.Commerce.Tests.Controllers
{
    public class CartApiControllerTests : ApiControllerBase
    {
        [Fact]
        public void get_returns_cart()
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            string customerId = "customer guid";

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(IntegrationUrl);

                Authenticate(client);
                Get(customerId, client);
            }
        }

        private static void Get(string customerId, HttpClient client)
        {
            var response = client.GetAsync($"/episerverapi/commerce/cart/{customerId}").Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Get failed! Status: {response.StatusCode}");
            }
        }
    }
}