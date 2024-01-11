using System.ComponentModel.DataAnnotations;

namespace tdd.Server.Models
{
    public class AntwoordModel
    {
        [Key]
        public int AntwoordID { get; set; }

        [Required]
        public string Onderzoek { get; set; }

        [Required]
        public string Vraag { get; set; }

        [Required]
        public string Antwoord { get; set; }
    }
}
