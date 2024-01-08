using System.ComponentModel.DataAnnotations;

namespace tdd.Server.Models
{
    public class LocatieModel
    {
        [Key]
        public int LocatieID { get; set; }

        [Length(6, 6)]
        [Required]
        public string PostCode {get; set;}
        
        [MaxLength(58)]
        public string? PlaatsNaam {get; set;}

        [MaxLength(85)]
        public string? StraatNaam {get; set;}

        public int Huisnummer { get; set; }
    }
}
