using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Script.Serialization;
using Geta.ServiceApi.Commerce.Models;
using Mediachase.Commerce.Customers;
using Xunit;

namespace Geta.ServiceApi.Commerce.Tests.Controllers
{
    public class CustomerApiControllerTests : ApiControllerBase
    {
        // Problems with using default JSON.NET (seems to be related to ScriptIgnoreAttribute)
        private static readonly JavaScriptSerializer Serializer = new JavaScriptSerializer();

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

            var userId = Guid.Parse("099E12F5-684C-4F34-A38B-CEBFC8E41816"); 

            var addresses = new List<Address>();
            var address = new Address
            {
                ShippingDefault = true,
                PostalCode = "10012",
                City = "New York",
                CountryCode = "US",
                CountryName = "United States",
                Region = "NY",
                Email = "frederik@geta.no",
                FirstName = "Frederik",
                LastName = "Vig",
                Line1 = "379 West Broadway",
                Line2 = "Suite 248",
                DaytimePhoneNumber = "(347) 261-7408",
                EveningPhoneNumber = "(347) 261-7408",
                Name = "Shipping address",
                Modified = DateTime.UtcNow
            };
            addresses.Add(address);

            var model = new Contact
            {
                FirstName = "Frederik",
                LastName = "Vig",
                Email = "frederik@geta.no",
                RegistrationSource = "Geta.ServiceApi.Commerce integration tests",
                Addresses = addresses
            };

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(IntegrationUrl);

                Authenticate(client);
                Post(userId, model, client);
                Delete(userId, client);
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
            var json = Serializer.Serialize(model);

            var response = client.PostAsync($"/episerverapi/commerce/customer/contact/{userId}", new StringContent(json, Encoding.UTF8, "application/json")).Result;

            string message = response.Content.ReadAsStringAsync().Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Post failed! Status: {response.StatusCode}. Message: {message}");
            }
        }

        private static void Delete(Guid contactId, HttpClient client)
        {
            var response = client.DeleteAsync($"/episerverapi/commerce/customer/contact/{contactId}").Result;

            string message = response.Content.ReadAsStringAsync().Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Delete failed! Status: {response.StatusCode}. Message: {message}");
            }
        }

        private static void PutCustomer(Guid contactId, Contact model, HttpClient client)
        {
            var json = Serializer.Serialize(model);

            var response = client.PutAsync($"/episerverapi/commerce/customer/contact/{contactId}", new StringContent(json, Encoding.UTF8, "application/json")).Result;

            string message = response.Content.ReadAsStringAsync().Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Put failed! Status: {response.StatusCode}. Message: {message}");
            }
        }

        private static void Get(string orgId, HttpClient client)
        {
            var response = client.GetAsync($"/episerverapi/commerce/customer/organization/{orgId}").Result;

            string message = response.Content.ReadAsStringAsync().Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Get failed! Status: {response.StatusCode}. Message: {message}");
            }
        }

        private static void GetOrganization(HttpClient client)
        {
            var response = client.GetAsync($"/episerverapi/commerce/customer/organization").Result;

            string message = response.Content.ReadAsStringAsync().Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Get failed! Status: {response.StatusCode}. Message: {message}");
            }
        }

        private static void PostOrganization(Organization model, HttpClient client)
        {
            var json = Serializer.Serialize(model);

            var response = client.PostAsync($"/episerverapi/commerce/customer/organization", new StringContent(json, Encoding.UTF8, "application/json")).Result;

            string message = response.Content.ReadAsStringAsync().Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Post failed! Status: {response.StatusCode}. Message: {message}");
            }
        }

        private static void DeleteOrganization(string orgId, HttpClient client)
        {
            var response = client.DeleteAsync($"/episerverapi/commerce/customer/organization/{orgId}").Result;

            string message = response.Content.ReadAsStringAsync().Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Delete failed! Status: {response.StatusCode}. Message: {message}");
            }
        }

        private static void PutOrganization(Organization model, HttpClient client)
        {
            var json = Serializer.Serialize(model);

            var response = client.PutAsync($"/episerverapi/commerce/customer/organization", new StringContent(json, Encoding.UTF8, "application/json")).Result;

            string message = response.Content.ReadAsStringAsync().Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Put failed! Status: {response.StatusCode}. Message: {message}");
            }
        }
    }
}