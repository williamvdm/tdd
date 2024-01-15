using System.ComponentModel.DataAnnotations;

namespace tdd.Server.Models.DTO
{
    public class OnderzoekModelDTO
    {
        [Required]
        public string Titel { get; set; }

        [MaxLength(128)]
        public string? Beschrijving { get; set; }

        [Required]
        public string BedrijfMail { get; set; }

        [Required]
        public DateOnly Begindatum { get; set; }

        [Required]
        public DateOnly Einddatum { get; set; }

        public LocatieModel? Locatie { get; set; }

        public string? BeloningBeschrijving { get; set; }

    }
}
