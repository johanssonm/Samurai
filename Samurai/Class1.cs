using System;
using Microsoft.EntityFrameworkCore;

namespace EfSamurai.Data
{
    public class SamuraiContext : DbContext
    {
        public DbSet<EfSamurai> Samurais { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server = (localdb)\\mssqllocaldb; Database = EfSamurai; Trusted_Connection = True; ");
        }
    }
}
