using Application.ProductFeatures.Commands;
using Application.ProductFeatures.Queires;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MovieManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetSessionAsync()
        {
            return Ok(await Mediator.Send(new GetSessionsQuery()));
        }

        [HttpPost]
        public async Task<IActionResult> UpserSessionAsync(UpsertSessionCommand cmd)
        {
            return Ok(await Mediator.Send(cmd));
        }
    }
}
