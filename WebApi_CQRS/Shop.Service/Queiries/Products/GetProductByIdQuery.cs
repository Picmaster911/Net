using Azure;
using Microsoft.EntityFrameworkCore;
using Shop.Contract.Responses;
using Shop.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Service.Queiries.Products
{
    public class GetProductByIdQuery : IRequestHandler < int,ProductResponse>
    {
        private readonly ShopContext _context;
        public GetProductByIdQuery(ShopContext context)
        {
            _context = context;
        }

        public async Task<ProductResponse> Handle(int productId, CancellationToken cancellationToken = default)
        {
            return await _context.Products
                .AsNoTracking()
                .Where(x => x.ProductId == productId)
                .Select(x => new ProductResponse
                {
                    ProductId = x.ProductId,
                    ProductName = x.ProductName,
                })
                .SingleOrDefaultAsync(cancellationToken);
        }
    }
}
