namespace ContactBook.core.Models
{
    public interface INumber
    {
        int Id { get; set; }
        string NumberType { get; set; }
        int PhoneNumber { get; set; }
        Contact Contact { get; set; }
    }
}