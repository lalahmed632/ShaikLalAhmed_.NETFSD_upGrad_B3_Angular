
using System.Collections.Generic;
using MyWebApplication3.Models;

namespace MyWebApplication3.Services
{
    public interface IContactService
    {
        List<ContactInfo> GetAllContacts();
        ContactInfo GetContactById(int id);
        void AddContact(ContactInfo contact);
    }
}