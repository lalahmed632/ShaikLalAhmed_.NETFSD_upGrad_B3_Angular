using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public interface IContactRepository
    {
        List<ContactInfo> GetAll();
        ContactInfo GetById(int id);
        void Add(ContactInfo contact);
        void Update(int id, ContactInfo contact);
        void Delete(int id);
    }
}
