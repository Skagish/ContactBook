using System.Collections.Generic;
using System.Threading.Tasks;
using ContactBook.core.Models;
using ContactBook.core.Services.ContactBook.services;

namespace ContactBook.core.Services
{
    public interface IAdressService : IEntityService<Adress>
    {
        Task<ServiceResult> AddAdress(Adress adress);
        Task<Adress> GetAdressById(int id);
        Task<ServiceResult> DeleteAdressById(int id);
        Task<Adress> DeleteAll();
    }
}