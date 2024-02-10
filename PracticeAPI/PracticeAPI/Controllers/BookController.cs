using AutoMapper;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticeAPI.DTO;
using PracticeAPI.Entities;
using PracticeAPI.Services;

namespace PracticeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService bookService;
        private readonly IMapper _mapper;
        private readonly IConfiguration configuration;
        private readonly ILog _logger;

        public BookController(IBookService bookService, IMapper mapper, IConfiguration configuration, ILog logger)
        {
            this.bookService = bookService;
            this._mapper = mapper;
            this.configuration = configuration;
            this._logger = logger;
        }

        [HttpPost, Route("AddBook")]
        //[Authorize(Roles = "1")]
        public IActionResult AddBook(BookDTO bookdto)
        {
            try
            {
                Book book = _mapper.Map<Book>(bookdto);
                var result = bookService.AddBook(book);
                if (result.Success)
                {
                    _logger.Info("Book added successfully");
                    return StatusCode(200, book);
                }
                else
                {
                    _logger.Error(result.Message);
                    return StatusCode(400, result.Message);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return StatusCode(500, ex.Message);
            }


        }
        [HttpGet, Route("GetAllBooks")]
        [AllowAnonymous]
        
        public IActionResult GetAllBooks()
        {
            try
            {
                List<Book> books = bookService.GetAllBooks();
                return StatusCode(200, books);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet, Route("GetBookById/{bookId}")]
        [AllowAnonymous]
        //
        public IActionResult GetPostById(int bookId)
        {
            try
            {

                BookDTO book = bookService.GetBookById(bookId);
                return StatusCode(200, book);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return StatusCode(400, ex.Message);
            }
        }

        [HttpDelete, Route("DeleteBook/{bookId}")]
        //[Authorize(Roles = "1")]
        public IActionResult DeletePost(int bookId)
        {
            try
            {

                var result = bookService.DeleteBook(bookId);
                if (result.Success)
                {
                    return StatusCode(200, result.Message);
                }
                else
                {

                    return StatusCode(400, result.Message);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return StatusCode(400, ex.Message);
            }
        }
        [HttpPut, Route("EditBok")]
        //[Authorize(Roles = "1")]
        public IActionResult EditBook(Book book)
        {
            try
            {
                var result = bookService.EditBook(book);
                if (result.Success)
                {
                    return StatusCode(200, result.Message);
                }
                else
                {
                    return StatusCode(400, result.Message);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return StatusCode(400, ex.Message);
            }
        }
        [HttpGet, Route("SearchBookByTitle/{searchTerm}")]
        [AllowAnonymous]
        //
        public IActionResult SearchBookByTitle(string searchTerm)
        {
            try
            {

                List<BookDTO> book = bookService.SearchBooksByTitle(searchTerm);
                return StatusCode(200, book);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return StatusCode(400, ex.Message);
            }
        }
        [HttpGet, Route("SearchBookByGenre/{searchTerm}")]
        [AllowAnonymous]
        //
        public IActionResult SearchBookByGenre(string searchTerm)
        {
            try
            {

                List<BookDTO> book = bookService.SearchBooksByGenre(searchTerm);
                return StatusCode(200, book);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return StatusCode(400, ex.Message);
            }
        }

    }
}
