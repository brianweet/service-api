using EPiServer.Commerce.Integration.Specs.TestModel;
using EPiServer.Commerce.TestTools.IntegrationTests;
using Machine.Specifications;
using Mediachase.Commerce;
using Mediachase.Commerce.Core.Features;
using Mediachase.Commerce.Orders;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;

namespace EPiServer.Commerce.Integration.Specs.Mediachase.Commerce.Orders.Serialization
{
    class JsonDeserialization_Specs
    {
        class When_Deserializing_Cart_Json : IntegrationEcfTestBase
        {
            It Should_serialize_cart_without_error = () => _cart.ShouldNotBeNull();
            It should_deserialize_promotion_information = () => ((IOrderGroup)_cart).Forms.First().Promotions.Count.ShouldEqual(1);

            static Cart _cart;

            Establish context = () =>
            {
                SetVNextFeature(true);
                CreateContentWithPriceAndInventory<ComplexVariationContent>(modifyModel: content =>
                {
                    content.Code = "My variant test 1";
                    content.DisplayName = content.Name = "My variant test 1";
                },
                prices: new[] 
                {
                    new Money(45m, Currency.USD) 
                },
                inventoryRecords: new[] { DefaultObjects.CreateInventory("My variant test 1", 100) });
            };

            Because of = () =>
            {
                var streamReader = new StreamReader(Path.Combine(TestDataDirectory, "TestCart.json"));
                _cart = JsonConvert.DeserializeObject<Cart>(streamReader.ReadToEnd());
                streamReader.Close();
                OrderRepository.Save(_cart);
            };

            Cleanup cleanup = () => SetVNextFeature(false);
        }

        class When_Deserializing_Purchase_Order_Json : IntegrationEcfTestBase
        {
            It Should_serialize_purchase_order_without_error = () => _purchaseOrder.ShouldNotBeNull();
            It should_deserialize_promotion_information = () => ((IOrderGroup)_purchaseOrder).Forms.First().Promotions.Count.ShouldEqual(1);

            static PurchaseOrder _purchaseOrder;

            Establish context = () => CreateContentWithPriceAndInventory<ComplexVariationContent>(modifyModel: content =>
            {
                content.Code = "My variant test 1";
                content.DisplayName = content.Name = "My variant test 1";
            },
            prices: new[] 
            {
                new Money(45m, Currency.USD) 
            },
            inventoryRecords: new[] { DefaultObjects.CreateInventory("My variant test 1", 100) });

            Because of = () =>
            {
                var streamReader = new StreamReader(Path.Combine(TestDataDirectory, "TestPurchaseOrder.json"));
                _purchaseOrder = JsonConvert.DeserializeObject<PurchaseOrder>(streamReader.ReadToEnd());
                streamReader.Close();
                OrderRepository.Save(_purchaseOrder);
            };
        }

        class When_Deserializing_Payment_Plan_Json : IntegrationEcfTestBase
        {
            It Should_serialize_payment_plan_without_error = () => _paymentPlan.ShouldNotBeNull();
            It should_deserialize_promotion_information = () => ((IOrderGroup)_paymentPlan).Forms.First().Promotions.Count.ShouldEqual(1);

            static PaymentPlan _paymentPlan;

            Establish context = () => CreateContentWithPriceAndInventory<ComplexVariationContent>(modifyModel: content =>
            {
                content.Code = "My variant test 1";
                content.DisplayName = content.Name = "My variant test 1";
            },
            prices: new[] 
            {
                new Money(45m, Currency.USD) 
            },
            inventoryRecords: new[] { DefaultObjects.CreateInventory("My variant test 1", 100) });

            Because of = () =>
            {
                var streamReader = new StreamReader(Path.Combine(TestDataDirectory, "TestPaymentPlan.json"));
                _paymentPlan = JsonConvert.DeserializeObject<PaymentPlan>(streamReader.ReadToEnd());
                streamReader.Close();
                OrderRepository.Save(_paymentPlan);
            };
        }
    }
}
