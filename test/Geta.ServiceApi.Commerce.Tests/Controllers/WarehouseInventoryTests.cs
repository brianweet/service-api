using System;
using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Xunit;

namespace Geta.ServiceApi.Commerce.Tests.Controllers
{
    public class WarehouseInventoryTests : ApiControllerBase
    {
        [Fact]
        public void post_adds_inventory_item()
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            var warehouseCode = "default";
            var entryCode = "SKU-35278811";

            var model = new WarehouseInventory
            {
                AllowBackorder = true,
                AllowPreorder = true,
                BackorderAvailabilityDate = DateTime.UtcNow,
                BackorderQuantity = 2,
                CatalogEntryCode = entryCode,
                InStockQuantity = 23,
                InventoryStatus = "Enabled",
                PreorderAvailabilityDate = DateTime.UtcNow,
                PreorderQuantity = 3,
                ReorderMinQuantity = 1,
                ReservedQuantity = 1,
                WarehouseCode = warehouseCode
            };

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(IntegrationUrl);

                Authenticate(client);
                GetCatalogs(client);
                GetFirst10Entries(client);
                GetEntry(entryCode, client);
                Post(model, client);
                Get(model, client);
                Delete(model, client);
            }
        }

        private void GetCatalogs(HttpClient client)
        {
            var response =
                client.GetAsync("/episerverapi/commerce/catalogs")
                    .Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Get Catalogs failed! Status: {response.StatusCode}");
            }
        }

        private void GetFirst10Entries(HttpClient client)
        {
            var response =
                client.GetAsync("/episerverapi/commerce/entries/1/10")
                    .Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Get first 10 Entries failed! Status: {response.StatusCode}");
            }
        }

        private static void GetEntry(string catalogEntryCode, HttpClient client)
        {
            var response =
                client.GetAsync($"/episerverapi/commerce/entries/{catalogEntryCode}")
                    .Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Get Entry failed! Status: {response.StatusCode}");
            }
        }

        private static void Get(WarehouseInventory model, HttpClient client)
        {
            var response =
                client.GetAsync($"/episerverapi/commerce/entries/{model.CatalogEntryCode}/inventories")
                    .Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Get failed! Status: {response.StatusCode}");
            }
        }

        private static void Delete(WarehouseInventory model, HttpClient client)
        {
            var response =
                client.DeleteAsync($"/episerverapi/commerce/entries/{model.CatalogEntryCode}/inventories/{model.WarehouseCode}")
                    .Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Delete failed! Status: {response.StatusCode}");
            }
        }

        private static void Post(WarehouseInventory model, HttpClient client)
        {
            var json = JsonConvert.SerializeObject(model);
            var response =
                client.PostAsync($"/episerverapi/commerce/entries/{model.CatalogEntryCode}/inventories",
                    new StringContent(json, Encoding.UTF8, "application/json"))
                    .Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Post failed! Status: {response.StatusCode}");
            }
        }
    }

    [Serializable]
    public class WarehouseInventory
    {
        public string CatalogEntryCode { get; set; }
        public Guid ApplicationId { get; set; }
        public string WarehouseCode { get; set; }
        public string WarehouseLink { get; set; }
        public decimal InStockQuantity { get; set; }
        public decimal ReservedQuantity { get; set; }
        public decimal ReorderMinQuantity { get; set; }
        public decimal PreorderQuantity { get; set; }
        public decimal BackorderQuantity { get; set; }
        public bool AllowBackorder { get; set; }
        public bool AllowPreorder { get; set; }
        public string InventoryStatus { get; set; }
        public DateTime? PreorderAvailabilityDate { get; set; }
        public DateTime? BackorderAvailabilityDate { get; set; }
    }
}