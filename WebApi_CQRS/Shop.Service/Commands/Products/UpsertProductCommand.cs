using Microsoft.EntityFrameworkCore;
using Shop.Contract.Responses;
using Shop.Data.Context;
using Shop.Data.Entites;

namespace Shop.Service.Commands.Products
{
    public class UpsertProductCommand
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }
        public Category Category { get; set; }

        public Product UpsertProduct()
        {
            var product = new Product
            {
                ProductId = ProductId,
                ProductName = ProductName,
                Category = Category
            };
            return product;
        }
    }
    public class UpsertProductCommandHandler : IRequestHandler<UpsertProductCommand, ProductResponse>
    {
        private readonly ShopContext _context;
        public UpsertProductCommandHandler(ShopContext context)
        {
            _context = context;
        }
        public async Task<ProductResponse> Handle(UpsertProductCommand request, CancellationToken cancellationToken = default)
        {
            var product = await GetSessionAsync(request.ProductId, cancellationToken);

            if (product == null)
            {
                product = request.UpsertProduct();
                await _context.AddAsync(product, cancellationToken);
            }

            product.ProductId = request.ProductId;
            product.ProductName = request.ProductName;
            product.Category = request.Category;
            await _context.SaveChangesAsync(cancellationToken);

            return new ProductResponse
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                Category = product.Category,
            };
        }

        private async Task <Product> GetSessionAsync(int productId, CancellationToken cancellationToken = default)
        {
            return await _context.Products.SingleOrDefaultAsync(x => x.ProductId == productId, cancellationToken);
        }
    }
    
}
