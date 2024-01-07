using System.ComponentModel.DataAnnotations;

namespace tdd.Server.Models
{
    public class HulpmiddelModel
    {
        [Key]
        [MaxLength(128)]
        public string Hulpmiddel { get; set; }
    }
}
