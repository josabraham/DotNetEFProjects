using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactsMVC.Models
{
    public class ContactGroup
    {
        public int ContactGroupId { get; set; }
        public string GroupName { get; set; }
        public ICollection<Contact> Contacts { get; set; } // One-to-Many Relationship
    }
}