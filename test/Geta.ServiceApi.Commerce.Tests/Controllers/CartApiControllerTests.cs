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

            var customerId = Guid.Parse("2A40754D-86D5-460B-A5A4-32BC87703567"); // admin contact;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(IntegrationUrl);

                Authenticate(client);
                Get(customerId, client);
                Get(client);
            }
        }

        private static void Get(Guid customerId, HttpClient client)
        {
            var response = client.GetAsync($"/episerverapi/commerce/cart/{customerId}/default").Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Get failed! Status: {response.StatusCode}");
            }
        }

        private static void Get(HttpClient client)
        {
            var response = client.GetAsync("/episerverapi/commerce/cart").Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Get failed! Status: {response.StatusCode}");
            }
        }
    }
}