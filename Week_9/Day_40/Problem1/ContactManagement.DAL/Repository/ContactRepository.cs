using ContactManagement.DAL.Data;
using ContactManagement.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactManagement.DAL.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly AppDbContext _context;

        public ContactRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ContactInfo>> GetAllAsync()
        {
            return await _context.Contacts
                .Include(c => c.Company)
                .Include(c => c.Department)
                .ToListAsync();
        }

        public async Task<ContactInfo?> GetByIdAsync(int id)
        {
            return await _context.Contacts
                .Include(c => c.Company)
                .Include(c => c.Department)
                .FirstOrDefaultAsync(x => x.ContactId == id);
        }

        public async Task AddAsync(ContactInfo contact)
        {
            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ContactInfo contact)
        {
            _context.Contacts.Update(contact);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            ContactInfo? contact = await _context.Contacts.FindAsync(id);

            if (contact != null)
            {
                _context.Contacts.Remove(contact);
                await _context.SaveChangesAsync();
            }
        }
    }
}
