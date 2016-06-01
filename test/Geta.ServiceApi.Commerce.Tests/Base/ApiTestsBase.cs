using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;

namespace Geta.ServiceApi.Commerce.Tests.Base
{
    public abstract class ApiTestsBase
    {
        readonly string _username = "admin";
        readonly string _password = "store";

        protected readonly HttpClient Client;
        protected string IntegrationUrl = "https://serviceapi.localtest.me";

        protected ApiTestsBase()
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            Client = new HttpClient
            {
                BaseAddress = new Uri(IntegrationUrl)
            };
            Authenticate(Client);
        }

        public void Dispose()
        {
            Client.Dispose();
        }

        private void Authenticate(HttpClient client)
        {
            var fields = new Dictionary<string, string>
                {
                    { "grant_type", "password" },
                    { "username", _username },
                    { "password", _password }
                };
            var response = client.PostAsync("/episerverapi/token", new FormUrlEncodedContent(fields)).Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Authentication failed! Status: {response.StatusCode}");
            }

            var content = response.Content.ReadAsStringAsync().Result;
            var token = JObject.Parse(content).GetValue("access_token").ToString();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
    }
}