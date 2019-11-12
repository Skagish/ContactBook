using System.Threading.Tasks;
using ContactBook.core.Models;
using ContactBook.core.Services.ContactBook.services;

namespace ContactBook.core.Services
{
    public interface IEmailService : IEntityService<Email>
    {
        Task<ServiceResult> AddEmail(Entity email);
        Task<Email> GetEmailById(int id);
        Task<ServiceResult> DeleteEmailById(int id);
        Task<Email> DeleteAll();
    }
}