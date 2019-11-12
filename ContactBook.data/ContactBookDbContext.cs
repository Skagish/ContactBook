using System.Data.Entity;
using ContactBook.core.Models;
using ContactBook.data.Migrations;

namespace ContactBook.data
{
    public class ContactBookDbContext : DbContext, IContactBookDbContext
    {
        public ContactBookDbContext() : base("ContactBook")
            {
                Database.SetInitializer<ContactBookDbContext>(null);
                Database.SetInitializer(new MigrateDatabaseToLatestVersion<ContactBookDbContext, Configuration>());
            }

            public DbSet<Contact> Contact { get; set; }

            public DbSet<Adress> Adress { get; set; }
            public DbSet<Email> Email { get; set; }
            public DbSet<Number> Number { get; set; }
    }
}