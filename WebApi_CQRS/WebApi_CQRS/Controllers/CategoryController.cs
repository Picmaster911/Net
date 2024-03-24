using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Contract.Requests;
using Shop.Contract.Responses;
using Shop.Service;
using Shop.Service.Commands.Categorys;

namespace WebApi_CQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        // DELETE api/<ProductController>/5
        [HttpDelete("{CategoryId}")]
        public async Task<IActionResult> DeleteCategoryById(int CategoryId, [FromServices] IRequestHandler<DeleteCategoryCommand, bool> deleteCategoryByIdCommand)
        {
            var result = await deleteCategoryByIdCommand.Handle(new DeleteCategoryCommand { CategoryId = CategoryId });

            if (result)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> PostCategoryAsync([FromServices] IRequestHandler<PostCaregoryCommand, CategoryResponse> postCategoryCommand, [FromBody] CategoryRequest request)
        {
            var category = await postCategoryCommand.Handle(new PostCaregoryCommand
            {
                CategoryId = request.CategoryId,
                CategoryName = request.CategoryName, 
            });

            return Ok(category);
        }

        [HttpPut]
        public async Task<IActionResult> PutCategoryAsync([FromServices] IRequestHandler<PutCaregoryCommand, CategoryResponse> putCategoryCommand, [FromBody] CategoryRequest request)
        {
            var category = await putCategoryCommand.Handle(new PutCaregoryCommand
            {
                CategoryId = request.CategoryId,
                CategoryName = request.CategoryName,
            });

            return Ok(category);
        }

        [HttpGet("{CategoryId}")]
        public async Task<IActionResult> GetCustomerByIdAsync(int CategoryId, [FromServices] IRequestHandler<int, CategoryResponse> getCategoryByIdQuery)
        {
            return Ok(await getCategoryByIdQuery.Handle(CategoryId));
        }

    }
}
