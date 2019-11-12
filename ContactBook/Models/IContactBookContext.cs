using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactBook.core.Models;

namespace ContactBook.Models
{
    interface IContactBookContext : IDisposable
    {
        DbSet<Contact> Products { get; }
        int SaveChanges();
        void MarkAsModified(Contact item);
    }
}
