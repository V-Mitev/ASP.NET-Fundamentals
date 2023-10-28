namespace DemoAPI.Data.Data
{
    using DemoAPI.Data.Data.Configuration;
    using DemoAPI.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class DemoApiDbContext : DbContext
    {
        public DemoApiDbContext(DbContextOptions<DemoApiDbContext> options) 
            : base(options)
        {
            
        }

        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Person>(new PersonConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
