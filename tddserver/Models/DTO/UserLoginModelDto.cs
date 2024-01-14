using System.ComponentModel.DataAnnotations;

namespace tdd.Server.Models
{
    public class UserLoginModelDto
    {
        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
