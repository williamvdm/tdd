using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tdd.Server.Models
{
    public class ContactPersoonModel
    {
        [Key]
        public int ContactPersoonID { get; set; }

        [Required]
        public string Voornaam { get; set; }

        [Required]
        public string Achternaam { get; set; }

    }
}
