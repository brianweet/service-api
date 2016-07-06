﻿using System;
using Mediachase.Commerce;

namespace Geta.ServiceApi.Commerce.Models
{
    /// <summary>
    /// Order group model.
    /// </summary>
    [Serializable]
    public class OrderGroup
    {
        /// <summary>
        /// Initializes new instance of the OrderGroup class.
        /// </summary>
        public OrderGroup()
        {
            OrderAddresses = new OrderAddress[0];
            OrderForms = new OrderForm[0];
            OrderNotes = new OrderNote[0];
        }

        /// <summary>
        /// Address ID.
        /// </summary>
        public string AddressId { get; set; }

        /// <summary>
        /// Affiliate ID (GUID)
        /// </summary>
        public Guid AffiliateId { get; set; }

        /// <summary>
        /// Billing currency.
        /// </summary>
        public string BillingCurrency { get; set; }

        /// <summary>
        /// Customer ID (GUID).
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Customer name.
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// Handling total.
        /// </summary>
        public decimal HandlingTotal { get; set; }

        /// <summary>
        /// Instance ID (GUID).
        /// </summary>
        public Guid InstanceId { get; set; }

        /// <summary>
        /// Market ID.
        /// </summary>
        public MarketId MarketId { get; set; }

        /// <summary>
        /// Order name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Array of addresses.
        /// </summary>
        public OrderAddress[] OrderAddresses { get; set; }

        /// <summary>
        /// Array of order forms.
        /// </summary>
        public OrderForm[] OrderForms { get; set; }

        /// <summary>
        /// Order group ID.
        /// </summary>
        public int OrderGroupId { get; set; }

        /// <summary>
        /// Array of order notes.
        /// </summary>
        public OrderNote[] OrderNotes { get; set; }

        /// <summary>
        /// Owner name.
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// Owner's organization name.
        /// </summary>
        public string OwnerOrg { get; set; }

        /// <summary>
        /// Provider ID.
        /// </summary>
        public string ProviderId { get; set; }

        /// <summary>
        /// Shipping total.
        /// </summary>
        public decimal ShippingTotal { get; set; }

        /// <summary>
        /// Status.
        /// Valid values:
        /// - AwaitingExchange
        /// - Cancelled
        /// - Completed
        /// - InProgress
        /// - OnHold
        /// - PartiallyShipped
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Sub-total.
        /// </summary>
        public decimal SubTotal { get; set; }

        /// <summary>
        /// Tax total.
        /// </summary>
        public decimal TaxTotal { get; set; }

        /// <summary>
        /// Total.
        /// </summary>
        public decimal Total { get; set; }
    }
}