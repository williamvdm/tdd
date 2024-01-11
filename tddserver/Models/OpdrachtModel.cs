using System.ComponentModel.DataAnnotations;

namespace tdd.Server.Models
{
    public class OpdrachtModel
    {
        [Key]
        [Required]
        public string? Data { get; set;}
    }
}
