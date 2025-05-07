using Microsoft.EntityFrameworkCore;
using WebApplication1.Models.Entities;

namespace WebApplication1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Ship> Ship { get; set; }
        public DbSet<Port> Port { get; set; }
        public DbSet<Voyage> Voyage { get; set; }
        public DbSet<Country> Country { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Voyage>()
                .HasOne(v => v.DeparturePort)
                .WithMany(p => p.DepartureVoyages)
                .HasForeignKey(v => v.DeparturePortId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Voyage>()
                .HasOne(v => v.ArrivalPort)
                .WithMany(p => p.ArrivalVoyages)
                .HasForeignKey(v => v.ArrivalPortId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
