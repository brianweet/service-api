using System;
using System.Net;
using System.Net.Http;
using Xunit;

namespace Geta.ServiceApi.Commerce.Tests.Controllers
{
    public class CustomerApiControllerTests : ApiControllerBase
    {
        [Fact]
        public void get_returns_customer()
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            string customerId = Guid.NewGuid().ToString();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(IntegrationUrl);

                Authenticate(client);
                Get(customerId, client);
            }
        }

        private static void Get(string customerId, HttpClient client)
        {
            var response = client.GetAsync($"/episerverapi/commerce/customer/{customerId}").Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Get failed! Status: {response.StatusCode}");
            }
        }
    }
}