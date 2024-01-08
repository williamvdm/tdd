using System.ComponentModel.DataAnnotations;

namespace tdd.Server.Models
{
    public class VraagModel
    {
        [Key]
        public int OnderzoekID;

        [Key]
        public int VraagID;

        [MaxLength(128)]
        public string? Vraag {get; set; }

        public List<AntwoordModel>? Antwoorden {get; set;}
    }
}
