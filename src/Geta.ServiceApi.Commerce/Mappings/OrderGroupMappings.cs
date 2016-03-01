using System;
using Mediachase.Commerce.Orders;
using OrderGroup = Geta.ServiceApi.Commerce.Models.OrderGroup;

namespace Geta.ServiceApi.Commerce.Mappings
{
    public static class OrderGroupMappings
    {
        public static Cart ConvertToCart(this OrderGroup orderGroup, Cart cart)
        {
            if (!string.IsNullOrEmpty(orderGroup.AddressId))
            {
                cart.AddressId = orderGroup.AddressId;
            }

            if (orderGroup.AffiliateId != Guid.Empty)
            {
                cart.AffiliateId = orderGroup.AffiliateId;
            }

            if (!string.IsNullOrEmpty(orderGroup.BillingCurrency))
            {
                cart.BillingCurrency = orderGroup.BillingCurrency;
            }

            if (!string.IsNullOrEmpty(orderGroup.CustomerName))
            {
                cart.CustomerName = orderGroup.CustomerName;
            }

            if (orderGroup.HandlingTotal >= 0)
            {
                cart.HandlingTotal = orderGroup.HandlingTotal;
            }

            if (orderGroup.InstanceId != Guid.Empty)
            {
                cart.InstanceId = orderGroup.InstanceId;
            }

            if (orderGroup.MarketId != null)
            {
                cart.MarketId = orderGroup.MarketId;
            }

            //public IList<PromotionInformation> Promotions { get; set; }

            //public OrderAddressCollection OrderAddresses { get; set; }

            //public OrderFormCollection OrderForms { get; set; }

            //public int OrderGroupId { get; set; }

            if (orderGroup.OrderNotes != null)
            {
                cart.OrderNotes = orderGroup.OrderNotes;
            }

            if (!string.IsNullOrEmpty(orderGroup.Owner))
            {
                cart.Owner = orderGroup.Owner;
            }

            if (!string.IsNullOrEmpty(orderGroup.OwnerOrg))
            {
                cart.OwnerOrg = orderGroup.OwnerOrg;
            }

            if (!string.IsNullOrEmpty(orderGroup.ProviderId))
            {
                cart.ProviderId = orderGroup.ProviderId;
            }

            if (orderGroup.ShippingTotal >= 0)
            {
                cart.ShippingTotal = orderGroup.ShippingTotal;
            }

            if (!string.IsNullOrEmpty(orderGroup.Status))
            {
                cart.Status = orderGroup.Status;
            }

            if (orderGroup.SubTotal >= 0)
            {
                cart.SubTotal = orderGroup.SubTotal;
            }

            if (orderGroup.TaxTotal >= 0)
            {
                cart.TaxTotal = orderGroup.TaxTotal;
            }

            if (orderGroup.Total >= 0)
            {
                cart.Total = orderGroup.Total;
            }

            return cart;
        }

