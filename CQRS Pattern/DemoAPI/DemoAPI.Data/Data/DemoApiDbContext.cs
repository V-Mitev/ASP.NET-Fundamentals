namespace DemoAPI.Data.Data
{
    using DemoAPI.Data.Data.Configuration;
    using DemoAPI.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class DemoApiDbContext : IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid>
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
