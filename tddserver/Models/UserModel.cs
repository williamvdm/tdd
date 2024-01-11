using System.ComponentModel.DataAnnotations;

namespace tdd.Server.Models
{
    public class UserModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Voornaam { get; set; }

        [Required]
        public string Achternaam { get; set; }

        [Required]
        public string Email { get; set; }

        public string? Telefoon { get; set; }

        public bool? ToestemmingBenadering { get; set; }

        public string? VoorkeurBenadering { get; set; }

        [Required]
        public string Provider {  get; set; }

        public bool IsAdult { get; set; }

        [Required]
        public string IdentityHash { get; set; }

        [Required]
        public string Role { get; set; }

        public VerzorgerModel? Verzorger { get; set; }

        public List<AandoeningModel>? Aandoening { get; set; }

        public List<BeperkingModel>? Beperking { get; set; }

        public List<BeschikbaarheidModel>? Beschikbaarheid { get; set; }

        public List<OnderzoeksoortModel>? Onderzoeksoorten { get; set;}

        public LocatieModel Adres { get; set; }

    }
}
