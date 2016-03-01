using System;
using System.Collections.Generic;

namespace Geta.ServiceApi.Commerce.Models
{
    public class Organization
    {
        public Guid PrimaryKeyId { get; set; }

        public List<Address> Addresses { get; set; }

        public List<Organization> ChildOrganizations { get; set; }
        
        public List<Contact> Contacts { get; set; }
        
        public string OrganizationType { get; set; }
        
        public string OrgCustomerGroup { get; set; } 
        
        // TODO Add property for CreditCards 
    }
}