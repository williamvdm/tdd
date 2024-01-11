using System.ComponentModel.DataAnnotations;

namespace tdd.Server.Models
{
    public class UserModelDto
    {
        [Key]
        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
