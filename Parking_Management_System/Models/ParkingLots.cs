using Parking_Management_System.Enum_s;
using Parking_Management_System.Models;
using System.ComponentModel.DataAnnotations;

namespace Parking_Management_System.Models
{
    public class ParkingLots
    {
        [Key]
        [Display(Name = "Parking Lot Id")]
        [Required]
        public int Id {  get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Capacity")]
        public int TotalCapacity { get; set; }

        [Required]
        [Display(Name = "Avalible Spaces")]
        public int AvailableSpaces { get; set; }

        [Required]
        [Display(Name = "Select Parking Space Size")]
        public SpaceSize SelectedSpaceSize { get; set; }

        [Required]
        //public int SelectedSpaceSize { get; set; }

        public ICollection<ParkingSpace> ParkingSpaces { get; set; }
    }
}