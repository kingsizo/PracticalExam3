using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class LicensePlate
    {
        [Key]
        public string PlateNumber { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string PlateType { get; set; }

        [Required]
        [MaxLength(20)]
        public string DateOfRegistration { get; set; }
        
        public KAT RegistratedInKat { get; set; }
        public LicensePlate Registrator { get; set; }

        private LicensePlate()
        {
        }
        
        public LicensePlate(string platetype, string date)
        {
            PlateType = platetype;
            DateOfRegistration = date;
            PlateNumber = Guid.NewGuid().ToString().Substring(0, 8);
        }
        public LicensePlate(string platenumber, string platetype, string date)
        {
            PlateNumber = platenumber;
            PlateType = platetype;
            DateOfRegistration = date;
        }
        public override string ToString()
        {
            return "Plate Number: " + PlateNumber + " Registrator: " + Registrator + " Date of Registration: " + DateOfRegistration;
        }

    }
}
