using System.ComponentModel.DataAnnotations;

namespace tdd.Server.Models
{
    public class UserRoleMachtigingModel
    {
        [Key]
        [MaxLength(32)]
        public string Role { get; set; }

        public int Machtigingingen { get; set; }
    }
}
