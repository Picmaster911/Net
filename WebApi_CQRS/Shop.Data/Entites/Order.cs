﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Entites
{
    [Table("Order")]
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public virtual Customer CustomerOrder { get; set; }
        public virtual Product ProductOrder { get; set; }
      
    }
}
