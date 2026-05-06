using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _repository;

        public ContactsController(IContactRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetContacts()
        {
            return Ok(_repository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetContactById(int id)
        {
            var contact = _repository.GetById(id);
            if (contact == null)
            {
                return NotFound("Requested contact does not exists");
            }
            return Ok(contact);
        }

        [HttpPost]
        public IActionResult AddContact(ContactInfo contact)
        {
            _repository.Add(contact);
            return Ok(new { contact, status = "New contact successfully added to server..!" });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateContact(int id, ContactInfo contact)
        {
            var existing = _repository.GetById(id);
            if (existing == null)
            {
                return NotFound("Requested contact does not exists");
            }
            _repository.Update(id, contact);
            return Ok(new { updatedContact = contact, status = "Contact details are updated successfully in server..!" });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var contact = _repository.GetById(id);
            if (contact == null)
            {
                return NotFound("Requested contact does not exists");
            }
            _repository.Delete(id);
            return Ok(new { contact, status = "Contact details are deleted successfully in server..!" });
        }
    }
}