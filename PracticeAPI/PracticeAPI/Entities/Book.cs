using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticeAPI.Entities
{
    [Table("Books")]
    public class Book
    {
        [Key]
        public int? BookId { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Author { get; set; }
        [Required]
        public string? Genre { get; set; }
        [Required]
        public string? ISBN { get; set; }
        [Required]
        public DateTime PublishedDate { get; set; }

    }
}
