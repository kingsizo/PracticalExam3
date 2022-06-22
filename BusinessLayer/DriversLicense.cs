using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class DriversLicense
    {
        [Key]
        
        public string ID { get; set; }

        [Required]
        
        public string FullName { get; set; }

        [Required]
        
        public string EGN { get; set; }

        private DriversLicense() { }

        public DriversLicense(string fullname, string egn)
        {
            ID = Guid.NewGuid().ToString();
            FullName = fullname;
            EGN = egn;
        }
        public DriversLicense(string id, string fullname, string egn)
        {
            ID = id;
            FullName = fullname;
            EGN = egn;
        }

        public override string ToString()
        {
            return "ID: " + ID + " Full Name: " + FullName + " EGN: " + EGN;
        }

    }
}
