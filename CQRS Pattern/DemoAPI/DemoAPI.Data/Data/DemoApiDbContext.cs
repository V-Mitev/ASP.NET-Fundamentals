namespace DemoAPI.Data.Data
{
    using DemoAPI.Data.Data.Configuration;
    using DemoAPI.Data.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class DemoApiDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public DemoApiDbContext(DbContextOptions<DemoApiDbContext> options) 
            : base(options)
        {
            
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; } = null!;

        public DbSet<ApplicationRole> ApplicationRoles { get; set; } = null!;

        public DbSet<Person> Persons { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Person>(new PersonConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
