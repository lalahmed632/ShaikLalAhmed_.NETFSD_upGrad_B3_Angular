using WebApplication3.Models;

namespace WebApplication3.Services
{
    public class InMemoryUserStore : IUserStore
    {
        private readonly List<User> _users;

        public InMemoryUserStore()
        {
            _users = new List<User>();

            _users.Add(new User
            {
                Id = 1,
                Username = "admin",
                Password = "admin123",
                Role = "Admin"
            });

            _users.Add(new User
            {
                Id = 2,
                Username = "user",
                Password = "user123",
                Role = "User"
            });
        }

        public IEnumerable<User> GetAll()
        {
            return _users;
        }

        public User? GetByUsername(string username)
        {
            foreach (User user in _users)
            {
                if (user.Username.ToLower() == username.ToLower())
                {
                    return user;
                }
            }

            return null;
        }

        public User Add(RegisterRequest request)
        {
            int newId = 1;

            if (_users.Count > 0)
            {
                newId = _users.Max(u => u.Id) + 1;
            }

            string role = request.Role;

            if (string.IsNullOrWhiteSpace(role))
            {
                role = "User";
            }

            User user = new User();
            user.Id = newId;
            user.Username = request.Username;
            user.Password = request.Password;
            user.Role = role;

            _users.Add(user);
            return user;
        }
    }
}
