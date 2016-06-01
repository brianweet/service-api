using System;
using System.Net.Http;
using System.Text;
using Geta.ServiceApi.Commerce.Tests.Base;
using Newtonsoft.Json;
using Xunit;

namespace Geta.ServiceApi.Commerce.Tests.Controllers
{
    public class WarehouseInventoryTests : ApiTestsBase
    {
        [Fact]
        public void post_adds_inventory_item()
        {
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

            GetCatalogs();
            GetFirst10Entries();
            GetEntry(entryCode);
            Post(model);
            Get(model);
            Delete(model);
        }

        private void GetCatalogs()
        {
            var response =
                Client.GetAsync("/episerverapi/commerce/catalogs")
                    .Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Get Catalogs failed! Status: {response.StatusCode}");
            }
        }

        private void GetFirst10Entries()
        {
            var response =
                Client.GetAsync("/episerverapi/commerce/entries/1/10")
                    .Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Get first 10 Entries failed! Status: {response.StatusCode}");
            }
        }

        private void GetEntry(string catalogEntryCode)
        {
            var response =
                Client.GetAsync($"/episerverapi/commerce/entries/{catalogEntryCode}")
                    .Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Get Entry failed! Status: {response.StatusCode}");
            }
        }

        private void Get(WarehouseInventory model)
        {
            var response =
                Client.GetAsync($"/episerverapi/commerce/entries/{model.CatalogEntryCode}/inventories")
                    .Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Get failed! Status: {response.StatusCode}");
            }
        }

        private void Delete(WarehouseInventory model)
        {
            var response =
                Client.DeleteAsync($"/episerverapi/commerce/entries/{model.CatalogEntryCode}/inventories/{model.WarehouseCode}")
                    .Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Delete failed! Status: {response.StatusCode}");
            }
        }

        private void Post(WarehouseInventory model)
        {
            var json = JsonConvert.SerializeObject(model);
            var response =
                Client.PostAsync($"/episerverapi/commerce/entries/{model.CatalogEntryCode}/inventories",
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