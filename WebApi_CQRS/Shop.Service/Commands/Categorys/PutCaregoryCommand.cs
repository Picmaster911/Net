using Microsoft.EntityFrameworkCore;
using Shop.Contract.Responses;
using Shop.Data.Context;
using Shop.Data.Entites;

namespace Shop.Service.Commands.Categorys
{

    public class PutCaregoryCommand
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

      }

    public class PutCategoryCommandHandler : IRequestHandler<PutCaregoryCommand, CategoryResponse>
    {
        private readonly ShopContext _context;
        public PutCategoryCommandHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<CategoryResponse> Handle(PutCaregoryCommand request, CancellationToken cancellationToken = default)
        {
            var categoryForPost = await GetCategoryAsync(request.CategoryId, cancellationToken);
            if (categoryForPost != null)
            {
                if (categoryForPost.CategoryName != null)
                    categoryForPost.CategoryName = request.CategoryName;
               
                _context.SaveChanges();

            }
            return new CategoryResponse
            {
                CategoryId = request.CategoryId,
                CategoryName = request.CategoryName,
            };
        }
        private async Task<Category> GetCategoryAsync(int categoryId, CancellationToken cancellationToken = default)
        {
            return await _context.Categorys.SingleOrDefaultAsync(x => x.CategoryId == categoryId, cancellationToken);
        }
    }
}
