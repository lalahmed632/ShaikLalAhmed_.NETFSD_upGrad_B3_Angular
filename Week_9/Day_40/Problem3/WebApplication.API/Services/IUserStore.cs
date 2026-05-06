using WebApplication3.Models;

namespace WebApplication3.Services;

public interface IUserStore
{
    IEnumerable<User> GetAll();
    User? GetByUsername(string username);
    User Add(RegisterRequest request);
}
