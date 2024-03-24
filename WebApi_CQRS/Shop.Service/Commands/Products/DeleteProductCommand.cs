using Microsoft.EntityFrameworkCore;
using Shop.Data.Context;
using Shop.Data.Entites;


namespace Shop.Service.Commands.Products
{
    public class DeleteProductCommand
    {
        public int ProductId { get; set; }
       
    }
    public class DeleteMovieCommandHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly ShopContext _context;
        public DeleteMovieCommandHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken = default)
        {
            var productForDelete  = await GetProductAsync(request.ProductId,cancellationToken); 
            if (productForDelete != null)
            {
                _context.Remove(productForDelete);
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;
        }
        private async Task<Product> GetProductAsync(int productId, CancellationToken cancellationToken = default)
        {
            return await _context.Products.SingleOrDefaultAsync(x => x.ProductId == productId, cancellationToken);
        }
    }
}
