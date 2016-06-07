using System;
using System.Collections.Generic;

namespace Geta.ServiceApi.Commerce.Models
{
    [Serializable]
    public class Contact
    {
        public Guid? PrimaryKeyId { get; set; }

        public Address[] Addresses { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string RegistrationSource { get; set; }
    }
}