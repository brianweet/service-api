using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using EPiServer.Commerce.Catalog.ContentTypes;
using EPiServer.Core;
using EPiServer.Reference.Commerce.Site.Features.Market.Services;
using EPiServer.ServiceLocation;
using Mediachase.BusinessFoundation.Data.Meta.Management;
using Mediachase.Commerce;
using Mediachase.Commerce.Catalog;
using Mediachase.Commerce.Catalog.Objects;
using Mediachase.Commerce.Core;
using Mediachase.Commerce.Customers;
using Mediachase.Commerce.Orders;
using Mediachase.Commerce.Pricing;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EPiServer.Reference.Commerce.Site
{
    public class TestController : Controller
    {
        // Problems with using default JSON.NET (seems to be related to ScriptIgnoreAttribute)
        private static readonly JavaScriptSerializer Serializer = new JavaScriptSerializer();

        public ActionResult Index()
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            var model = new Organization();

            string orgId = string.Empty;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(IntegrationUrl);

                Authenticate(client);
                PostOrganization(model, client);
                //DeleteOrganization(orgId, client);
            }

            return HttpNotFound();
        }

        public ActionResult Index2()
        {
            var contentLoader = ServiceLocator.Current.GetInstance<IContentLoader>();
            var referenceConverter = ServiceLocator.Current.GetInstance<ReferenceConverter>();

            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            //int orderGroupId = 12345;
            var contactId = Guid.Parse("2A40754D-86D5-460B-A5A4-32BC87703567"); // admin contact
            string cartName = Cart.DefaultName;
            var entryCode = "SKU-35278811";

            var entry = CatalogContext.Current.GetCatalogEntry(entryCode);

            var model = new Cart(cartName, contactId);
            {
            };

            model.OrderForms.AddNew();

            var orderForm = model.OrderForms.First();
            orderForm.LineItems.Add(new LineItem
            {
                Quantity = 1,
                ExtendedPrice = 10,
                InventoryStatus = 1,
                Code = entryCode,
                ListPrice = 10,
                DisplayName = "SKU-35278811 test"
            });


            // orderaddress
            model.OrderAddresses.AddNew();

            // shipment
            orderForm.Shipments.Add(new Shipment
            {
                ShippingMethodId = Guid.Parse("BBF8FE44-9EB2-40A8-B69C-709A1A27ED5C"),
                ShippingMethodName = "Fast-USD",
                ShippingAddressId = "fake address",
                WarehouseCode = "default"
            });

            var json = JsonConvert.SerializeObject(model);
            var json2 = JsonConvert.SerializeObject(orderForm);

            var serializer = new JavaScriptSerializer();
            //var json3 = serializer.Serialize(model); // result in circular reference exception

            // orderforms with payment

            // promotions

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(IntegrationUrl);

                Authenticate(client);
                Post(model, client);
                //Delete(orderGroupId, client);
            }

            return HttpNotFound();
        }

        //private void Test()
        //{
        //    string _rewardDescription = "A description says it all.";
        //    string _json;
        //    Cart _cart;

        //    _cart = CreateContentAndAddToCart<ComplexVariationContent>(
        //        modifyModel: content =>
        //        {
        //            content.Code = "My variant test 1";
        //            content.DisplayName = content.Name = "My variant test 1";
        //        },
        //        prices: new[]
        //        {
        //            new Money(45m, Currency.USD)
        //        },
        //        inventoryRecords: new[]
        //        {
        //            DefaultObjects.CreateInventory("My variant test 1", 100)
        //        },
        //        modifyLineItem: null,
        //        modifyCart: cart =>
        //        {
        //            cart.OrderAddresses.Add(DefaultObjects.CreateOrderAddress());
        //            cart.OrderForms.First().Payments.Add(CreatePayment<OtherPayment>("fake address", _payByPhone.PaymentMethodId, _payByPhone.Name, 45m));
        //            var shipment = cart.OrderForms.First().Shipments.First();
        //            shipment.ShippingMethodId = _onlineDownload.ShippingMethodId;
        //            shipment.ShippingMethodName = _onlineDownload.Name;
        //            shipment.ShippingAddressId = "fake address";

        //            ((IOrderGroup)cart).Forms.First().Promotions.Add(new PromotionInformation
        //            {
        //                PromotionInformationId = 98,
        //                Description = _rewardDescription,
        //                SavedAmount = 10.5m,
        //                DiscountType = DiscountType.LineItem,
        //                RewardType = RewardType.Percentage,
        //                ContentLink = new ContentReference(42),
        //                PromotionLink = new ContentReference(85)
        //            });
        //        });
        //}

        private static void Post(Cart model, HttpClient client)
        {
            // Problems with using JavaScript Serializer circular reference exception. Works with JSON.NET
            var serializer = new JavaScriptSerializer();
            //var json = serializer.Serialize(model);

            var json = JsonConvert.SerializeObject(model);

            var response = client.PostAsync($"/episerverapi/commerce/order", new StringContent(json, Encoding.UTF8, "application/json")).Result;

            string message = response.Content.ReadAsStringAsync().Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Post failed! Status: {response.StatusCode}. Message: {message}");
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

        readonly string _username = "admin";
        readonly string _password = "store";

        protected string IntegrationUrl = "https://serviceapi.localtest.me";

        protected virtual void Authenticate(HttpClient client)
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