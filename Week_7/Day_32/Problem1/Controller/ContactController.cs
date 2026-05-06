using Microsoft.AspNetCore.Mvc;
using MyWebApplication3.Services;
using MyWebApplication3.Models;

namespace MyWebApplication3.Controllers
{
    [Route("contact")]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        // Constructor Injection
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        // Show all contacts
        [HttpGet("show")]
        public IActionResult ShowContacts()
        {
            var contacts = _contactService.GetAllContacts();
            return View(contacts);
        }

        // Get contact by ID
        [HttpGet("get")]
        public IActionResult GetContactById(int id)
        {
            var contact = _contactService.GetContactById(id);
            return View(contact);
        }

        // Show Add Form
        [HttpGet("add")]
        public IActionResult AddContact()
        {
            return View();
        }

        // Handle Add
        [HttpPost("add")]
        public IActionResult AddContact(ContactInfo contactInfo)
        {
            _contactService.AddContact(contactInfo);
            return RedirectToAction("ShowContacts");
        }
    }
}