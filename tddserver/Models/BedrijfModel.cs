using System.ComponentModel.DataAnnotations;

namespace tdd.Server.Models
{
    public class BedrijfModel
    {
        [Key]
        public string Bedrijfsmail { get; set;}

        [Required]
        public string Password { get; set; }
        
        [Required]
        public string Informatie { get; set; }

        public LocatieModel Locatie { get; set; }

        [Required]
        public string Link { get; set; }

        [Required]
        public bool Verified { get; set; } = false;

        [Required]
        public string Provider { get; set; }

        public List<ContactPersoonModel>? contactpersonen { get; set; }

        public List<OnderzoekModel>? onderzoeken { get; set; }
    }
}
