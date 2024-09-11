using System.ComponentModel.DataAnnotations;

namespace Parking_Management_System.Models
{
    public class ParkingTransaction
    {
        [Key]
        [Display(Name = "Transactions Id")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Vehicle Id")]
        public int VehicleId { get; set; }

        public virtual Vehicle Vehicles { get; set; }

        [Required]
        [Display(Name = "Parking Space Id")]
        public int ParkingSpaceId { get; set; }

        public Vehicle Vehicle { get; set; }

        public virtual ParkingSpace ParkingSpaces { get; set; }

        [Required]
        [Display(Name = "Entry Time")]
        public DateTime EntryTime { get; set; }

        [Required]
        [Display(Name = "Exit Time")]
        public DateTime ExitTime { get; set; }

        [Required]
        [Display(Name = "Duration")]
        public DateTime Duration { get; set; }

        [Display(Name ="Payment Status")]
        public bool PaymentStatus { get; set; } = false;


    }
}
