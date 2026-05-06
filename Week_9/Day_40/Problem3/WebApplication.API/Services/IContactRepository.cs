using WebApplication3.Models;

namespace WebApplication3.Services;

public interface IContactRepository
{
    Task<IEnumerable<ContactInfo>> GetAllAsync();
    Task<ContactInfo?> GetByIdAsync(int id);
    Task<ContactInfo> AddAsync(ContactInfo contact);
    Task<bool> UpdateAsync(int id, ContactInfo contact);
    Task<bool> DeleteAsync(int id);
}
