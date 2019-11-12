using System;

namespace ContactBook.core.Models
{
    public class Number : Entity, INumber
    {
        public int Id { get; set; }
        public string NumberType { get; set; }
        public int PhoneNumber { get; set; }

        public virtual Contact Contact { get; set; }
    }
}