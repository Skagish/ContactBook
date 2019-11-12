using System;
using System.Collections.Generic;

namespace ContactBook.core.Models
{
    public class Contact : Entity, IContact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public DateTime BirthDate { get; set; }
        public string Note { get; set; }

        public virtual ICollection<Adress> Adress { get; set; }
        public virtual ICollection<Email> Email { get; set; }
        public virtual ICollection<Number> Number { get; set; }
    }
}