        public static PaymentPlan ConvertToPaymentPlan(this OrderGroup orderGroup, PaymentPlan paymentPlan)
        {
            if (!string.IsNullOrEmpty(orderGroup.AddressId))
            {
                paymentPlan.AddressId = orderGroup.AddressId;
            }

            if (orderGroup.AffiliateId != Guid.Empty)
            {
                paymentPlan.AffiliateId = orderGroup.AffiliateId;
            }

            if (!string.IsNullOrEmpty(orderGroup.BillingCurrency))
            {
                paymentPlan.BillingCurrency = orderGroup.BillingCurrency;
            }

            if (!string.IsNullOrEmpty(orderGroup.CustomerName))
            {
                paymentPlan.CustomerName = orderGroup.CustomerName;
            }

            if (orderGroup.HandlingTotal >= 0)
            {
                paymentPlan.HandlingTotal = orderGroup.HandlingTotal;
            }

            if (orderGroup.InstanceId != Guid.Empty)
            {
                paymentPlan.InstanceId = orderGroup.InstanceId;
            }

            if (orderGroup.MarketId != null)
            {
                paymentPlan.MarketId = orderGroup.MarketId;
            }

            //public IList<PromotionInformation> Promotions { get; set; }

            //public OrderAddressCollection OrderAddresses { get; set; }

            //public OrderFormCollection OrderForms { get; set; }

            //public int OrderGroupId { get; set; }

            if (orderGroup.OrderNotes != null)
            {
                paymentPlan.OrderNotes = orderGroup.OrderNotes;
            }

            if (!string.IsNullOrEmpty(orderGroup.Owner))
            {
                paymentPlan.Owner = orderGroup.Owner;
            }

            if (!string.IsNullOrEmpty(orderGroup.OwnerOrg))
            {
                paymentPlan.OwnerOrg = orderGroup.OwnerOrg;
            }

            if (!string.IsNullOrEmpty(orderGroup.ProviderId))
            {
                paymentPlan.ProviderId = orderGroup.ProviderId;
            }

            if (orderGroup.ShippingTotal >= 0)
            {
                paymentPlan.ShippingTotal = orderGroup.ShippingTotal;
            }

            if (!string.IsNullOrEmpty(orderGroup.Status))
            {
                paymentPlan.Status = orderGroup.Status;
            }

            if (orderGroup.SubTotal >= 0)
            {
                paymentPlan.SubTotal = orderGroup.SubTotal;
            }

            if (orderGroup.TaxTotal >= 0)
            {
                paymentPlan.TaxTotal = orderGroup.TaxTotal;
            }

            if (orderGroup.Total >= 0)
            {
                paymentPlan.Total = orderGroup.Total;
            }

            return paymentPlan;
        }

        public static PurchaseOrder ConvertToPurchaseOrder(this OrderGroup orderGroup, PurchaseOrder purchaseOrder)
        {
            if (!string.IsNullOrEmpty(orderGroup.AddressId))
            {
                purchaseOrder.AddressId = orderGroup.AddressId;
            }

            if (orderGroup.AffiliateId != Guid.Empty)
            {
                purchaseOrder.AffiliateId = orderGroup.AffiliateId;
            }

            if (!string.IsNullOrEmpty(orderGroup.BillingCurrency))
            {
                purchaseOrder.BillingCurrency = orderGroup.BillingCurrency;
            }

            if (!string.IsNullOrEmpty(orderGroup.CustomerName))
            {
                purchaseOrder.CustomerName = orderGroup.CustomerName;
            }

            if (orderGroup.HandlingTotal >= 0)
            {
                purchaseOrder.HandlingTotal = orderGroup.HandlingTotal;
            }

            if (orderGroup.InstanceId != Guid.Empty)
            {
                purchaseOrder.InstanceId = orderGroup.InstanceId;
            }

            if (orderGroup.MarketId != null)
            {
                purchaseOrder.MarketId = orderGroup.MarketId;
            }

            //public IList<PromotionInformation> Promotions { get; set; }

            //public OrderAddressCollection OrderAddresses { get; set; }

            //public OrderFormCollection OrderForms { get; set; }

            //public int OrderGroupId { get; set; }

            if (orderGroup.OrderNotes != null)
            {
                purchaseOrder.OrderNotes = orderGroup.OrderNotes;
            }

            if (!string.IsNullOrEmpty(orderGroup.Owner))
            {
                purchaseOrder.Owner = orderGroup.Owner;
            }

            if (!string.IsNullOrEmpty(orderGroup.OwnerOrg))
            {
                purchaseOrder.OwnerOrg = orderGroup.OwnerOrg;
            }

            if (!string.IsNullOrEmpty(orderGroup.ProviderId))
            {
                purchaseOrder.ProviderId = orderGroup.ProviderId;
            }

            if (orderGroup.ShippingTotal >= 0)
            {
                purchaseOrder.ShippingTotal = orderGroup.ShippingTotal;
            }

            if (!string.IsNullOrEmpty(orderGroup.Status))
            {
                purchaseOrder.Status = orderGroup.Status;
            }

            if (orderGroup.SubTotal >= 0)
            {
                purchaseOrder.SubTotal = orderGroup.SubTotal;
            }

            if (orderGroup.TaxTotal >= 0)
            {
                purchaseOrder.TaxTotal = orderGroup.TaxTotal;
            }

            if (orderGroup.Total >= 0)
            {
                purchaseOrder.Total = orderGroup.Total;
            }

            return purchaseOrder;
        }
    }
}