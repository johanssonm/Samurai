using Microsoft.EntityFrameworkCore;

namespace EfSamurai
{
    public class SamuraiContext : DbContext
    {
        public DbSet<Samurai> Samurais { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server = (localdb)\\mssqllocaldb; Database = EfSamurai; Trusted_Connection = True; ");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {

            modelBuilder.Entity<SamuraiBattle>().HasKey(x => new { x.BattleID, x.SamuraiID });

        }

    }
}