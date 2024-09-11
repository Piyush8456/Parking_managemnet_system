using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Parking_Management_System.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<ParkingLots> parkingLots { get; set; }

        public DbSet<ParkingSpace> parkingSpaces { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<ParkingTransaction> ParkingTransactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParkingSpace>()
          .HasOne(ps => ps.ParkingLot)
          .WithMany(pl => pl.ParkingSpaces)
          .HasForeignKey(ps => ps.parkingLotId)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ParkingTransaction>()
                .HasOne(pt => pt.ParkingSpaces)
                .WithMany(pt => pt.ParkingTransactions)
                .HasForeignKey(p => p.ParkingSpaceId)
                    .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ParkingTransaction>()
            .HasOne(v => v.Vehicle)
            .WithMany(pt => pt.ParkingTransactions)
            .HasForeignKey(pt => pt.VehicleId)
                    .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
