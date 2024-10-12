using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactsMVC.Models
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int ContactGroupId { get; set; } // Foreign Key
        public ContactGroup ContactGroup { get; set; } // Navigation Property
    }
}