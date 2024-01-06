using System.ComponentModel.DataAnnotations;

namespace tdd.Server.Models
{
    public class VerzorgerModel
    {
        [Key]
        public int VerzorgerId { get; set;}

        [Required]
        public string VerzorgerEmail { get; set;}

        [Required]
        public string VerzorgerTelefoon { get; set;}
    }
}
