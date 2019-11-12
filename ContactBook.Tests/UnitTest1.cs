using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using ContactBook.Controllers;
using ContactBook.core.Models;
using ContactBook.core.Services;
using ContactBook.data;
using ContactBook.services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ContactBook.Tests
{
    [TestClass]
    public class TestCustomerController
    {
        [TestMethod]
        public void GetContacts_ShouldReturnContacts()
        {
            // Arrange
            var mockContactsRepos = new ContactBookDbContext();
            var mockContactsRepo = new ContactService(mockContactsRepos);
            var controller = new CustomerController(mockContactsRepo);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var post = controller.AddContact(new Contact());
            var response = controller.GetContacts(controller.Request);

            // Assert
            Contact contact;
            Assert.IsTrue(response.TryGetContentValue(out contact));
            Assert.AreEqual(7, contact.Id);
        }

        [TestMethod]
        public void GetContacts_ShouldReturnContactsById()
        {
            //Arrange
            var ContactID = 0;
            var mockContactsRepo = new Mock<IContactService>();
            mockContactsRepo.Setup(x => x.QueryById(ContactID)).Equals(new Contact() { Id = 0 });
            var controller = new CustomerController(mockContactsRepo.Object);
            //Act
            IHttpActionResult response = controller.GetContactById(ContactID);
            var contentResult = response as OkNegotiatedContentResult<Contact>;
            //Assert
            Assert.IsNotNull(contentResult);
            Assert.AreEqual(ContactID, contentResult.Content.Id);
        }

        [TestMethod]
        public void PostProduct_ShouldReturnSameProduct()
        {
            var controller = new CustomerController(new ContactService(new ContactBookDbContext()));

            var item = GetDemoProduct();

            var result = controller.AddContact(item);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Id, item.Id);
        }

        [TestMethod]
        public void PutProduct_ShouldReturnStatusCode()
        {
            var controller = new CustomerController(new ContactService(new ContactBookDbContext()));

            var item = GetDemoProduct();

            var result = controller.PutContact(item.Id, item);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
            Assert.AreEqual(HttpStatusCode.NoContent, result.IsFaulted);
        }

        [TestMethod]
        public void PutProduct_ShouldFail_WhenDifferentID()
        {
            var controller = new CustomerController(new ContactService(new ContactBookDbContext()));

            var badresult = controller.PutContact(999, GetDemoProduct());
            Assert.IsInstanceOfType(badresult, typeof(BadRequestResult));
        }

        [TestMethod]
        public async System.Threading.Tasks.Task GetProduct_ShouldReturnProductWithSameIDAsync()
        {
            var context = new ContactService(new ContactBookDbContext());
            await context.AddContact(GetDemoProduct());

            var controller = new CustomerController(new ContactService(new ContactBookDbContext()));
            var result = controller.GetContactById(3) as OkNegotiatedContentResult<Contact>;

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Content.Id);
        }

        [TestMethod]
        public async void GetProducts_ShouldReturnAllProducts()
        {
            var context = new ContactService(new ContactBookDbContext());
            await context.AddContact(new Contact() { FirstName = "Demo1", LastName = "Eddie" });
            await context.AddContact(new Contact() { FirstName = "Demo2", LastName = "Eddie1" });
            await context.AddContact(new Contact() { FirstName = "Demo3", LastName = "Eddie2" });

            var controller = new CustomerController(context);
            var result = controller.GetContacts(controller.Request) as IContactService;

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.GetContacts().Result.GetEnumerator().Current.Id.Equals(3));
        }

        [TestMethod]
        public void DeleteProduct_ShouldReturnOK()
        {
            var context = new ContactService(new ContactBookDbContext());
            var item = GetDemoProduct();
            context.AddContact(item);

            var controller = new CustomerController(context);
            var result = controller.Delete(controller.Request, item.Id) as IContactService;

            Assert.IsNotNull(result);
            Assert.AreEqual(item.Id, result.DeleteContactById(item.Id));
        }

        Contact GetDemoProduct()
        {
            return new Contact() { Id = 3, FirstName = "Leo", LastName = "Reinicans"};
        }
    }
}

