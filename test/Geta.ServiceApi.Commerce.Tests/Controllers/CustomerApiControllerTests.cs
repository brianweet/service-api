using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Script.Serialization;
using Geta.ServiceApi.Commerce.Models;
using Xunit;
using Organization = Geta.ServiceApi.Commerce.Models.Organization;

namespace Geta.ServiceApi.Commerce.Tests.Controllers
{
    public sealed class CustomerApiControllerTests : ApiControllerBase
    {
        // Problems with using default JSON.NET (seems to be related to ScriptIgnoreAttribute)
        private static readonly JavaScriptSerializer Serializer = new JavaScriptSerializer();

        private readonly HttpClient _client;

        public CustomerApiControllerTests()
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            _client = new HttpClient {BaseAddress = new Uri(IntegrationUrl)};
            Authenticate(_client);
        }

        [Fact]
        public void get_returns_contact()
        {
            var contactId = Guid.Parse("2A40754D-86D5-460B-A5A4-32BC87703567"); // admin contact

            Get();
            Get(contactId);
        }

        [Fact]
        public void post_creates_new_contact()
        {
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

            Post(userId, model);
            Delete(userId);
        }

        [Fact]
        public void post_creates_new_organization()
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            var model = new Organization();

            var orgId = string.Empty;

            PostOrganization(model);
            //DeleteOrganization(orgId, client);
        }

        private void Get(Guid contactId)
        {
            var response = _client.GetAsync($"/episerverapi/commerce/customer/contact/{contactId}").Result;

            var message = response.Content.ReadAsStringAsync().Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Get failed! Status: {response.StatusCode}. Message: {message}");
            }
        }

        private void Get()
        {
            var response = _client.GetAsync($"/episerverapi/commerce/customer/contact").Result;

            var message = response.Content.ReadAsStringAsync().Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Get failed! Status: {response.StatusCode}. Message: {message}");
            }
        }

        private void Post(Guid userId, Contact model)
        {
            var json = Serializer.Serialize(model);

            var response = _client.PostAsync($"/episerverapi/commerce/customer/contact/{userId}", new StringContent(json, Encoding.UTF8, "application/json")).Result;

            var message = response.Content.ReadAsStringAsync().Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Post failed! Status: {response.StatusCode}. Message: {message}");
            }
        }

        private void Delete(Guid contactId)
        {
            var response = _client.DeleteAsync($"/episerverapi/commerce/customer/contact/{contactId}").Result;

            var message = response.Content.ReadAsStringAsync().Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Delete failed! Status: {response.StatusCode}. Message: {message}");
            }
        }

        private void PutCustomer(Guid contactId, Contact model)
        {
            var json = Serializer.Serialize(model);

            var response = _client.PutAsync($"/episerverapi/commerce/customer/contact/{contactId}", new StringContent(json, Encoding.UTF8, "application/json")).Result;

            var message = response.Content.ReadAsStringAsync().Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Put failed! Status: {response.StatusCode}. Message: {message}");
            }
        }

        private void Get(string orgId)
        {
            var response = _client.GetAsync($"/episerverapi/commerce/customer/organization/{orgId}").Result;

            var message = response.Content.ReadAsStringAsync().Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Get failed! Status: {response.StatusCode}. Message: {message}");
            }
        }

        private void GetOrganization()
        {
            var response = _client.GetAsync($"/episerverapi/commerce/customer/organization").Result;

            var message = response.Content.ReadAsStringAsync().Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Get failed! Status: {response.StatusCode}. Message: {message}");
            }
        }

        private void PostOrganization(Organization model)
        {
            var json = Serializer.Serialize(model);

            var response = _client.PostAsync($"/episerverapi/commerce/customer/organization", new StringContent(json, Encoding.UTF8, "application/json")).Result;

            var message = response.Content.ReadAsStringAsync().Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Post failed! Status: {response.StatusCode}. Message: {message}");
            }
        }

        private void DeleteOrganization(string orgId)
        {
            var response = _client.DeleteAsync($"/episerverapi/commerce/customer/organization/{orgId}").Result;

            var message = response.Content.ReadAsStringAsync().Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Delete failed! Status: {response.StatusCode}. Message: {message}");
            }
        }

        private void PutOrganization(Organization model)
        {
            var json = Serializer.Serialize(model);

            var response = _client.PutAsync($"/episerverapi/commerce/customer/organization", new StringContent(json, Encoding.UTF8, "application/json")).Result;

            var message = response.Content.ReadAsStringAsync().Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Put failed! Status: {response.StatusCode}. Message: {message}");
            }
        }
    }
}