using Microsoft.EntityFrameworkCore;
using WebApplication11.model;

namespace WebApplication11.Data
{
    public class ContactsAPIDbContext:DbContext
    {
        public ContactsAPIDbContext(DbContextOptions options) : base(options)
        {

        }

        
        public DbSet<Contact> Contacts { get; set; }

       
    
    
    }

}
