using UserService.Model;

namespace UserService.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly static IEnumerable<User> _users = new List<User>()
        {
             new User(1, "John", "Doe"),
             new User(2, "Tom", "Sawyer")
        };

        public UserRepository()
        {

        }

        public IEnumerable<User> GetAll()
        {
            return _users;
        }

        public User? GetUser(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            return user;
        }


    }
}
