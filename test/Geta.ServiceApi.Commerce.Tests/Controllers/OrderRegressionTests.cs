using System;
using System.IO;
using System.Net.Http;
using System.Text;
using Geta.ServiceApi.Commerce.Tests.Base;
using Xunit;

namespace Geta.ServiceApi.Commerce.Tests.Controllers
{
    public class OrderRegressionTests : ApiTestsBase
    {
        [Fact] // Test against existing order in your DB
        public void it_updates_order_from_xml()
        {
            var xml = File.ReadAllText(@"..\Controllers\order_3487.xml");
            PutXml(xml, 2005);
        }

        private void PutXml(string xml, int id)
        {
            AcceptXml();
            var response =
                Client.PutAsync($"/episerverapi/commerce/order/{id}",
                    new StringContent(xml, Encoding.UTF8, "text/xml")).Result;
            RemoveAcceptXml();

            var message = response.Content.ReadAsStringAsync().Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Post failed! Status: {response.StatusCode}. Message: {message}");
            }
        }
    }
}