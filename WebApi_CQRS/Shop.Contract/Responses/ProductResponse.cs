using Shop.Data.Entites;

namespace Shop.Contract.Responses
{
    public class ProductResponse
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public Category Category { get; set; }
    }
}
