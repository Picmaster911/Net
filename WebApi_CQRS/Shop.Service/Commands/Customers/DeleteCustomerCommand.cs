using Microsoft.EntityFrameworkCore;
using Shop.Data.Context;
using Shop.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Service.Commands.Customers
{
    public class DeleteCustomerCommand
    {
        public int CustomerId { get; set; }
    }

    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, bool>
    {
        private readonly ShopContext _context;
        public DeleteCustomerCommandHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken = default)
        {
            var customerForDelete = await GetCustomerAsync(request.CustomerId, cancellationToken);
            if (customerForDelete != null)
            {
                _context.Remove(customerForDelete);
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;
        }
        private async Task<Customer> GetCustomerAsync(int customerId, CancellationToken cancellationToken = default)
        {
            return await _context.Customers.SingleOrDefaultAsync(x => x.CustomerId == customerId, cancellationToken);
        }
    }
}