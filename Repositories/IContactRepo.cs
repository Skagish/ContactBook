using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IContactRepo
    {
        int Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Company { get; set; }
        DateTime? BirthDate { get; set; }
        string Note { get; set; }
        int? AdressID { get; set; }
        int? EmailID { get; set; }
        int? NumbersID { get; set; }
    }
}
