using System.ComponentModel.DataAnnotations;

namespace tdd.Server.Models
{
    public class TrackingGegevensModel
    {
        [Key]
        public Guid UserID { get; set; }
        [Key]
        public Guid OnderzoekID { get; set; }
        [Required]

        [MaxLength(2147483647)]
        public string Data { get; set; }
    }
}
