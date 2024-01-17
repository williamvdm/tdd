using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tdd.Server.Models
{
    public class OnderzoekModel
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(128)]
        public string? Beschrijving { get; set; }

        public string? BedrijfMail { get; set; }

        [Required]
        public DateOnly Begindatum { get; set; }

        [Required]
        public DateOnly Einddatum { get; set; }

        public LocatieModel? Locatie { get; set; }

        public string? BeloningBeschrijving { get; set; }

        [Required]
        public string Titel { get; set; }

        public List<VraagModel>? Vragen { get; set; }

        public TrackingGegevensModel? TrackingGegevens { get; set; }
        
        public OpdrachtModel? Opdracht { get; set; }

        public List<UserModel> Deelnemers { get; set; }
    }
}
