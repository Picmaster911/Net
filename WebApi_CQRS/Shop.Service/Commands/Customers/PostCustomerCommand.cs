using Microsoft.EntityFrameworkCore;
using Shop.Contract.Responses;
using Shop.Data.Context;
using Shop.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Service.Commands.Customers
{
    public class PostCustomerCommand
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }

        public Customer CreateCustomer()
        {
            var customer = new Customer
            {
                CustomerId = CustomerId,
                CustomerName = CustomerName,
                CustomerSurname = CustomerSurname,
            };
            return customer;
        }
    }
    public class PostCategoryCommandHandler : IRequestHandler<PostCustomerCommand, CustomerResponse>
    {
        private readonly ShopContext _context;
        public PostCategoryCommandHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<CustomerResponse> Handle(PostCustomerCommand request, CancellationToken cancellationToken = default)
        {
            var customerForPost = request.CreateCustomer();
            await _context.Customers.AddAsync(customerForPost, cancellationToken);
            _context.SaveChanges();
            var lastCustomer = await GetLastCategoryesAsync();
            
            return new CustomerResponse
            {
                CustomerId = lastCustomer.CustomerId,
                CustomerName = request.CustomerName,
                CustomerSurname = request.CustomerSurname,  
            };
        }

        public async Task<Customer> GetLastCategoryesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Customers.OrderByDescending(c => c.CustomerId).FirstOrDefaultAsync();
        }
    }
}
