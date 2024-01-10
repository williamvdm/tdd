using System.ComponentModel.DataAnnotations;

namespace tdd.Server.Models
{
    public class BeantwoordModel
    {
        [Key]
        public Guid? User { get; set; }

        [Required]
        public OnderzoekModel Onderzoek { get; set; }

        [Required]
        public VraagModel Vraag { get; set; }

        [Required]
        public string Antwoord { get; set; }
    }
}
