using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U5CDCG_HFT_2021221.Models
{
    public class Cars
    {
        [Key]
        public int Chassis_Number { get; set; }
        [ForeignKey(nameof(Brands))]
        public string Brand { get; set; }
        public string Type { get; set; }
        public int Produce_Year { get; set; }
                
    }
}
