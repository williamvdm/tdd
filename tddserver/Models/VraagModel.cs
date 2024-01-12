using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace tdd.Server.Models
{
    public class VraagModel
    {
        [Key]
        public int VraagID { get; set; }

        public Guid OnderzoekID { get; set; } // Foreign key

        [MaxLength(128)]
        public string? Vraag {get; set; }

        public List<AntwoordModel>? Antwoorden { get; set; }
    }
}
