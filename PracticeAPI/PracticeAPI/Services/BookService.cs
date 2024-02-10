using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using PracticeAPI.Database;
using PracticeAPI.DTO;
using PracticeAPI.Entities;
using PracticeAPI.Model;

namespace PracticeAPI.Services
{
    public class BookService:IBookService
    {
        private readonly MyContext context;
        private readonly IMapper _mapper;

        public BookService(MyContext context, IMapper mapper)
        {
            this.context = context;
            this._mapper = mapper;

        }

        public ResultModel AddBook(Book book)
        {
            try
            {     
                context.Books.Add(book);
                context.SaveChanges();

                return new ResultModel { Success = true, Message = "Book added successfully." };
            }
            catch (Exception ex)
            {
                return new ResultModel { Success = false, Message = $"Error: {ex.Message}" };
            }
        }

        public List<Book> GetAllBooks()
        {
            try
            {
                return context.Books.ToList();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public BookDTO GetBookById(int bookId)
        {
            try
            {
                Book books = context.Books.Where(p => p.BookId == bookId).SingleOrDefault();
                if (books == null)
                {
                    return null;
                }
                BookDTO book = _mapper.Map<BookDTO>(books);

                return book;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ResultModel DeleteBook(int bookId)
        {
            try
            {
                Book book = context.Books.SingleOrDefault(p => p.BookId == bookId);

                if (book != null)
                {
                    context.Books.Remove(book);
                    context.SaveChanges();

                    return new ResultModel { Success = true, Message = "Book deleted successfully." };
                }
                else
                {
                    return new ResultModel { Success = false, Message = "Book not found." };
                }
            }
            catch (Exception ex)
            {
                return new ResultModel { Success = false, Message = $"Error: {ex.Message}" };
            }
        }

        public ResultModel EditBook(Book book)
        {
            try
            {
               
                Book existingbook = context.Books.SingleOrDefault(p => p.BookId == book.BookId);
                if (existingbook != null)
                {
                    context.Entry(existingbook).State = EntityState.Detached;
                    context.Books.Update(book);
                    context.SaveChanges();
                    return new ResultModel { Success = true, Message = "Book edited successfully." };
                }
                else
                {
                    return new ResultModel { Success = false, Message = "Book not found." };
                }
            }
            catch (Exception ex)
            {

                return new ResultModel { Success = false, Message = $"Error: {ex.Message}" };
            }
        }

        public List<BookDTO> SearchBooksByTitle(string searchTerm)
        {
            try
            {
                List<Book> activeMatchingBooks = context.Books
                           .Where(p => EF.Functions.Like( p.Title, $"%{searchTerm}%"))
                    .OrderByDescending(p => p.PublishedDate)
                    .ToList();


                List<BookDTO> matchingBookDTOs = _mapper.Map<List<BookDTO>>(activeMatchingBooks);

                return matchingBookDTOs;
            }
            catch (Exception)
            {
                throw;
            }

        }
        public List<BookDTO> SearchBooksByGenre(string searchTerm)
        {
            try
            {
                List<Book> activeMatchingBooks = context.Books
                           .Where(p => EF.Functions.Like(p.Genre, $"%{searchTerm}%"))
                    .OrderByDescending(p => p.PublishedDate)
                    .ToList();


                List<BookDTO> matchingBookDTOs = _mapper.Map<List<BookDTO>>(activeMatchingBooks);

                return matchingBookDTOs;
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}
