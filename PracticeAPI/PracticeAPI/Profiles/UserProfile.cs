using PracticeAPI.DTO;
using PracticeAPI.Entities;
using AutoMapper;

namespace PracticeAPI.Profiles
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
        }
    }
}
