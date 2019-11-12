using ContactBook.core.Services;

namespace ContactBook.core.Models
{
    public interface IAdress
    {
        int Id { get; set; }
        string Adress1 { get; set; }
        Contact Contact { get; set; }
    }
}