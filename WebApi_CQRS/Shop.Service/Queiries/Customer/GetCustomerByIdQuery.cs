using Microsoft.EntityFrameworkCore;
using Shop.Contract.Responses;
using Shop.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Service.Queiries.Customer
{
    public class GetCustomerByIdQuery: IRequestHandler<int, CustomerResponse>
    {

        private readonly ShopContext _context;
        public GetCustomerByIdQuery(ShopContext context)
        {
            _context = context;
        }
        public async Task<CustomerResponse> Handle(int customerId, CancellationToken cancellationToken = default)
        {
            return await _context.Customers
                .AsNoTracking()
                .Where(x => x.CustomerId == customerId)
                .Select(x => new CustomerResponse
                {
                    CustomerId = x.CustomerId,
                    CustomerName = x.CustomerName,
                    CustomerSurname = x.CustomerSurname,
                })
                .SingleOrDefaultAsync(cancellationToken);
        }

    }
}
