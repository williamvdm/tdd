using System.ComponentModel.DataAnnotations;

namespace tdd.Server.Models
{
    public class BeschikbaarheidModel
    {
        [Key]
        public UserModel? User { get; set;}

        [Key]
        public DateTime Begintijd {get; set;}

        public DateTime Eindtijd { get; set;}
    }
}
