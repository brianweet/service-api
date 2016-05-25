using System;
using System.Net;
using System.Net.Http;
using System.Text;
using Mediachase.Commerce;
using Mediachase.Commerce.Orders;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OrderGroup = Geta.ServiceApi.Commerce.Models.OrderGroup;
using Xunit;

namespace Geta.ServiceApi.Commerce.Tests.Controllers
{
    public sealed class OrderApiControllerTests : ApiControllerBase, IDisposable
    {
        private readonly HttpClient _client;

        public OrderApiControllerTests()
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            _client = new HttpClient {BaseAddress = new Uri(IntegrationUrl)};
            Authenticate(_client);
        }

        public void Dispose()
        {
            _client.Dispose();
        }

        [Fact]
        public void get_returns_order()
        {
            var orderId = 121121; // not valid order id
            var customerId = Guid.NewGuid();

            Get(orderId);
            Get(customerId);
        }

        [Fact]
        public void post_creates_new_order()
        {
            var contactId = Guid.Parse("2A40754D-86D5-460B-A5A4-32BC87703567"); // admin contact
            var cartName = Cart.DefaultName;

            var model = new OrderGroup
            {
                CustomerId = contactId,
                Name = cartName
            };

            // Add address info
            // Add LineItems

            var orderReference = Post(model);
            Delete(orderReference.OrderGroupId);
        }

        [Fact]
        public void post_creates_new_order_and_searches_it()
        {
            var contactId = Guid.Parse("2A40754D-86D5-460B-A5A4-32BC87703567"); // admin contact
            var cartName = Cart.DefaultName;

            var model = new OrderGroup
            {
                CustomerId = contactId,
                Name = cartName
            };

            var orderReference = Post(model);

            Search(OrderShipmentStatus.Packing, Guid.NewGuid());
            Search(OrderShipmentStatus.AwaitingInventory, null);
            Search(null, Guid.NewGuid());
            Search(null, null);

            Delete(orderReference.OrderGroupId);
        }

        [Fact]
        public void it_updates_order_status()
        {
            var contactId = Guid.Parse("2A40754D-86D5-460B-A5A4-32BC87703567"); // admin contact
            var cartName = Cart.DefaultName;

            var postModel = new OrderGroup
            {
                CustomerId = contactId,
                Name = cartName
            };

            var orderReference = Post(postModel);
            var order = Get(orderReference.OrderGroupId);
            var orderGroup = ToOrderGroup(order);
            var expectedStatus = "New status";

            orderGroup.Status = expectedStatus;
            Put(orderReference.OrderGroupId, orderGroup);

            var savedOrder = Get(orderReference.OrderGroupId);

            Delete(orderReference.OrderGroupId);

            Assert.Equal(expectedStatus, savedOrder.Status.ToString());
        }

        private OrderGroup ToOrderGroup(dynamic order)
        {
            Func<object, Guid> toGuid = x =>
            {
                Guid g;
                if (Guid.TryParse(x.ToString(), out g))
                {
                    return g;
                }
                return Guid.Empty;
            };

            return new OrderGroup
            {
                AddressId = order.AddressId,
                AffiliateId = toGuid(order.AffiliateId),
                BillingCurrency = order.BillingCurrency,
                CustomerId = toGuid(order.CustomerId),
                CustomerName = order.CustomerName,
                HandlingTotal = order.HandlingTotal,
                InstanceId = toGuid(order.InstanceId),
                MarketId = new MarketId(order.MarketId.ToString()),
                Name = order.Name,
                OrderGroupId = order.OrderGroupId,
                Owner = order.Owner,
                OwnerOrg = order.OwnerOrg,
                ProviderId = order.ProviderId,
                ShippingTotal = order.ShippingTotal,
                Status = order.Status,
                SubTotal = order.SubTotal,
                TaxTotal = order.TaxTotal,
                Total = order.Total
            };
        }

        private dynamic Get(int orderId)
        {
            var response = _client.GetAsync($"/episerverapi/commerce/order/{orderId}").Result;

            var message = response.Content.ReadAsStringAsync().Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Get failed! Status: {response.StatusCode}. Message: {message}");
            }

            return JObject.Parse(message);
        }

        private void Get(Guid customerId)
        {
            var response = _client.GetAsync($"/episerverapi/commerce/order/{customerId}/all").Result;

            var message = response.Content.ReadAsStringAsync().Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Get failed! Status: {response.StatusCode}. Message: {message}");
            }
        }

        private void Search(OrderShipmentStatus? orderShipmentStatus, Guid? shippingMethodId)
        {
            HttpResponseMessage response;
            if (orderShipmentStatus != null && shippingMethodId != null)
            {
                response =
                    _client.GetAsync(
                        $"/episerverapi/commerce/order/0/100/search/?OrderShipmentStatus={orderShipmentStatus}&ShippingMethodId={shippingMethodId}")
                        .Result;
            }
            else if (orderShipmentStatus != null)
            {
                response =
                    _client.GetAsync(
                        $"/episerverapi/commerce/order/0/100/search/?OrderShipmentStatus={orderShipmentStatus}").Result;
            }
            else if (shippingMethodId != null)
            {
                response =
                    _client.GetAsync($"/episerverapi/commerce/order/0/100/search/?ShippingMethodId={shippingMethodId}")
                        .Result;
            }
            else
            {
                response = _client.GetAsync($"/episerverapi/commerce/order/0/100/search/").Result;
            }

            var message = response.Content.ReadAsStringAsync().Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Get failed! Status: {response.StatusCode}. Message: {message}");
            }
        }

        private OrderReference Post(OrderGroup model)
        {
            var json = JsonConvert.SerializeObject(model);

            var response =
                _client.PostAsync($"/episerverapi/commerce/order/isPaymentPlan=false",
                    new StringContent(json, Encoding.UTF8, "application/json")).Result;

            var message = response.Content.ReadAsStringAsync().Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Post failed! Status: {response.StatusCode}. Message: {message}");
            }

            return JsonConvert.DeserializeObject<OrderReference>(message);
        }

        private void Put(int orderId, OrderGroup model)
        {
            var json = JsonConvert.SerializeObject(model);

            var response =
                _client.PutAsync($"/episerverapi/commerce/order/{orderId}",
                    new StringContent(json, Encoding.UTF8, "application/json")).Result;

            var message = response.Content.ReadAsStringAsync().Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Post failed! Status: {response.StatusCode}. Message: {message}");
            }
        }

        private void Delete(int orderGroupId)
        {
            var response = _client.DeleteAsync($"/episerverapi/commerce/order/{orderGroupId}").Result;

            var message = response.Content.ReadAsStringAsync().Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Delete failed! Status: {response.StatusCode}. Message: {message}");
            }
        }
    }
}