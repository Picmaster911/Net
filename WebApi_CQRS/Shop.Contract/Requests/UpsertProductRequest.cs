using Shop.Data.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Contract.Requests
{
    public class UpsertProductRequest
    {
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        public  Category Category { get; set; }
    }
}
