using Microsoft.EntityFrameworkCore;
using Shop.Data.Context;
using Shop.Data.Entites;


namespace Shop.Service.Commands.Categorys
{
    public class DeleteCategoryCommand
    {
        public int CategoryId { get; set; }
    }

    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, bool>
    {
        private readonly ShopContext _context;
        public DeleteCategoryCommandHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken = default)
        {
            var categoryForDelete = await GetCategoryAsync(request.CategoryId, cancellationToken);
            if (categoryForDelete != null)
            {
                _context.Remove(categoryForDelete);
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;
        }
        private async Task<Category> GetCategoryAsync(int categoryId, CancellationToken cancellationToken = default)
        {
            return await _context.Categorys.SingleOrDefaultAsync(x => x.CategoryId == categoryId, cancellationToken);
        }
    }
}
