using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class KAT
    {
        [Key]
        public int KatID { get; set; }

        [Required]
        public string City { get; set; }

        private KAT()
        {
            
        }
           
        public KAT(string city)
        {
            Random s = new Random();
            int num = s.Next();
            
            City = city;
        }
        public KAT(int id, string city)
        {
            KatID = id;
            City = city;
        }

        public override string ToString()
        {
            return "KatID: " + KatID + " City: " + City;
        }
    }
}
