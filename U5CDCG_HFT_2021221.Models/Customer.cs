using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U5CDCG_HFT_2021221.Models
{
    [Table("Customers")]
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public bool Gender { get; set; }
        [Required]
        [MaxLength(32)]
        public string Email { get; set; }

        [NotMapped]
        public virtual ICollection<Library> Library { get; set; }

        public override string ToString()
        {
            return CustomerId + " - " + Name + " - " + Age + " - " + newValue(Gender) + " - " + Email; ;
        }

        static string newValue(bool value)
        {
            if (value)
            {
                return "Férfi";
            }
            else
            {
                return "Nő";
            }
        }
    }
}
