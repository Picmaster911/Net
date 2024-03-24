using Microsoft.EntityFrameworkCore;
using Shop.Contract.Responses;
using Shop.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Service.Queiries.Order
{
    internal class GetOrdertByIdQuery: IRequestHandler<int, OrderResponse>
    {
      
            private readonly ShopContext _context;
            public GetOrdertByIdQuery(ShopContext context)
            {
                _context = context;
            }
            public async Task<OrderResponse> Handle(int orderId, CancellationToken cancellationToken = default)
            {
                return await _context.Orders
                    .AsNoTracking()
                    .Where(x => x.OrderId == orderId)
                    .Select(x => new OrderResponse
                    {
                        OrderId = x.OrderId,
                        CustomerOrder = x.CustomerOrder,
                        ProductOrder = x.ProductOrder,
                    })
                    .SingleOrDefaultAsync(cancellationToken);
            }        
    }
}
