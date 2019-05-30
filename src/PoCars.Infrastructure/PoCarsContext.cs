using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PoCars.Domain;

namespace PoCars.Infrastructure
{
    public class PoCarsContext : IdentityDbContext<IdentityUser>
    {
        public PoCarsContext(DbContextOptions<PoCarsContext> options) : base(options)
        {

        }

        public DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var carBuilder = modelBuilder.Entity<Car>();

            carBuilder.HasKey(x => x.Id);
            carBuilder.Property(x => x.Id)
                .HasAnnotation("DatabaseGenerated", DatabaseGeneratedOption.None);

            // Added for IdentityUserLogin primary key
            base.OnModelCreating(modelBuilder);
        }
    }
}