using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using Geta.ServiceApi.Commerce.Models;
using Newtonsoft.Json;
using Xunit;

namespace Geta.ServiceApi.Commerce.Tests.Controllers
{
    public class CustomerApiControllerTests : ApiControllerBase
    {
        [Fact]
        public void get_returns_contact()
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            var contactId = Guid.Parse("2A40754D-86D5-460B-A5A4-32BC87703567"); // admin contact

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(IntegrationUrl);

                Authenticate(client);
                Get(client);
                Get(contactId, client);
            }
        }

        [Fact]
        public void post_creates_new_contact()
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            var userId = Guid.Parse("2A40754D-86D5-460B-A5A4-32BC87703567"); // admin contact

            var model = new Contact
            {
                FirstName = "Frederik",
                LastName = "Vig",
                Email = "frederik@geta.no",
                RegistrationSource = "Geta.ServiceApi.Commerce integration tests",
                Addresses = new List<CustomerAddress>
                {
                    
                }
            };


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(IntegrationUrl);

                Authenticate(client);
                Post(userId, null, client);
            }
        }

        private static void Get(Guid contactId, HttpClient client)
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

        private static void Post(Guid userId, Contact model, HttpClient client)
        {
            var json = JsonConvert.SerializeObject(model);
            var response = client.PostAsync($"/episerverapi/commerce/customer/contact/{userId}", new StringContent(json, Encoding.UTF8, "application/json")).Result;

            string message = response.Content.ReadAsStringAsync().Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Get failed! Status: {response.StatusCode}. Message: {message}");
            }
        }
    }
}