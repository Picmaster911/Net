using Shop.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Contract.Requests
{
    public class OrderRequest
    {
        public int OrderId { get; set; }
        public Customer CustomerOrder { get; set; }
        public Product ProductOrder { get; set; }
    }
}
