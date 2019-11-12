using ContactBook.core.Services;

namespace ContactBook.core.Models
{
    using System;
    using System.Collections.Generic;

    public class Adress : Entity, IAdress
    {
        public int Id { get; set; }
        public string Adress1 { get; set; }

        public virtual Contact Contact { get; set; }
    }
}