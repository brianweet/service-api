using EPiServer.Commerce.Integration.Specs.TestModel;
using EPiServer.Commerce.TestTools.IntegrationTests;
using EPiServer.Core;
using Machine.Specifications;
using Mediachase.Commerce;
using Mediachase.Commerce.Marketing;
using Mediachase.Commerce.Orders;
using Mediachase.Commerce.Orders.Dto;
using Mediachase.Commerce.Orders.Managers;
using Newtonsoft.Json;
using System.Linq;

namespace EPiServer.Commerce.Integration.Specs.Mediachase.Commerce.Orders.Serialization
{
    class JsonSerialization_Specs 
    {
        protected static ShippingMethodDto.ShippingMethodRow _onlineDownload;
        protected static PaymentMethodDto.PaymentMethodRow _payByPhone;
        
        Establish context = () =>
        {
            _onlineDownload = ShippingManager.GetShippingMethods("en").ShippingMethod.FirstOrDefault(x => x.Name.Equals("Online Download"));
            _payByPhone = PaymentManager.GetPaymentMethods("en").PaymentMethod.FirstOrDefault(x => x.Name.Equals("Pay By Phone"));
        };

        class When_Serializing_Cart : IntegrationEcfTestBase
        {
            It Should_serialize_cart_without_error = () => _json.ShouldNotBeEmpty();

            static string _rewardDescription = "A description says it all.";
            static string _json;
            static Cart _cart;

            Establish context = () =>
            {
                _cart = CreateContentAndAddToCart<ComplexVariationContent>(
                modifyModel:content =>
                {
                    content.Code = "My variant test 1";
                    content.DisplayName = content.Name = "My variant test 1";
                },
                prices:new[] 
                {
                    new Money(45m, Currency.USD) 
                },
                inventoryRecords:new[] 
                {
                    DefaultObjects.CreateInventory("My variant test 1", 100)
                },
                modifyLineItem:null,
                modifyCart:cart =>
                {
                    cart.OrderAddresses.Add(DefaultObjects.CreateOrderAddress());
                    cart.OrderForms.First().Payments.Add(CreatePayment<OtherPayment>("fake address", _payByPhone.PaymentMethodId, _payByPhone.Name, 45m));
                    var shipment = cart.OrderForms.First().Shipments.First();
                    shipment.ShippingMethodId = _onlineDownload.ShippingMethodId;
                    shipment.ShippingMethodName = _onlineDownload.Name;
                    shipment.ShippingAddressId = "fake address";

                    ((IOrderGroup)cart).Forms.First().Promotions.Add(new PromotionInformation
                    {
                        PromotionInformationId = 98,
                        Description = _rewardDescription,
                        SavedAmount = 10.5m,
                        DiscountType = DiscountType.LineItem,
                        RewardType = RewardType.Percentage,
                        ContentLink = new ContentReference(42),
                        PromotionLink = new ContentReference(85)
                    });
                });
            };

            Because of = () => _json = JsonConvert.SerializeObject(_cart);

            It should_also_serialize_any_promotioninformation = () => _json.ShouldContain(_rewardDescription);
        }

        class When_Serializing_PurchaseOrder : IntegrationEcfTestBase
        {
            It Should_serialize_purchase_order_without_error = () => _json.ShouldNotBeEmpty();

            static string _rewardDescription = "A description says it all.";
            static string _json;
            static PurchaseOrder _purchaseOrder;

            Establish context = () =>
            {
                var myCart = CreateContentAndAddToCart<ComplexVariationContent>(
                modifyModel: content =>
                {
                    content.Code = "My variant test 1";
                    content.DisplayName = content.Name = "My variant test 1";
                },
                prices: new[] 
                {
                    new Money(45m, Currency.USD) 
                },
                inventoryRecords: new[] 
                {
                    DefaultObjects.CreateInventory("My variant test 1", 100)
                },
                modifyLineItem: null,
                modifyCart: cart =>
                {
                    cart.OrderAddresses.Add(DefaultObjects.CreateOrderAddress());
                    cart.OrderForms.First().Payments.Add(CreatePayment<OtherPayment>("fake address", _payByPhone.PaymentMethodId, _payByPhone.Name, 45m));
                    var shipment = cart.OrderForms.First().Shipments.First();
                    shipment.ShippingMethodId = _onlineDownload.ShippingMethodId;
                    shipment.ShippingMethodName = _onlineDownload.Name;
                    shipment.ShippingAddressId = "fake address";

                    ((IOrderGroup)cart).Forms.First().Promotions.Add(new PromotionInformation
                    {
                        PromotionInformationId = 98,
                        Description = _rewardDescription,
                        SavedAmount = 10.5m,
                        DiscountType = DiscountType.LineItem,
                        RewardType = RewardType.Percentage,
                        ContentLink = new ContentReference(42),
                        PromotionLink = new ContentReference(85)
                    });
                });
                _purchaseOrder = myCart.SaveAsPurchaseOrder();
            };

            Because of = () => _json = JsonConvert.SerializeObject(_purchaseOrder);

            It should_also_serialize_any_promotioninformation = () => _json.ShouldContain(_rewardDescription);

        }

        class When_Serializing_PaymentPlan : IntegrationEcfTestBase
        {
            It Should_serialize_payment_plan_without_error = () => _json.ShouldNotBeEmpty();

            static string _rewardDescription = "A description says it all.";
            static string _json;
            static PaymentPlan _paymentPlan;

            Establish context = () =>
            {
                var myCart = CreateContentAndAddToCart<ComplexVariationContent>(
                modifyModel: content =>
                {
                    content.Code = "My variant test 1";
                    content.DisplayName = content.Name = "My variant test 1";
                },
                prices: new[] 
                {
                    new Money(45m, Currency.USD) 
                },
                inventoryRecords: new[] 
                {
                    DefaultObjects.CreateInventory("My variant test 1", 100)
                },
                modifyLineItem: null,
                modifyCart: cart =>
                {
                    cart.OrderAddresses.Add(DefaultObjects.CreateOrderAddress());
                    cart.OrderForms.First().Payments.Add(CreatePayment<OtherPayment>("fake address", _payByPhone.PaymentMethodId, _payByPhone.Name, 45m));
                    var shipment = cart.OrderForms.First().Shipments.First();
                    shipment.ShippingMethodId = _onlineDownload.ShippingMethodId;
                    shipment.ShippingMethodName = _onlineDownload.Name;
                    shipment.ShippingAddressId = "fake address";

                    ((IOrderGroup)cart).Forms.First().Promotions.Add(new PromotionInformation
                    {
                        PromotionInformationId = 98,
                        Description = _rewardDescription,
                        SavedAmount = 10.5m,
                        DiscountType = DiscountType.LineItem,
                        RewardType = RewardType.Percentage,
                        ContentLink = new ContentReference(42),
                        PromotionLink = new ContentReference(85)
                    });
                });
                _paymentPlan = myCart.SaveAsPaymentPlan();
                _paymentPlan.CompletedCyclesCount = 0;
                _paymentPlan.CycleLength = 1;
                _paymentPlan.CycleMode = PaymentPlanCycle.Months;
                _paymentPlan.IsActive = true;
                _paymentPlan.MaxCyclesCount = 12;
                _paymentPlan.AcceptChanges();
            };

            Because of = () => _json = JsonConvert.SerializeObject(_paymentPlan);

            It should_also_serialize_any_promotioninformation = () => _json.ShouldContain(_rewardDescription);
        }
    }
}
