using Laboratorium_3___App.Controllers;
using Laboratorium_3___App.Models;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorium_9
{
    public class ContactControllerTest
    {
        private ContactController _controller;
        private IContactService _service;

        public ContactControllerTest()
        {
            IDateTimeProvider dateTimeProvider = new CurrentDateTimeProvider();
            _service = new MemoryContactService(dateTimeProvider);
            _service.Add(new Contact() { Name = "Test1" });
            _service.Add(new Contact() { Name = "Test2" });
            _controller = new ContactController(_service) ;
        }

        [Fact]
        public void IndexTest()
        {
            var result = _controller.Index();
            Assert.IsType<ViewResult>(result);
            var view = result as ViewResult;
            Assert.IsType<List<Contact>>(view.Model);
            var list = view.Model as List<Contact>;
            Assert.Equal(_service.FindAll().Count, list.Count);
        }

        [Fact]
        public void DetailsTestForNonExistingContacts()
        {
            var result = _controller.Details(3); //liczba kontaktów
            Assert.IsType<NotFoundResult>(result);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void DetailsTestForExistingContacts(int id)
        {
            var result = _controller.Details(id);
            Assert.IsType<ViewResult>(result);
            var view = result as ViewResult;
            Assert.IsType<Contact>(view.Model);
            var contact = view.Model as Contact;
            Assert.Equal(id,contact.ID);
        }

        [Fact]
        public void DeleteTest()
        {
            var contact = new Contact() { ID = 1 };
            var prev = _service.FindById(contact.ID);
            Assert.Equal(prev.ID, contact.ID);
            var result = _controller.Delete(contact);

            //ciag dalszy
            
        }
    }
}