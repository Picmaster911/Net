using Microsoft.EntityFrameworkCore;
using Shop.Contract.Responses;
using Shop.Data.Context;
using Shop.Data.Entites;

namespace Shop.Service.Commands.Customers
{
    public class PutCustomerCommand
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }

    }

    public class PutCustomerCommandHandler : IRequestHandler<PutCustomerCommand, CustomerResponse>
    {
        private readonly ShopContext _context;
        public PutCustomerCommandHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<CustomerResponse> Handle(PutCustomerCommand request, CancellationToken cancellationToken = default)
        {
            var customerForPut = await GetCategoryAsync(request.CustomerId, cancellationToken);
            if (customerForPut != null)
            {
                if (customerForPut.CustomerName != null)
                    customerForPut.CustomerName = request.CustomerName;
                if (customerForPut.CustomerSurname != null)
                    customerForPut.CustomerSurname = request.CustomerSurname;

                _context.SaveChanges();

            }
            return new CustomerResponse
            {
                CustomerId = request.CustomerId,
                CustomerName = request.CustomerName,
                CustomerSurname = request.CustomerSurname,
            };
        }
        private async Task<Customer> GetCategoryAsync(int CustomerId, CancellationToken cancellationToken = default)
        {
            return await _context.Customers.SingleOrDefaultAsync(x => x.CustomerId == CustomerId, cancellationToken);
        }
    }
}
