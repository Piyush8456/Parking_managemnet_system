using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Parking_Management_System.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public virtual DbSet<VehicleRegistration> VehicleRegistration { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleRegistration>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<VehicleRegistration>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            //modelBuilder.Entity<VehicleRegistration>().Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    // Configure the connection string (for example, using SQL Server)
        //    optionsBuilder.UseSqlServer("DefaultConnection");
        //}
    }
}
