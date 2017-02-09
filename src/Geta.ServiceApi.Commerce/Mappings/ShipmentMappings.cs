using System.Linq;
using EPiServer.Commerce.Order;
using Mediachase.Commerce.Orders;

namespace Geta.ServiceApi.Commerce.Mappings
{
    internal static class ShipmentMappings
    {
        public static void ConvertToShipment(this Models.Shipment shipmentDto, Shipment shipment, OrderForm orderForm)
        {
            shipment.Status = shipmentDto.Status;
            shipment.ShippingMethodId = shipmentDto.ShippingMethodId;
            shipment.SubTotal = shipmentDto.SubTotal;
            shipment.ShippingTax = shipmentDto.ShippingTax;
            shipment.ShippingDiscountAmount = shipmentDto.ShippingDiscountAmount;
            shipment.ShipmentTrackingNumber = shipmentDto.ShipmentTrackingNumber;
            shipment.WarehouseCode = shipmentDto.WarehouseCode;
            shipment.ShippingAddressId = shipmentDto.ShippingAddressId;
            shipment.ShippingMethodName = shipmentDto.ShippingMethodName;
            shipment.PrevStatus = shipmentDto.PrevStatus;
            shipment.PickListId = shipmentDto.PickListId;

            shipmentDto.MapPropertiesToModel(shipment);
            MapLineItems(shipmentDto, shipment, orderForm);
        }

        private static void MapLineItems(Models.Shipment shipmentDto, Shipment shipment, OrderForm orderForm)
        {
            shipment.LineItems.Clear();
            foreach (var lineItemDto in shipmentDto.LineItems)
            {
                var lineItem = orderForm.LineItems.FirstOrDefault(x => x.Code == lineItemDto.Code);
                if (lineItem == null) continue;
                lineItemDto.ConvertToLineItem(lineItem);
                shipment.LineItems.Add(lineItem);
            }
        }

        private static void ConvertToLineItem(this Models.LineItem lineItemDto, ILineItem lineItem)
        {
            var li = lineItem;
            li.DisplayName = lineItemDto.DisplayName;
            li.PlacedPrice = lineItemDto.PlacedPrice;
            li.Quantity = lineItemDto.Quantity;
            li.ReturnQuantity = lineItemDto.ReturnQuantity;
            li.InventoryTrackingStatus = lineItemDto.InventoryTrackingStatus;
            li.IsInventoryAllocated = lineItemDto.IsInventoryAllocated;
            li.IsGift = lineItemDto.IsGift;
        }
    }
}