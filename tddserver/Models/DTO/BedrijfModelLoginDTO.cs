using System.ComponentModel.DataAnnotations;

namespace tdd.Server.Models.DTO
{
    public class BedrijfModelLoginDTO
    {
        [Required]
        public string Bedrijfsmail { get; set; }

        [Required]
        public string Password { get; set; }

    }
}
