using System;
using System.Net;
using System.Net.Http;
using Xunit;

namespace Geta.ServiceApi.Commerce.Tests.Controllers
{
    public class CustomerApiControllerTests : ApiControllerBase
    {
        [Fact]
        public void get_returns_contact()
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            string contactId = "2A40754D-86D5-460B-A5A4-32BC87703567";

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(IntegrationUrl);

                Authenticate(client);
                Get(client);
                Get(contactId, client);
            }
        }

        private static void Get(string contactId, HttpClient client)
        {
            var response = client.GetAsync($"/episerverapi/commerce/customer/contact/{contactId}").Result;

            string message = response.Content.ReadAsStringAsync().Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Get failed! Status: {response.StatusCode}. Message: {message}");
            }
        }

        private static void Get(HttpClient client)
        {
            var response = client.GetAsync($"/episerverapi/commerce/customer/contact").Result;

            string message = response.Content.ReadAsStringAsync().Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Get failed! Status: {response.StatusCode}. Message: {message}");
            }
        }
    }
}