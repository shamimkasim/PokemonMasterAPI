using Microsoft.EntityFrameworkCore;
using PokemonMasterAPI.Domain.Entities;

namespace PokemonMasterAPI.Infrastructure.Data
{
    public class PokemonDbContext : DbContext
    {
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<Capture> Captures { get; set; }

        public DbSet<Evolution> Evolutions { get; set; }

        public PokemonDbContext(DbContextOptions<PokemonDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=PokemonMaster.db");
            }
        }
    }

}
