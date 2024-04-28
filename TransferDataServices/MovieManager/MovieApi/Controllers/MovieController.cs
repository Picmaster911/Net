using Application.ProductFeatures.Commands;
using Application.ProductFeatures.Queires;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MovieApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetMoviesAsync()
        {
            return Ok(await Mediator.Send(new GetMoviesQuery()));
        }

        [HttpGet("{movieId}")]
        public async Task<IActionResult> GetMovieByIdAsync(int movieId)
        {
            try
            {
                var result = await Mediator.Send(new GetMovieByIdQuery { MovieId = movieId });

                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpserMovieAsync(UpsertMovieCommand cmd)
        {
            return Ok(await Mediator.Send(cmd));
        }

        [HttpDelete("{movieId}")]
        public async Task<IActionResult> DeleteMovieById(int movieId)
        {
            try
            {
                var result = await Mediator.Send(new DeleteMovieCommand { MovieId = movieId });

                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
