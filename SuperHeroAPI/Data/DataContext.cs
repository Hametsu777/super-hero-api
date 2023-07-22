using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Data
{
    // Be sure to read definition of DbContext.
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        // Another way to add a connection string, instead of doing it through appsettings.json and program.cs.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql(connectionString: "Server=localhost;Port=5433;User Id=postgres;Password=admin;Database=superherodb;");
        }

        // Use Linq to have Entity Framework create SQL statements. Property Name is pluralized name of Model. Will be the
        // name of the table in the database.
        public DbSet<SuperHero> SuperHeroes { get; set; }
    }
}
