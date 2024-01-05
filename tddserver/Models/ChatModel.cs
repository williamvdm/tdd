using System.ComponentModel.DataAnnotations;

namespace tdd.Server.Models
{
    public class ChatModel
    {
        [Key]
        public int ChatBerichtID { get; set; }

        [Required]
        public string ZenderMail { get; set; }

        [Required]
        public string OntvangerMail { get; set; }

        [Required]
        public string Bericht { get; set; }
    }
}
