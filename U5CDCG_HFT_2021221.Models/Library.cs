using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace U5CDCG_HFT_2021221.Models
{
    [Table("Library")]
    public class Library
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ActionID { get; set; }
        [ForeignKey(nameof(Models.Book))]
        public int BookId { get; set; }
        [ForeignKey(nameof(Models.Customer))]
        public int CustomerId { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual Book Book { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual Customer Customer { get; set; }

    }
}
