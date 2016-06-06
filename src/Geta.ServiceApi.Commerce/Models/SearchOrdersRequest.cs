using System;
using Mediachase.Commerce.Orders;

namespace Geta.ServiceApi.Commerce.Models
{
    public class SearchOrdersRequest
    {
        public OrderShipmentStatus? OrderShipmentStatus { get; set; }
        public Guid? ShippingMethodId { get; set; }
        public DateTime? ModifiedFrom { get; set; }
    }
}