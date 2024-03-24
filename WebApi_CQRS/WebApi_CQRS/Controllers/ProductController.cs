using Microsoft.AspNetCore.Mvc;
using Shop.Contract.Responses;
using Shop.Contract.Requests;
using Shop.Data.Entites;
using Shop.Service;
using Shop.Service.Commands.Products;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi_CQRS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        // GET: api/<ProductController>
        [HttpGet]
        public async Task<IActionResult> GetProductSAsync([FromServices] IRequestHandler<IList<ProductResponse>> getProductQuery)
        {
            return Ok(await getProductQuery.Handle());
        }

        // GET api/<ProductController>/5
        [HttpGet("{ProductId}")]
        public async Task<IActionResult> GetProductByIdAsync(int ProductId,[FromServices] IRequestHandler<int, ProductResponse> getProductByIdQuery)
        {
            return Ok(await getProductByIdQuery.Handle(ProductId));
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<IActionResult> UpserMovieAsync([FromServices] IRequestHandler<UpsertProductCommand, ProductResponse> upsertProductCommand, [FromBody] UpsertProductRequest request)
        {
            var product = await upsertProductCommand.Handle(new UpsertProductCommand
            {
                ProductId = request.ProductId,
                ProductName = request.ProductName,
                Category = request.Category,
            });

            return Ok(product);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{ProductId}")]
        public async Task<IActionResult> DeleteProductById(int ProductId, [FromServices] IRequestHandler<DeleteProductCommand, bool> deleteMovieByIdCommand)
        {
            var result = await deleteMovieByIdCommand.Handle(new DeleteProductCommand { ProductId = ProductId });

            if (result)
            {
                return Ok(result);
            }
            return NotFound();
        }
    }
}
