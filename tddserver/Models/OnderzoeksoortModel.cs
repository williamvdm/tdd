using System.ComponentModel.DataAnnotations;

namespace tdd.Server.Models
{
    public class OnderzoeksoortModel
    {
        [Key]
        [MaxLength(128)]
        public string Tag { get; set;}
    }
}