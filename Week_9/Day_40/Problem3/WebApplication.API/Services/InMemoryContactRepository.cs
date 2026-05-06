using WebApplication3.Models;

namespace WebApplication3.Services
{
    public class InMemoryContactRepository : IContactRepository
    {
        private readonly List<ContactInfo> _contacts;

        public InMemoryContactRepository()
        {
            _contacts = new List<ContactInfo>();

            _contacts.Add(new ContactInfo
            {
                ContactId = 1,
                FirstName = "Rahul",
                LastName = "Sharma",
                EmailId = "rahul.sharma@example.com",
                MobileNo = 9876543210,
                Designation = "Manager",
                CompanyName = "ABC Pvt Ltd",
                DepartmentName = "Sales"
            });

            _contacts.Add(new ContactInfo
            {
                ContactId = 2,
                FirstName = "Priya",
                LastName = "Iyer",
                EmailId = "priya.iyer@example.com",
                MobileNo = 9123456780,
                Designation = "Developer",
                CompanyName = "XYZ Technologies",
                DepartmentName = "IT"
            });
        }

        public Task<IEnumerable<ContactInfo>> GetAllAsync()
        {
            IEnumerable<ContactInfo> contacts = _contacts;
            return Task.FromResult(contacts);
        }

        public Task<ContactInfo?> GetByIdAsync(int id)
        {
            ContactInfo? foundContact = null;

            foreach (ContactInfo contact in _contacts)
            {
                if (contact.ContactId == id)
                {
                    foundContact = contact;
                    break;
                }
            }

            return Task.FromResult(foundContact);
        }

        public Task<ContactInfo> AddAsync(ContactInfo contact)
        {
            int newId = 1;

            if (_contacts.Count > 0)
            {
                newId = _contacts.Max(c => c.ContactId) + 1;
            }

            contact.ContactId = newId;
            _contacts.Add(contact);

            return Task.FromResult(contact);
        }

        public Task<bool> UpdateAsync(int id, ContactInfo contact)
        {
            ContactInfo? existing = null;

            foreach (ContactInfo item in _contacts)
            {
                if (item.ContactId == id)
                {
                    existing = item;
                    break;
                }
            }

            if (existing == null)
            {
                return Task.FromResult(false);
            }

            existing.FirstName = contact.FirstName;
            existing.LastName = contact.LastName;
            existing.EmailId = contact.EmailId;
            existing.MobileNo = contact.MobileNo;
            existing.Designation = contact.Designation;
            existing.CompanyName = contact.CompanyName;
            existing.DepartmentName = contact.DepartmentName;

            return Task.FromResult(true);
        }

        public Task<bool> DeleteAsync(int id)
        {
            ContactInfo? existing = null;

            foreach (ContactInfo contact in _contacts)
            {
                if (contact.ContactId == id)
                {
                    existing = contact;
                    break;
                }
            }

            if (existing == null)
            {
                return Task.FromResult(false);
            }

            _contacts.Remove(existing);
            return Task.FromResult(true);
        }
    }
}
