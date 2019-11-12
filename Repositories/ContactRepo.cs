using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    class ContactRepo : IContactRepo
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Note { get; set; }
        public int? AdressID { get; set; }
        public int? EmailID { get; set; }
        public int? NumbersID { get; set; }
    }
}
