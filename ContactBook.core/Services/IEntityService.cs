using ContactBook.core.Models;

namespace ContactBook.core.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace ContactBook.services
    {
        public interface IEntityService<T> where T : Entity
        {
            IQueryable<T> Query();

            IQueryable<T> QueryById(int id);
            IEnumerable<T> Get();

            Task<T> GetById(int id);

            ServiceResult Create(T entity);
            ServiceResult Delete(T entity);
            ServiceResult Update(T entity);

            bool Exists(int id);
        }
    }

}