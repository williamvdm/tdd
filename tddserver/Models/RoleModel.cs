using System.ComponentModel.DataAnnotations;

namespace tdd.Server.Models
{
    public class RoleModel
    {
        [Key]
        public string? Naam {get; set;}

        [Required]
        public int Machtigingingen {get; set;}
    }
}
