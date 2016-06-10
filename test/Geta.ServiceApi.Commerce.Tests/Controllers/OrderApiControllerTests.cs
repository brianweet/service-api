﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Xml.Linq;
using Geta.ServiceApi.Commerce.Tests.Base;
using Mediachase.Commerce;
using Mediachase.Commerce.Orders;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OrderGroup = Geta.ServiceApi.Commerce.Models.OrderGroup;
using Xunit;

namespace Geta.ServiceApi.Commerce.Tests.Controllers
{
    public sealed class OrderApiControllerTests : ApiTestsBase, IDisposable
    {
        [Fact]
        public void get_returns_order()
        {
            var orderId = 121121; // not valid order id
            var customerId = Guid.NewGuid();

            GetNotFound(orderId);
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

            var order = Post(model);
            Delete((int)order.OrderGroupId);
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

            var order = Post(model);

            Search(OrderShipmentStatus.Packing, Guid.NewGuid());
            Search(OrderShipmentStatus.AwaitingInventory, null);
            Search(null, Guid.NewGuid());
            Search(null, null);

            Delete((int)order.OrderGroupId);
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

            var newOrder = Post(postModel);
            int orderGroupId = newOrder.OrderGroupId;
            var order = Get(orderGroupId);
            var orderGroup = ToOrderGroup(order);
            var expectedStatus = "New status";

            orderGroup.Status = expectedStatus;
            Put(orderGroupId, orderGroup);

            var savedOrder = Get(orderGroupId);

            Delete(orderGroupId);

            Assert.Equal(expectedStatus, savedOrder.Status.ToString());
        }

        [Fact]
        public void it_searches_since_modified_date()
        {
            var contactId = Guid.Parse("2A40754D-86D5-460B-A5A4-32BC87703567"); // admin contact
            var cartName = Cart.DefaultName;

            var postModel = new OrderGroup
            {
                CustomerId = contactId,
                Name = cartName
            };

            var newOrder = Post(postModel);
            int orderGroupId = newOrder.OrderGroupId;

            var updatedSince = DateTime.UtcNow.AddMinutes(-1);
            var orders = Search(updatedSince);

            Delete(orderGroupId);

            Assert.True(orders.Any(x => (DateTime) x["Modified"] >= updatedSince));
            Assert.False(orders.Any(x => (DateTime) x["Modified"] < updatedSince));
        }

        [Fact]
        public void it_searches_by_statuses()
        {
            var contactId = Guid.Parse("2A40754D-86D5-460B-A5A4-32BC87703567"); // admin contact
            var cartName = Cart.DefaultName;

            var statuses = new[] {"InProgress", "Completed", "OnHold", "PartiallyShipped"};
            var orderIds = new List<int>();
            foreach (var status in statuses)
            {
                var postModel = new OrderGroup
                {
                    CustomerId = contactId,
                    Name = cartName,
                    Status = status
                };

                var newOrder = Post(postModel);
                orderIds.Add((int)newOrder.OrderGroupId);
            }

            var expectedStatuses = new[] {"InProgress", "OnHold"};
            var orders = Search(expectedStatuses);

            foreach (var orderId in orderIds)
            {
                Delete(orderId);
            }

            Assert.True(orders.All(x => expectedStatuses.Contains((string) x["Status"])));
        }

        [Fact]
        public void it_posts_and_searches_with_accept_xml()
        {
            var contactId = Guid.Parse("2A40754D-86D5-460B-A5A4-32BC87703567"); // admin contact
            var cartName = "default";

            var postModel = new OrderGroup
            {
                CustomerId = contactId,
                Name = cartName
            };

            var orderGroupId = PostXml(postModel);

            var xmlString = SearchXml();

            Delete(orderGroupId);

            Assert.True(IsXml(xmlString));
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
            var response = Client.GetAsync($"/episerverapi/commerce/order/{orderId}").Result;

            var message = response.Content.ReadAsStringAsync().Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Get failed! Status: {response.StatusCode}. Message: {message}");
            }

            return JObject.Parse(message);
        }

