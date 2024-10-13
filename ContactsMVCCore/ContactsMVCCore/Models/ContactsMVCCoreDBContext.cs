using Microsoft.EntityFrameworkCore;

namespace ContactsMVCCore.Models
{
    public partial class ContactsMVCCoreDBContext : DbContext
    {
        public ContactsMVCCoreDBContext()
        {
        }
        public ContactsMVCCoreDBContext(DbContextOptions<ContactsMVCCoreDBContext> options)
            :base(options)
        {
            
        }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<ContactGroup> ContactGroups { get; set; }
    }
}