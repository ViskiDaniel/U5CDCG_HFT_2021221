using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U5CDCG_HFT_2021221.Models
{
    public class Owner
    {
        [Key]
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public bool HasInsurance { get; set; } 

        [ForeignKey(nameof(Cars))]
        public int Car_Identifier { get; set; }
    }
}
