using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tdd.Server.Models;

namespace tdd.Server.Context
{
    public interface DbContextInterface
    {
        public DbSet<BedrijfModel> Bedrijven { get; set; }
        public DbSet<ContactPersoonModel> Contactpersonen { get; set; }
        public DbSet<LocatieModel> Locaties { get; set; }
        public DbSet<OnderzoekModel> Onderzoeken { get; set; }
        public DbSet<AntwoordModel> Antwoorden { get; set; }
        public DbSet<BeantwoordModel> Beantwoord { get; set; }
        public DbSet<UserModel> Deelnemers { get; set; }
        public DbSet<OpdrachtModel> Opdrachten { get; set; }
        public DbSet<VraagModel> Vragen { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<AandoeningModel> Aandoeningen { get; set; }
        public DbSet<BeperkingModel> Beperkingen { get; set; }
        public DbSet<BeschikbaarheidModel> Beschikbaarheid { get; set; }
        public DbSet<HulpmiddelModel> Hulpmiddelen { get; set; }
        public DbSet<TrackingGegevensModel> TrackingGegevens { get; set; }
        public DbSet<VerzorgerModel> Verzorgers { get; set; }

        public Task<int> SaveChangesAsync();
        public void Remove(BedrijfModel item);
        public void Remove(UserModel item);
        public void Add(OnderzoekModel item);
    }

    public class DatabaseContext : DbContext, DbContextInterface
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // TODO: Connection string naar secret
            options.UseNpgsql("Host=abloxdatabase.postgres.database.azure.com;Database=tdddb;Username=abloxroot;Password=passlauwillannak123!;Port=5432;SSL Mode=Require;Trust Server Certificate=true");

        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        public void Remove(BedrijfModel item)
        {
            base.Remove(item);
        }

        public void Remove(UserModel item)
        {
            throw new NotImplementedException();
        }

        public void Add(OnderzoekModel item)
        {
            throw new NotImplementedException();
        }

        // Voeg hieronder ALTIJD de databasemodellen toe voor deze context, dus tabellen die te maken hebben met Onderzoek bij OnderzoekContext. Algemene tabellen mogen in DatabaseContext.
        // Dus alle models die je aanmaakt in het mapje Models, anders werkt het programma niet. 
        public DbSet<BedrijfModel> Bedrijven { get; set; }
        public DbSet<ContactPersoonModel> Contactpersonen {get; set;}
        public DbSet<LocatieModel> Locaties { get; set; }
        public DbSet<OnderzoekModel> Onderzoeken { get; set; }
        public DbSet<AntwoordModel> Antwoorden { get; set; }
        public DbSet<BeantwoordModel> Beantwoord { get; set; }
        public DbSet<UserModel> Deelnemers {get; set;}
        public DbSet<OpdrachtModel> Opdrachten { get; set; }
        public DbSet<VraagModel> Vragen {get;set; }
        public virtual DbSet<UserModel> Users { get; set; }
        public DbSet<AandoeningModel> Aandoeningen { get; set; }
        public DbSet<BeperkingModel> Beperkingen {get; set;}
        public DbSet<BeschikbaarheidModel> Beschikbaarheid {get; set;}
        public DbSet<HulpmiddelModel> Hulpmiddelen { get; set; }
        public DbSet<TrackingGegevensModel> TrackingGegevens {get;set;}
        public DbSet<VerzorgerModel> Verzorgers { get; set; }
    }
}
