using System.ComponentModel.DataAnnotations;

namespace tdd.Server.Models
{
    public class OnderzoekModel
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(128)]
        public char Beschrijving { get; set; }

        public BedrijfModel? Bedrijf { get; set; }

        [Required]
        public DateOnly Begindatum { get; set; }

        [Required]
        public DateOnly Einddatum { get; set; }

        public LocatieModel? Locatie { get; set; }

        [MaxLength(128)]
        public char? BeloningBeschrijving { get; set; }

        [Required]
        [MaxLength(128)]
        public char Titel { get; set; }

        [Required]
        [MaxLength(128)]
        public char OnderzoekSoort { get; set; }

        [Required]
        public List<VraagModel>? Vragen { get; set; }
    }
}
