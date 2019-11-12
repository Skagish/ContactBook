using System.Threading.Tasks;
using ContactBook.core.Models;
using ContactBook.core.Services.ContactBook.services;

namespace ContactBook.core.Services
{
    public interface INumberService : IEntityService<Number>
    {
        Task<ServiceResult> AddNumber(Entity number);
        Task<Email> GetNumberById(int id);
        Task<ServiceResult> DeleteNumberById(int id);
        Task<Email> DeleteAll();
    }
}