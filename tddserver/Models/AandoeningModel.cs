using System.ComponentModel.DataAnnotations;

namespace tdd.Server.Models
{
    public class AandoeningModel
    {
        [Key]
        public int AandoeningId { get; set;}
        
        [Required]
        public string AandoeningNaam { get; set; }
    }
}
