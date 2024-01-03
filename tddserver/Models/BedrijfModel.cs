using System.ComponentModel.DataAnnotations;

namespace tdd.Server.Models
{
    public class BedrijfModel
    {
        [Key]
        public Guid Bedrijfsmail { get; set;}
        
        [Required]
        public string Informatie { get; set; }

        public LocatieModel Locatie { get; set; }

        [Required]
        public string Link { get; set; }

        [Required]
        public bool Verified { get; set; }

        [Required]
        public string Provider { get; set; }

    }
}
