using System;
using Mediachase.Commerce;
using Mediachase.Commerce.Marketing;
using Mediachase.Commerce.Orders;

namespace Geta.ServiceApi.Commerce.Models
{
    [Serializable]
    public class OrderGroup
    {
        public string AddressId { get; set; }

        public Guid AffiliateId { get; set; }

        public string BillingCurrency { get; set; }

        public Guid CustomerId { get; set; }

        public string CustomerName { get; set; }

        public decimal HandlingTotal { get; set; }

        public Guid InstanceId { get; set; }

        public MarketId MarketId { get; set; }

        public PromotionInformation[] Promotions { get; set; }

        public string Name { get; set; }

        public OrderAddressCollection OrderAddresses { get; set; }

        public OrderFormCollection OrderForms { get; set; }

        public int OrderGroupId { get; set; }

        public OrderNoteCollection OrderNotes { get; set; }

        public string Owner { get; set; }

        public string OwnerOrg { get; set; }

        public string ProviderId { get; set; }

        public decimal ShippingTotal { get; set; }

        public string Status { get; set; }

        public decimal SubTotal { get; set; }

        public decimal TaxTotal { get; set; }

        public decimal Total { get; set; }
    }
}