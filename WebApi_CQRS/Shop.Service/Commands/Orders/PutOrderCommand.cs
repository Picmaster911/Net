using Microsoft.EntityFrameworkCore;
using Shop.Contract.Responses;
using Shop.Data.Context;
using Shop.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Service.Commands.Orders
{
    public class PutOrderCommand
    {
        public int OrderId { get; set; }
        public Customer CustomerOrder { get; set; }
        public Product ProductOrder { get; set; }

    }

    public class PutOrderCommandHandler : IRequestHandler<PutOrderCommand, OrderResponse>
    {
        private readonly ShopContext _context;
        public PutOrderCommandHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<OrderResponse> Handle(PutOrderCommand request, CancellationToken cancellationToken = default)
        {
            var orderForPut = await GetOrderAsync(request.OrderId, cancellationToken);
            if (orderForPut != null)
            {
                if (orderForPut.CustomerOrder != null)
                    orderForPut.CustomerOrder = request.CustomerOrder;
                if (orderForPut.ProductOrder != null)
                    orderForPut.ProductOrder = request.ProductOrder;

                _context.SaveChanges();

            }
            return new OrderResponse
            {
                OrderId = request.OrderId,
                CustomerOrder = request.CustomerOrder,
                ProductOrder = request.ProductOrder,
            };
        }
        private async Task<Order> GetOrderAsync(int OrderId, CancellationToken cancellationToken = default)
        {
            return await _context.Orders.SingleOrDefaultAsync(x => x.OrderId == OrderId, cancellationToken);
        }
    }
}
