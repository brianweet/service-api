using Mediachase.Commerce.Orders;

namespace Geta.ServiceApi.Commerce.Mappings
{
    internal static class OrderAddressMappings
    {
        public static OrderAddress ConvertToOrderAddress(
            this Models.OrderAddress orderAddressDto, OrderAddress orderAddress)
        {
            orderAddress.Name = orderAddressDto.Name;
            orderAddress.City = orderAddressDto.City;
            orderAddress.CountryCode = orderAddressDto.CountryCode;
            orderAddress.CountryName = orderAddressDto.CountryName;
            orderAddress.DaytimePhoneNumber = orderAddressDto.DaytimePhoneNumber;
            orderAddress.Email = orderAddressDto.Email;
            orderAddress.EveningPhoneNumber = orderAddressDto.EveningPhoneNumber;
            orderAddress.FaxNumber = orderAddressDto.FaxNumber;
            orderAddress.FirstName = orderAddressDto.FirstName;
            orderAddress.LastName = orderAddressDto.LastName;
            orderAddress.Line1 = orderAddressDto.Line1;
            orderAddress.Line2 = orderAddressDto.Line2;
            orderAddress.PostalCode = orderAddressDto.PostalCode;
            orderAddress.RegionName = orderAddressDto.RegionName;
            orderAddress.RegionCode = orderAddressDto.RegionCode;
            orderAddress.State = orderAddressDto.State;
            orderAddress.Organization = orderAddress.Organization;

            return orderAddress;
        }
    }
}