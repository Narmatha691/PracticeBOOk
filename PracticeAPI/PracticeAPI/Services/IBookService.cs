using PracticeAPI.DTO;
using PracticeAPI.Entities;
using PracticeAPI.Model;

namespace PracticeAPI.Services
{
    public interface IBookService
    {
        ResultModel AddBook(Book book);
        List<Book> GetAllBooks();
        BookDTO GetBookById(int bookId);
        ResultModel DeleteBook(int bookId);
        ResultModel EditBook(Book book);
        List<BookDTO> SearchBooksByTitle(string searchTerm);
        List<BookDTO> SearchBooksByGenre(string searchTerm);
    }
}
