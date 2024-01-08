using System.ComponentModel.DataAnnotations;

namespace tdd.Server.Models
{
    public class BeperkingModel
    {
        [Key]
        public int BeperkingId { get; set;}
        
        [Required]
        public string BeperkingNaam { get; set; }
    }
}
