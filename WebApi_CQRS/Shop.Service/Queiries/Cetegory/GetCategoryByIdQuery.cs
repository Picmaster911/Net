using Microsoft.EntityFrameworkCore;
using Shop.Contract.Responses;
using Shop.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Service.Queiries.Cetegory
{
    internal class GetCategoryByIdQuery : IRequestHandler<int, CategoryResponse>
    {
        private readonly ShopContext _context;
        public GetCategoryByIdQuery(ShopContext context)
        {
            _context = context;
        }

        public async Task<CategoryResponse> Handle(int categoryId, CancellationToken cancellationToken = default)
        {
            return await _context.Categorys
                .AsNoTracking()
                .Where(x => x.CategoryId == categoryId)
                .Select(x => new CategoryResponse
                {
                    CategoryId = x.CategoryId,
                    CategoryName = x.CategoryName,
                })
                .SingleOrDefaultAsync(cancellationToken);
        }
    }
}
