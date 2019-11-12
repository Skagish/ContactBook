using System;
using System.Collections.Generic;

namespace ContactBook.core.Models
{
    public interface IContact
    {
        int Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Company { get; set; }
        DateTime BirthDate { get; set; }
        string Note { get; set; }
        ICollection<Adress> Adress { get; set; }
        ICollection<Email> Email { get; set; }
        ICollection<Number> Number { get; set; }
    }
}