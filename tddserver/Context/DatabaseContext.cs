using Microsoft.EntityFrameworkCore;
using tdd.Server.Models;

namespace tdd.Server.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "tdd_db");
        }

        public DbSet<UserModel> Users { get; set; }
    }
}
