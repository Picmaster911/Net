using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Entites
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        [StringLength(255)]
        public string CustomerName { get; set; }
        [Required]
        [StringLength(255)]
        public string CustomerSurname { get; set; }

    }
}
