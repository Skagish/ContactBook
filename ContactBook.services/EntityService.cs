using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactBook.core.Models;
using ContactBook.core.Services;
using ContactBook.core.Services.ContactBook.services;
using ContactBook.data;
using ContactBook.services;

namespace ContactBook.services
{
    public class EntityService<T> : DbService, IEntityService<T> where T : Entity
    {
        public EntityService(IContactBookDbContext context) : base(context) { }
        public ServiceResult Create(T entity)
        {
            return Create<T>(entity);
        }

        public virtual ServiceResult Delete(T entity)
        {
            return Delete<T>(entity);
        }

        public virtual bool Exists(int id)
        {
            return QueryById(id).Any();
        }

        public virtual IEnumerable<T> Get()
        {
            return Get<T>();
        }

        public virtual async Task<T> GetById(int id)
        {
            return await GetById<T>(id);
        }

        public virtual IQueryable<T> Query()
        {
            return Query<T>();
        }

        public virtual IQueryable<T> QueryById(int id)
        {
            return Query<T>().Where(t => t.Id == id);
        }

        public virtual ServiceResult Update(T entity)
        {
            return Update<T>(entity);
        }
    }
}