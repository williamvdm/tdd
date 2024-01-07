using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using tdd.Server.Models;

namespace tdd.Server.Context
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // TODO: Connection string naar secret
            options.UseNpgsql("Host=localhost;Database=tdddb;Username=postgres;Password=passlauwillannak");
        }
        
        public DbSet<UserModel> Users { get; set; }
        public DbSet<AandoeningModel> Aandoeningen { get; set; }
        public DbSet<BeperkingModel> Beperkingen {get; set;}
        public DbSet<BeschikbaarheidModel> Beschikbaarheid {get; set;}
        public DbSet<HulpmiddelModel> Hulpmiddelen { get; set; }
        public DbSet<TrackingGegevensModel> TrackingGegevens {get;set;}
        public DbSet<UserRoleMachtigingModel> UserRoleMachtiging { get; set;}
        public DbSet<VerzorgerModel> Verzorgers { get; set; }
        // Voeg hieronder ALTIJD de databasemodellen toe voor deze context, dus tabellen die te maken hebben met Onderzoek bij OnderzoekContext. Algemene tabellen mogen in DatabaseContext.
        // Dus alle models die je aanmaakt in het mapje Models, anders werkt het programma niet. 
    }
}
