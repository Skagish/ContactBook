using System.Collections.Generic;
using System.Threading.Tasks;
using ContactBook.core.Models;
using ContactBook.core.Services.ContactBook.services;

namespace ContactBook.core.Services
{
    public interface IContactService : IEntityService<Contact>
    {
        Task<IEnumerable<Contact>> GetContacts();
        Task<ServiceResult> AddContact(Contact flight);
        Task<Contact> GetContactById(int id);
        Task<ServiceResult> DeleteContactById(int id);
        Task<ServiceResult> DeleteContacts();
    }
}