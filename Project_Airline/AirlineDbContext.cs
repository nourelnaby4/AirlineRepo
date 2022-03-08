using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;



namespace Project_Airline
{
    public class AirlineDbContext : DbContext
    {

        public AirlineDbContext() { }
        public AirlineDbContext(DbContextOptions<AirlineDbContext> options)
            : base(options)
        {
        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source =.; Initial Catalog = AirlineDb;");
            }
        }
        public DbSet<Airline> Airlines { get; set; }

    }

    
}
