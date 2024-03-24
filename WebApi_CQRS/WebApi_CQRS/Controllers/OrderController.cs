using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Contract.Requests;
using Shop.Contract.Responses;
using Shop.Service.Commands.Customers;
using Shop.Service;
using Shop.Service.Commands.Orders;

namespace WebApi_CQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        [HttpDelete("{OrderId}")]
        public async Task<IActionResult> DeleteOrderById(int OrderId, [FromServices] IRequestHandler<DeleteOrderCommand, bool> deleteOrderCommand)
        {
            var result = await deleteOrderCommand.Handle(new DeleteOrderCommand { OrderId = OrderId });

            if (result)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> PostOrderAsync([FromServices] IRequestHandler<PostOrderCommand, OrderResponse> postOrderCommand, [FromBody] OrderRequest request)
        {
            var order = await postOrderCommand.Handle(new PostOrderCommand
            {
                OrderId = request.OrderId,
                CustomerOrder = request.CustomerOrder,
                ProductOrder = request.ProductOrder,
            });

            return Ok(order);
        }

        [HttpPut]
        public async Task<IActionResult> PutOrderAsync([FromServices] IRequestHandler<PutOrderCommand, OrderResponse> putOrderCommand, [FromBody] OrderRequest request)
        {
            var order = await putOrderCommand.Handle(new PutOrderCommand
            {
                OrderId = request.OrderId,
                CustomerOrder = request.CustomerOrder,
                ProductOrder = request.ProductOrder,
            });

            return Ok(order);
        }

        [HttpGet("{OrderId}")]
        public async Task<IActionResult> GetOrderByIdAsync(int OrderId, [FromServices] IRequestHandler<int, OrderResponse> getOrderByIdQuery)
        {
            return Ok(await getOrderByIdQuery.Handle(OrderId));
        }

    }
}
