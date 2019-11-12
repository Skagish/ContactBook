using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ContactBook.core.Models;
using ContactBook.core.Services;
using ContactBook.data;

namespace ContactBook.Controllers
{
    public class CustomerController : ApiController
    {
        private readonly ContactBookDbContext db = new ContactBookDbContext();
        private readonly IContactService _contact;

        public CustomerController(IContactService contact)
        {
            _contact = contact;
        }

        // GET: api/Customer
        [HttpGet]
        [Route("api/Customer")]
        public HttpResponseMessage GetContacts(HttpRequestMessage request)
        {
            lock (_contact.GetContacts())
            {
                var contacts = _contact.GetContacts();
                if (contacts == null)
                {
                    return request.CreateResponse(HttpStatusCode.NotFound);
                }
                return request.CreateResponse(HttpStatusCode.OK, contacts);
            }
        }

        // GET: api/Customer/5
        [ResponseType(typeof(Contact))]
        [HttpGet]
        [Route("api/Customer/{id}")]
        public IHttpActionResult GetContactById(int id)
        {
            lock (_contact.GetContacts())
            {
                var contact = _contact.QueryById(id);
                if (contact == null)
                {
                    return NotFound();
                }

                return Ok(contact);
            }
        }

        // PUT: api/Customer/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutContact(int id, Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contact.Id)
            {
                return BadRequest();
            }

            db.Entry(contact).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Customer
        [HttpPost]
        [Route("api/Customer")]
        public async Task<IHttpActionResult> AddContact(Contact contact)
        {
            if (!IsValid(contact))
            {
                return BadRequest();
            }

            var result = await _contact.AddContact(contact);
            if (!result.Succeeded)
            {
                return Conflict();
            }

            contact.Id = result.Id;
            return Created(string.Empty, contact);
        }

        private bool IsValid(Contact contact)
        {
            return !string.IsNullOrEmpty(contact.FirstName) &&
                !string.IsNullOrEmpty(contact.LastName) &&
                !string.IsNullOrEmpty(contact.Id.ToString()) &&
                IsValidEmail(contact.Email) && IsValidNumber(contact.Number) &&
                IsValidAdress(contact.Adress);
        }

        private bool IsValidAdress(ICollection<Adress> adress)
        {
            return true;
        }

        private bool IsValidNumber(ICollection<Number> number)
        {
            if (number == null)
            {
                return true;
            }
            var list = new List<bool>();
            foreach (var item in number)
            {
                bool result = false;
                var nr = item.PhoneNumber;
                var type = item.NumberType;
                if (nr == null && type != null)
                {
                    result = false;
                }
                if (nr == null && type == null)
                {
                    result = true;
                }

                if (nr != null && type != null)
                {
                    if (nr.ToString().Length > 16)
                    {
                        result = false;
                    }
                    else
                    {
                        result = true;
                    }
                }
                
                list.Add(result);
            }

            if (list.Contains(false))
            {
                return false;
            }

            return true;
        }

        private bool IsValidEmail(ICollection<Email> email)
        {
            if (email == null)
            {
                return true;
            }
            var list = new List<bool>();
            
            {
                
            }
            foreach (var item in email)
            {
                bool result;
                var mail = item.Email1;
                if (mail != null)
                {
                    result = Regex.IsMatch(mail, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
                }
                else
                {
                    result = true;
                }
                
                list.Add(result);
            }

            if (list.Contains(false))
            {
                return false;
            }

            return true;
        }

        // DELETE: api/Customer/5
        [ResponseType(typeof(Contact))]
        [HttpDelete]
        [Route("api/Customer/{id}")]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            _contact.DeleteContactById(id);
            return request.CreateResponse(HttpStatusCode.OK);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContactExists(int id)
        {
            return db.Contact.Count(e => e.Id == id) > 0;
        }
    }
}