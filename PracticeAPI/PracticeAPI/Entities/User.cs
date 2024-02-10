using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PracticeAPI.Entities
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int? UserId { get; set; }
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? UserEmail { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public int? IsAdmin { get; set; } = 0;
    }
}
