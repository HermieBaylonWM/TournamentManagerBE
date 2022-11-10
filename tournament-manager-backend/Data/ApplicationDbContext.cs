using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using tournament_manager_backend.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace tournament_manager_backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<WinRecord> WinRecords { get; set; }
        public DbSet<LossRecord> LossRecords { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>()
                .HasMany(p => p.Wins)
                .WithOne(w => w.Player);

            modelBuilder.Entity<Player>()
                .HasMany(p => p.Losses)
                .WithOne(w => w.Player);

        }
    }
}
