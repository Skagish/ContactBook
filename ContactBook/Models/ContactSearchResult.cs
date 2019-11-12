using System.Collections.Generic;
using ContactBook.core.Models;

namespace ContactBook.Models
{
    public class ContactSearchResult
    {
        public int Page { get; set; }
        public int TotalItems { get; set; }
        public List<Contact> Items { get; set; }
    }
}