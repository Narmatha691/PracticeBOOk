using PracticeAPI.Entities;
using PracticeAPI.Model;

namespace PracticeAPI.Services
{
    public interface IUserService
    {
        ResultModel AddUser(User user);
        List<User> GetAllUsers();
        User ValidteUser(string userName, string password);
    }
}
