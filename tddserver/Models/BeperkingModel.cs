using System.ComponentModel.DataAnnotations;

namespace tdd.Server.Models
{
    public class BeperkingModel
    {
        [Key]
        public int BeperkingId { get; set;}
        
        [Required]
        public string BeprkingNaam { get; set; }
    }
}
