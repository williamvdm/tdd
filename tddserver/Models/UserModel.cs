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

        [MaxLength(10)]
        public char Telefoon { get; set; }

        [Required]
        public bool ToestemmingBenadering { get; set; }

        public string VoorkeurBenadering { get; set; }

        [Required]
        public string Provider {  get; set; }

        [Required]
        public DateTime GeboorteDatum { get; set; }

        [Required]
        public string IdentityHash { get; set; }
        
    }
}
