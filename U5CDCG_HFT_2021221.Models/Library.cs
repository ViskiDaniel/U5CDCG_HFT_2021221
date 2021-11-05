using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U5CDCG_HFT_2021221.Models
{
    [Table("Library")]
    class Library
    {
        [ForeignKey(nameof(Books))]
        public int BookId { get; set; }
        [ForeignKey(nameof(Customers))]
        public int CustomerId { get; set; }

        [NotMapped]
        public virtual Books Book { get; set; }
        [NotMapped]
        public virtual Customers Customer { get; set; }

        public DateTime StartofRental { get; set; }
        public DateTime EndofRental { get; set; }

    }
}
