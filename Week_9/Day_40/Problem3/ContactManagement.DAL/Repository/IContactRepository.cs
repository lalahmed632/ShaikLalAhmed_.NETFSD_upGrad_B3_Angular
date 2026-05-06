using ContactManagement.DAL.Models;

namespace ContactManagement.DAL.Repository
{
    public interface IContactRepository
    {
        Task<IEnumerable<ContactInfo>> GetAllAsync();
        Task<ContactInfo?> GetByIdAsync(int id);
        Task AddAsync(ContactInfo contact);
        Task UpdateAsync(ContactInfo contact);
        Task DeleteAsync(int id);
    }
}
