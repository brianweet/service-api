using System;
using System.Collections.Generic;
using Mediachase.Commerce.Customers;

namespace Geta.ServiceApi.Commerce.Models
{
    public class Contact
    {
        public Guid PrimaryKeyId { get; set; }

        public List<CustomerAddress> Addresses { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string RegistrationSource { get; set; }
    }
}