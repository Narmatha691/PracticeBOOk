using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PracticeAPI.Database;
using PracticeAPI.Entities;
using PracticeAPI.Model;

namespace PracticeAPI.Services
{
    public class UserService:IUserService
    {
        private readonly MyContext context;
        private readonly IMapper _mapper;

        public UserService(MyContext context, IMapper mapper)
        {
            this.context = context;
            this._mapper = mapper;

        }
        public ResultModel AddUser(User user)
        {
            try
            {
                if (context.Users.Any(u => u.UserName == user.UserName))
                {
                    return new ResultModel { Success = false, Message = "User with the same UserName already exists." };
                }
                if (context.Users.Any(u => u.UserEmail == user.UserEmail))
                {
                    return new ResultModel { Success = false, Message = "User with the same Email already exists." };
                }
                context.Users.Add(user);
                context.SaveChanges();

                return new ResultModel { Success = true, Message = "User added successfully." };
            }
            catch (Exception ex)
            {
                return new ResultModel { Success = false, Message = $"Error: {ex.Message}" };
            }
        }
        public List<User> GetAllUsers()
        {
            try
            {
                return context.Users.ToList();
            }
            catch (Exception)
            {

                throw;
            }

        }
        public User ValidteUser(string userName, string password)
        {
            return context.Users.SingleOrDefault(u => u.UserName == userName && u.Password == password);
        }


        

    }

}
