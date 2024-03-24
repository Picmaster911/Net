using Microsoft.EntityFrameworkCore;
using Shop.Data.Context;
using Shop.Data.Entites;
using Shop.Contract.Responses;

namespace Shop.Service.Commands.Categorys
{
    public class PostCaregoryCommand
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public Category CreateCategory()
        {
            var category = new Category
            {
                CategoryId = CategoryId,
                CategoryName = CategoryName,
            };
            return category;
        }
    }
    public class PostCategoryCommandHandler : IRequestHandler<PostCaregoryCommand, CategoryResponse>
    {
        private readonly ShopContext _context;
        public PostCategoryCommandHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<CategoryResponse> Handle(PostCaregoryCommand request, CancellationToken cancellationToken = default)
        {
            var categoryForPost = request.CreateCategory();
            await _context.Categorys.AddAsync(categoryForPost, cancellationToken);
            _context.SaveChanges();
            var lastCategory = await GetLastCategoryesAsync();
           
            return new CategoryResponse
            {
                CategoryId = lastCategory.CategoryId,
                CategoryName = request.CategoryName,
            };
        }

        public async Task<Category> GetLastCategoryesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Categorys.OrderByDescending(c => c.CategoryId).FirstOrDefaultAsync();
        }
    }
}
