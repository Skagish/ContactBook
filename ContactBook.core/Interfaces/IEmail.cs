namespace ContactBook.core.Models
{
    public interface IEmail
    {
        int Id { get; set; }
        string Email1 { get; set; }
        Contact Contact { get; set; }
    }
}