using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace tdd.Server.Models
{
    public class TrackingGegevensModel
    {
        [Key]
        public int TrackingDataId { get; set; }

        [Required]
        public string? Data { get; set; }
    }
}
