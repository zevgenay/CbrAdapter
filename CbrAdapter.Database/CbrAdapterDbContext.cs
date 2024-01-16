using CbrAdapter.Database.Configurations;
using CbrAdapter.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace CbrAdapter.Database
{
    public class CbrAdapterDbContext : DbContext
    {
        public DbSet<KeyRate> KeyRates { get; set; }

        public CbrAdapterDbContext(DbContextOptions<CbrAdapterDbContext> options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name });
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new KeyRateConfigurations());
        }
    }
}