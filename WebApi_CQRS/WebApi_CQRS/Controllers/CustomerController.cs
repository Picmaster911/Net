using Shop.Contract.Responses;
using Microsoft.AspNetCore.Mvc;
using Shop.Service.Commands.Categorys;
using Shop.Service;
using Shop.Contract.Requests;
using Shop.Service.Commands.Customers;



namespace WebApi_CQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [HttpDelete("{CustomerId}")]
        public async Task<IActionResult> DeleteCustomerById(int CustomerId, [FromServices] IRequestHandler<DeleteCustomerCommand, bool> deleteCustomerCommand)
        {
            var result = await deleteCustomerCommand.Handle(new DeleteCustomerCommand { CustomerId = CustomerId });

            if (result)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> PostCustomerAsync([FromServices] IRequestHandler<PostCustomerCommand, CustomerResponse> postCustomerCommand, [FromBody] CustomerRequest request)
        {
            var category = await postCustomerCommand.Handle(new PostCustomerCommand
            {
                CustomerId = request.CustomerId,
                CustomerName = request.CustomerName,
                CustomerSurname = request.CustomerSurname,
            });

            return Ok(category);
        }

        [HttpPut]
        public async Task<IActionResult> PutCustomerAsync([FromServices] IRequestHandler<PutCustomerCommand, CustomerResponse> putCustomerCommand, [FromBody] CustomerRequest request)
        {
            var category = await putCustomerCommand.Handle(new PutCustomerCommand
            {
                CustomerId = request.CustomerId,
                CustomerName = request.CustomerName,
                CustomerSurname = request.CustomerSurname,
            });

            return Ok(category);
        }

        [HttpGet("{CustomerId}")]
        public async Task<IActionResult> GetCustomerByIdAsync(int CustomerId, [FromServices] IRequestHandler<int, CustomerResponse> getCustomerByIdQuery)
        {
            return Ok(await getCustomerByIdQuery.Handle(CustomerId));
        }

    }
}
