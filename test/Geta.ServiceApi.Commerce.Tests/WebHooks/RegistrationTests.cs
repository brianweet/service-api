using System;
using Geta.ServiceApi.Commerce.Tests.Base;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Geta.ServiceApi.Commerce.Tests.WebHooks
{
    public class RegistrationTests : ApiTestsBase
    {
        [Fact]
        public void it_registers_webhook_receiver()
        {
            var json = @"
            {
                ""WebHookUri"": ""http://serviceapi.localtest.me/api/webhooks/incoming/custom"",
                ""Secret"": ""12345678901234567890123456789012"",
                ""Description"": ""My first WebHook!""
            }
            ";
            var response = Client.PostAsync($"/api/webhooks/registrations", new StringContent(json, Encoding.UTF8, "application/json")).Result;
            var message = response.Content.ReadAsStringAsync().Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Post failed! Status: {response.StatusCode}. Message: {message}");
            }

            var result = JObject.Parse(message);

            Assert.NotNull(result);
            Assert.NotNull(result["Id"]);
        }
    }
}