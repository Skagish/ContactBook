using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using ContactBook.core.Models;
using System.Threading.Tasks;

namespace ContactBook.data
{
    public interface IContactBookDbContext
    {
        DbSet<T> Set<T>() where T : class;
        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        DbSet<Contact> Contact { get; set; }

        DbSet<Adress> Adress { get; set; }
        DbSet<Email> Email { get; set; }
        DbSet<Number> Number { get; set; }

        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}