using AutoMapper;
using PracticeAPI.DTO;
using PracticeAPI.Entities;

namespace PracticeAPI.Profiles
{
    public class BookProfile:Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookDTO>();
            CreateMap<BookDTO, Book>();
        }
    }
}
