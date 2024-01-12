using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace tdd.Server.Models
{
    public class BeschikbaarheidModel
    {
        [Key]
        public int BeschikbaarheidId { get; set; }
        public DateTime Begintijd {get; set;}

        public DateTime Eindtijd { get; set;}
    }
}
