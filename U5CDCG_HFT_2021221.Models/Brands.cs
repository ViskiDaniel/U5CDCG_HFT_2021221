using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U5CDCG_HFT_2021221.Models
{
    class Brands
    {
        [Key]
        public string Name { get; set; }
        public string Country { get; set; }
        public int? Since { get; set; }
        public List<string> Factories { get; set; }
    }
}
