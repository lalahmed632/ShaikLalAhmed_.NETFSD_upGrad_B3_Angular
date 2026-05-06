using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Repositories
{
    public class ContactRepository : IContactRepository
    {
        public static List<ContactInfo> contacts = new List<ContactInfo>()
        {
            new ContactInfo { ContactId = 1, FirstName = "Lal", LastName = "Ahmed", EmailId = "lal236@gmail.com", MobileNo =7981573094 , Designation = "Tester", CompanyId = 1, DepartmentId = 10 },
            new ContactInfo { ContactId = 2, FirstName = "Sharan", LastName = "Kumar", EmailId = "sharan@gmail.com", MobileNo = 7075754191, Designation = "Developer", CompanyId = 2, DepartmentId = 20 },

        };

        public List<ContactInfo> GetAll() => contacts;

        public ContactInfo GetById(int id) => contacts.Find(x => x.ContactId == id);

        public void Add(ContactInfo contact)
        {
            contact.ContactId = contacts.Count + 1;
            contacts.Add(contact);
        }

        public void Update(int id, ContactInfo contact)
        {
            var existing = contacts.Find(x => x.ContactId == id);
            if (existing != null)
            {
                existing.FirstName = contact.FirstName;
                existing.LastName = contact.LastName;
                existing.EmailId = contact.EmailId;
                existing.MobileNo = contact.MobileNo;
                existing.Designation = contact.Designation;
                existing.CompanyId = contact.CompanyId;
                existing.DepartmentId = contact.DepartmentId;
            }
        }

        public void Delete(int id)
        {
            var contact = contacts.Find(x => x.ContactId == id);
            if (contact != null)
            {
                contacts.Remove(contact);

            }
        }
    }
}
