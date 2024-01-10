using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace tdd.Server.Models
{
    [PrimaryKey(nameof(UserID), nameof(OnderzoekID))]
    public class TrackingGegevensModel
    {  
        public Guid UserID { get; set; }
        public Guid OnderzoekID { get; set; }
        
        [Required]
        public string? Data { get; set; }
    }
}
