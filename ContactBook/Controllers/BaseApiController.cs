using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ContactBook.data;

namespace ContactBook.Controllers
{
    public class BaseApiController : ApiController
    {
        private IContactBookDbContext _repo;

        public BaseApiController(IContactBookDbContext repo)
        {
            _repo = repo;
        }

        protected IContactBookDbContext TheRepository
        {
            get
            {
                return _repo;
            }
        }
    }
}
