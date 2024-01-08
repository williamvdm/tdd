using Microsoft.EntityFrameworkCore;
using tdd.Server.Models;

namespace tdd.Server.Context
{
    public class OnderzoekContext : DbContext
    {
        public OnderzoekContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // TODO: Connection string naar secret
            options.UseNpgsql("Host=localhost;Database=tdddb;Username=postgres;Password=passlauwillannak");
        }

        // Voeg hieronder ALTIJD de databasemodellen toe voor deze context, dus tabellen die te maken hebben met Onderzoek bij OnderzoekContext. Algemene tabellen mogen in DatabaseContext.
        // Dus alle models die je aanmaakt in het mapje Models, anders werkt het programma niet.
        public DbSet<OnderzoekModel> Onderzoeken { get; set; }
        public DbSet<AntwoordModel> Antwoorden { get; set; }
        public DbSet<BeantwoordModel> Beantwoord { get; set; }
        public DbSet<UserModel> Deelnemers {get; set;}
        public DbSet<OpdrachtModel> Opdrachten { get; set; }
        public DbSet<OnderzoeksoortModel> Onderzoeksoorten { get; set;}
        public DbSet<VraagModel> Vragen {get;set; }
    }
}
