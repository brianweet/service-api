using System;
using System.Collections.Generic;

namespace Geta.ServiceApi.Commerce.Models
{
    public class Organization
    {
        public Guid PrimaryKeyId { get; set; }

        public IEnumerable<Address> Addresses { get; set; }

        public IEnumerable<Organization> ChildOrganizations { get; set; }
        
        public IEnumerable<Contact> Contacts { get; set; }
        
        public string OrganizationType { get; set; }
        
        public string OrgCustomerGroup { get; set; } 
        
        // TODO Add property for CreditCards 
    }
}