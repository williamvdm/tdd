using System.ComponentModel.DataAnnotations;

namespace tdd.Server.Models.DTO
{
    public class BedrijfModelDTO
    {
        [Required]
        public string Bedrijfsmail { get; set; }

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
    }
}
