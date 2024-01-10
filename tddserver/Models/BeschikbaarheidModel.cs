using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace tdd.Server.Models
{
    [PrimaryKey(nameof(User), nameof(Begintijd))]
    public class BeschikbaarheidModel
    {
        
        public Guid? User { get; set;}

        public DateTime Begintijd {get; set;}

        public DateTime Eindtijd { get; set;}
    }
}
