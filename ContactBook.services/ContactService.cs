using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactBook.core.Models;
using ContactBook.core.Services;
using ContactBook.data;

namespace ContactBook.services
{
    public class ContactService : EntityService<Contact>, IContactService
    {
        public ContactService(IContactBookDbContext context) : base(context) { }
        public virtual async Task<IEnumerable<Contact>> GetContacts()
        {
            return await Task.FromResult(Get());
        }

        public IQueryable<T> QueryById<T>(int id) where T : Entity
        {
            return Query<T>().Where(t => t.Id == id);
        }

        public virtual async Task<ServiceResult> AddContact(Contact contact)
        {
            if (contact == null)
            {
                return new ServiceResult(succeeded: false);
            }

            return Create(contact);
        }

        public virtual async Task<Contact> GetContactById(int id)
        {
            using (var context = new ContactBookDbContext())
            {
                var contact = context.Contact.Find(id);
                return contact;
            }
        }

        public virtual async Task<ServiceResult> DeleteContactById(int id)
        {
            var contact = await GetById(id);
            return contact == null ? new ServiceResult(true) : Delete(contact);
        }

        public virtual async Task<ServiceResult> DeleteContacts()
        {
            _ctx.Contact.RemoveRange(_ctx.Contact);
            await _ctx.SaveChangesAsync();
            return new ServiceResult(succeeded: true);
        }
    }
}
