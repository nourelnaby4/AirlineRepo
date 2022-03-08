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
                optionsBuilder.UseSqlServer("Data Source =DESKTOP-3JFH685\\SQL2019; Initial Catalog = AirlineDb; User ID = sa; Password = 0000;");
            }
        }
        public DbSet<Airline> Airlines { get; set; }

    }

    
}
