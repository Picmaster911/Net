using Microsoft.EntityFrameworkCore;
using Shop.Data.Context;
using Shop.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Service.Commands.Orders
{
    public class DeleteOrderCommand
    {
        public int OrderId { get; set; }
    }

    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, bool>
    {
        private readonly ShopContext _context;
        public DeleteOrderCommandHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteOrderCommand request, CancellationToken cancellationToken = default)
        {
            var orderForDelete = await GetOrderAsync(request.OrderId, cancellationToken);
            if (orderForDelete != null)
            {
                _context.Remove(orderForDelete);
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;
        }
        private async Task<Order> GetOrderAsync(int orderId, CancellationToken cancellationToken = default)
        {
            return await _context.Orders.SingleOrDefaultAsync(x => x.OrderId == orderId, cancellationToken);
        }
    }
}
