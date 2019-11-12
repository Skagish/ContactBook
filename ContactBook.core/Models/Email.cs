namespace ContactBook.core.Models
{
    public class Email : Entity, IEmail
    {
        public int Id { get; set; }
        public string Email1 { get; set; }

        public virtual Contact Contact { get; set; }
    }
}