        private void GetNotFound(int orderId)
        {
            var response = Client.GetAsync($"/episerverapi/commerce/order/{orderId}").Result;

            var message = response.Content.ReadAsStringAsync().Result;

            if (response.StatusCode != HttpStatusCode.NotFound)
            {
                throw new Exception($"Get failed! Status: {response.StatusCode}. Message: {message}");
            }
        }

        private void Get(Guid customerId)
        {
            var response = Client.GetAsync($"/episerverapi/commerce/order/{customerId}/all").Result;

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
                    Client.GetAsync(
                        $"/episerverapi/commerce/order/0/100/search/?OrderShipmentStatus={orderShipmentStatus}&ShippingMethodId={shippingMethodId}")
                        .Result;
            }
            else if (orderShipmentStatus != null)
            {
                response =
                    Client.GetAsync(
                        $"/episerverapi/commerce/order/0/100/search/?OrderShipmentStatus={orderShipmentStatus}").Result;
            }
            else if (shippingMethodId != null)
            {
                response =
                    Client.GetAsync($"/episerverapi/commerce/order/0/100/search/?ShippingMethodId={shippingMethodId}")
                        .Result;
            }
            else
            {
                response = Client.GetAsync($"/episerverapi/commerce/order/0/100/search/").Result;
            }

            var message = response.Content.ReadAsStringAsync().Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Get failed! Status: {response.StatusCode}. Message: {message}");
            }
        }

        private string SearchXml()
        {
            AcceptXml();
            var response = Client.GetAsync($"/episerverapi/commerce/order/0/100/search").Result;
            RemoveAcceptXml();

            var message = response.Content.ReadAsStringAsync().Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Get failed! Status: {response.StatusCode}. Message: {message}");
            }

            return message;
        }

        private JArray Search(DateTime modifiedFrom)
        {
            var response = Client.GetAsync($"/episerverapi/commerce/order/0/100/search/?modifiedFrom={modifiedFrom}").Result;

            var message = response.Content.ReadAsStringAsync().Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Get failed! Status: {response.StatusCode}. Message: {message}");
            }

            return JArray.Parse(message);
        }

        private JArray Search(string[] statuses)
        {
            var statusParam = string.Join("&", statuses.Select(x => $"status={x}"));
            var response = Client.GetAsync($"/episerverapi/commerce/order/0/100/search/?{statusParam}").Result;

            var message = response.Content.ReadAsStringAsync().Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Get failed! Status: {response.StatusCode}. Message: {message}");
            }

            return JArray.Parse(message);
        }

        private int PostXml(OrderGroup model)
        {
            var xml = SerializeXml(model);

            AcceptXml();
            var response =
                Client.PostAsync($"/episerverapi/commerce/order",
                    new StringContent(xml, Encoding.Unicode, "application/xml")).Result;
            RemoveAcceptXml();

            var message = response.Content.ReadAsStringAsync().Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Post failed! Status: {response.StatusCode}. Message: {message}");
            }

            var document = XDocument.Parse(message);
            var str = document.Descendants(XName.Get("OrderGroupId")).First().Value;
            int orderGroupId;
            int.TryParse(str, out orderGroupId);

            return orderGroupId;
        }

        private dynamic Post(OrderGroup model)
        {
            var json = JsonConvert.SerializeObject(model);

            var response =
                Client.PostAsync($"/episerverapi/commerce/order",
                    new StringContent(json, Encoding.UTF8, "application/json")).Result;

            var message = response.Content.ReadAsStringAsync().Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Post failed! Status: {response.StatusCode}. Message: {message}");
            }

            return JObject.Parse(message);
        }

        private void Put(int orderId, OrderGroup model)
        {
            var json = JsonConvert.SerializeObject(model);

            var response =
                Client.PutAsync($"/episerverapi/commerce/order/{orderId}",
                    new StringContent(json, Encoding.UTF8, "application/json")).Result;

            var message = response.Content.ReadAsStringAsync().Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Post failed! Status: {response.StatusCode}. Message: {message}");
            }
        }

        private void Delete(int orderGroupId)
        {
            var response = Client.DeleteAsync($"/episerverapi/commerce/order/{orderGroupId}").Result;

            var message = response.Content.ReadAsStringAsync().Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Delete failed! Status: {response.StatusCode}. Message: {message}");
            }
        }
    }
}