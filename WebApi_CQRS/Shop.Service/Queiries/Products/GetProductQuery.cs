using Microsoft.EntityFrameworkCore;
using Shop.Contract.Responses;
using Shop.Data.Context;

namespace Shop.Service.Queiries.Products
{
    internal class GetProductQueryHandler : IRequestHandler<IList<ProductResponse>>
    {
        private readonly ShopContext _context;

        public GetProductQueryHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<IList<ProductResponse>> Handle(CancellationToken cancellationToken = default)
        {
            return await _context.Products
                .AsNoTracking()
                .Select(x => new ProductResponse
                {
                    ProductId = x.ProductId,
                    ProductName = x.ProductName,

                })
                .OrderByDescending(x => x.ProductId)
                .ToListAsync(cancellationToken);
        }
    }
}
