using System.Collections.Generic;
using System.Linq;
using Geta.ServiceApi.Commerce.Models;
using Mediachase.Commerce.Customers;
using Mediachase.Commerce.Orders.Dto;
using Mediachase.Commerce.Orders.Managers;

namespace Geta.ServiceApi.Commerce.Extensions
{
    public static class AddressExtensions
    {
        public static CustomerAddress ConvertToCustomerAddress(this Address address, CustomerAddress customerAddress)
        {
            customerAddress.Name = address.Name;
            customerAddress.City = address.City;
            customerAddress.CountryCode = address.CountryCode;
            customerAddress.CountryName = GetAllCountries().Where(x => x.Code == address.CountryCode).Select(x => x.Name).FirstOrDefault();
            customerAddress.FirstName = address.FirstName;
            customerAddress.LastName = address.LastName;
            customerAddress.Line1 = address.Line1;
            customerAddress.Line2 = address.Line2;
            customerAddress.DaytimePhoneNumber = address.DaytimePhoneNumber;
            customerAddress.EveningPhoneNumber = address.EveningPhoneNumber;
            customerAddress.PostalCode = address.PostalCode;
            customerAddress.RegionName = address.Region;
            // Commerce Manager expects State to be set for addresses in order management. Set it to be same as
            // RegionName to avoid issues.
            customerAddress.State = address.Region;
            customerAddress.Email = address.Email;
            customerAddress.AddressType = CustomerAddressTypeEnum.Public | (address.ShippingDefault ? CustomerAddressTypeEnum.Shipping : 0) | (address.BillingDefault ? CustomerAddressTypeEnum.Billing : 0);

            return customerAddress;
        }

        private static List<CountryDto.CountryRow> GetAllCountries()
        {
            return CountryManager.GetCountries().Country.ToList();
        }
    }
}