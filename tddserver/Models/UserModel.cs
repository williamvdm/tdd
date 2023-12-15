using System.ComponentModel.DataAnnotations;

namespace tdd.Server.Models
{
    public class UserModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
    }
}
