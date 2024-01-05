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
        // Voeg hieronder ALTIJD de databasemodellen toe voor deze context, dus tabellen die te maken hebben met Onderzoek bij OnderzoekContext. Algemene tabellen mogen in DatabaseContext.
        // Dus alle models die je aanmaakt in het mapje Models, anders werkt het programma niet. 
    }
}
