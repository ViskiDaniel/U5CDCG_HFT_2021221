using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U5CDCG_HFT_2021221.Models
{
    class Cars
    {
        [Key]
        public string Brand { get; set; }
        public string Type { get; set; }
        public int? ProduceYear { get; set; }


        //Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\U5CDCG_HFT_2021221_Database.mdf;Integrated Security=True
    }
}
