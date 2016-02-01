using System;
using EPiServer.Commerce.Integration.Specs.TestModel;
using EPiServer.Commerce.TestTools.IntegrationTests;
using Machine.Specifications;
using Mediachase.Commerce;
using Mediachase.Commerce.Orders;
using System.IO;
using System.Xml.Serialization;
using System.Linq;

namespace EPiServer.Commerce.Integration.Specs.Mediachase.Commerce.Orders.Serialization
{
    class XmlDeserialization_Specs
    {
        class When_Deserializing_Cart_Xml : IntegrationEcfTestBase
        {
            It Should_deserialize_cart_without_error = () => _cart.ShouldNotBeNull();
            It should_deserialize_promotion_information = () => ((IOrderGroup)_cart).Forms.First().Promotions.Count.ShouldEqual(1);

            static Cart _cart;

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
                using (var streamReader = new StreamReader(Path.Combine(TestDataDirectory, "TestCart.xml")))
                {
                    var serialzer = new XmlSerializer(typeof(Cart));
                    _cart = (Cart)serialzer.Deserialize(streamReader);
                    OrderRepository.Save(_cart);
                }
            };
        }

        class When_Deserializing_Purchase_Order_Xml : IntegrationEcfTestBase
        {
            It Should_deserialize_purchase_order_without_error = () => _purchaseOrder.ShouldNotBeNull();
            It should_deserialize_promotion_information = () => ((IOrderGroup)_purchaseOrder).Forms.First().Promotions.Count.ShouldEqual(1);
            It Should_deserialize_order_notes_properly = () => _purchaseOrder.OrderNotes.Count.ShouldEqual(6);

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
                using (var streamReader = new StreamReader(Path.Combine(TestDataDirectory, "TestPurchaseOrder.xml")))
                {
                    var serialzer = new XmlSerializer(typeof(PurchaseOrder));
                    _purchaseOrder = (PurchaseOrder)serialzer.Deserialize(streamReader);
                    OrderRepository.Save(_purchaseOrder);
                }
            };
        }

        class When_Deserializing_Payment_Plan_Xml : IntegrationEcfTestBase
        {
            It Should_deserialize_payment_plan_without_error = () => _paymentPlan.ShouldNotBeNull();
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
                using (var streamReader = new StreamReader(Path.Combine(TestDataDirectory, "TestPaymentPlan.xml")))
                {
                    var serialzer = new XmlSerializer(typeof(PaymentPlan));
                    _paymentPlan = (PaymentPlan)serialzer.Deserialize(streamReader);
                    OrderRepository.Save(_paymentPlan);
                }
            };
        }
    }
}
