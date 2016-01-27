using System;

namespace Geta.ServiceApi.Commerce.Models
{
    public class Address
    {
        //public Guid? AddressId { get; set; }

        public DateTime? Modified { get; set; }

        public string Name { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string CountryName { get; set; }

        public string CountryCode { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        public string Line1 { get; set; }

        public string Line2 { get; set; }

        public string Region { get; set; }

        public string Email { get; set; }

        public bool ShippingDefault { get; set; }

        public bool BillingDefault { get; set; }

        public string DaytimePhoneNumber { get; set; }

        public string EveningPhoneNumber { get; set; }

        public string Organization { get; set; }
    }
}