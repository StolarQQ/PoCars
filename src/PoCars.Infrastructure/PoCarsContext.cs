using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using PoCars.Domain;

namespace PoCars.Infrastructure
{
    public class PoCarsContext : DbContext
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
            //carBuilder.Property(x => x.Price).HasAnnotation("Column", TypeName = "decimal(4,2)");

        }
    }
}