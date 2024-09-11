using System.ComponentModel.DataAnnotations;

namespace Parking_Management_System.Models
{
    public class Vehicle
    {
        [Key]
        [Display(Name ="Vehicle Id")]
        public int Id {  get; set; } 

        [Required]
        [Display(Name = "Vehicle Id")]
        public int LicensePlateNumber {  get; set; }

        [Required]
        [Display(Name = "Vehicle Type")]
        public int VehicleType {  get; set; }

        [Required]
        [Display(Name = "Owner Name")]
        public string OwnerName {  get; set; }
        
        [Required]
        [Display(Name = "Owner Name")]
        public string OwnerContact {  get; set; }
        public virtual ICollection<ParkingTransaction> ParkingTransactions { get; set; }

    }
}
