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
    public class PostOrderCommand
    {

        public int OrderId { get; set; }
        public Customer CustomerOrder { get; set; }
        public Product ProductOrder { get; set; }

        public Order CreateOrder()
        {
            var order = new Order
            {
                OrderId = OrderId,
                CustomerOrder = CustomerOrder,
                ProductOrder = ProductOrder
            };
            return order;
        }
    }
    public class PostOrderCommandHandler : IRequestHandler<PostOrderCommand, OrderResponse>
    {
        private readonly ShopContext _context;
        public PostOrderCommandHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<OrderResponse> Handle(PostOrderCommand request, CancellationToken cancellationToken = default)
        {
            var orderForPost = request.CreateOrder();
            await _context.Orders.AddAsync(orderForPost, cancellationToken);
            _context.SaveChanges();
            var lastOrder = await GetLastOrderAsync();

            return new OrderResponse
            {
                OrderId = lastOrder.OrderId,
                CustomerOrder = request.CustomerOrder,
                ProductOrder = request.ProductOrder,
            };
        }

        public async Task<Order> GetLastOrderAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Orders.OrderByDescending(c => c.OrderId).FirstOrDefaultAsync();
        }
    }
}
