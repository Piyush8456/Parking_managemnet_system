using Parking_Management_System.Enum_s;
using System.ComponentModel.DataAnnotations;

namespace Parking_Management_System.Models
{
    public class ParkingSpace
    {
        [Key]
        [Display(Name = "Spot Id")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Parking Lot Id")]
        public int parkingLotId { get; set; }

        public virtual ParkingLots ParkingLot { get; set; }

        [Required]
        [Display(Name = "Avalible")]
        public bool IsAvailable { get; set; } = true;

        [Display(Name = "Parking Space Size")]
        public SpaceSize SpaceSize { get; set; }

        public virtual ICollection<ParkingTransaction> ParkingTransactions { get; set; }

    }
}
