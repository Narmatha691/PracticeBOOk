using System.ComponentModel.DataAnnotations;

namespace PracticeAPI.DTO
{
    public class BookDTO
    {
        public string? Title { get; set; }
      
        public string? Author { get; set; }
        public string? Genre { get; set; }
 
        public string? IsISBAdmin { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}
