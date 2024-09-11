using System.ComponentModel.DataAnnotations;

namespace Parking_Management_System.Enum_s
{
    public enum SpaceSize
    {
        [Display(Name = "Standard (9 * 20)")]
        Standard=1,

        [Display(Name= "Compact (7 * 15)")]
        Compact =2,

        [Display(Name = "Large/Extended (12 * 24)")]
        Large = 3,

        [Display(Name = " Handicap/Accessible (8 * 18)")]
        Handicape= 4
    }
}
