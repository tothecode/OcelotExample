using UserService.Model;

namespace UserService.Services
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();

        User? GetUser(int id);
    }
}
