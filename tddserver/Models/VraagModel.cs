using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace tdd.Server.Models
{
    [PrimaryKey(nameof(OnderzoekID), nameof(VraagID))]
    public class VraagModel
    {
        [Key]
        [Column(Order = 0)]
        public int OnderzoekID;

        [Key]
        [Column(Order = 1)]
        public int VraagID;

        [MaxLength(128)]
        public string? Vraag {get; set; }

        public List<AntwoordModel>? Antwoorden {get; set;}
    }
}
