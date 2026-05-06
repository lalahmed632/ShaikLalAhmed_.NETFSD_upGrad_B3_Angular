using ContactManagement.Interfaces;
using ContactManagement.Models;
using ContactManagement.Services;

IContactService service = new ContactService();

service.AddContact(new Contact
{
    Name = "Lal",
    Email = "lal@gmail.com",
    Phone = "1234567890"
});

service.AddContact(new Contact
{
    Name = "John",
    Email = "john@gmail.com",
    Phone = "9876543210"
});

var contacts = service.GetAllContacts();

foreach (var contact in contacts)
{
    Console.WriteLine($"{contact.Id}: {contact.Name} - {contact.Email} - {contact.Phone}");
}