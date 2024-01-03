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
            // It would be a good idea to move the connection string to user secrets
            options.UseNpgsql("Host=localhost;Database=tdddb;Username=postgres;Password=passlauwillannak");
        }

        // Voeg hieronder ALTIJD de databasemodellen toe voor deze context, dus tabellen die te maken hebben met Onderzoek bij OnderzoekContext. Algemene tabellen mogen in DatabaseContext.
        // Dus alle models die je aanmaakt in het mapje Models, anders werkt het programma niet. 
    }
}
