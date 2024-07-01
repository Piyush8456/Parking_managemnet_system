using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Parking_Management_System.Models
{
    public class VehicleRegistration
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Display(Name ="Id")]
        public int Id { get; set; }

        [Display(Name = "Sport Number")]
        public int SpotNumber { get; set; }


        [Display(Name = "Vehicle Number")]
        public required string  VehicleName { get; set; }

        [Display(Name = "Sport Number")]
        public required string VehicleNumber {  get; set; } 
    }
}
