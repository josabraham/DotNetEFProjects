using Microsoft.EntityFrameworkCore;

namespace ContactsMVCCore.Models
{
    public partial class ContactsMVCCoreSQLiteDBContext : DbContext
    {
        public ContactsMVCCoreSQLiteDBContext()
        {
        }
        public ContactsMVCCoreSQLiteDBContext(DbContextOptions<ContactsMVCCoreSQLiteDBContext> options)
            :base(options)
        {
            
        }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<ContactGroup> ContactGroups { get; set; }
    }
}