using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MovieManager.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[Controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetMoviesAsync(GetMoviesQuery getMovie)
        {
            return Ok(await Mediator.Send(new getMoviesQuery()));
        }

        [HttpGet("{movieId}")]
        public async Task<IActionResult> GetMovieByIdAsync(int movieId, [FromServices] IRequestHandler<int, MovieResponse> getMovieByIdQuery)
        {
            return Ok(await getMovieByIdQuery.Handle(movieId));
        }

        [HttpPost]
        public async Task<IActionResult> UpserMovieAsync([FromServices] IRequestHandler<UpsertMovieCommand, MovieResponse> upsertMovieCommand, [FromBody] UpsertMovieRequest request)
        {
            var movie = await upsertMovieCommand.Handle(new UpsertMovieCommand
            {
                MovieId = request.MovieId,
                Title = request.Title,
                Description = request.Description,
                ReleaseDate = request.ReleaseDate
            });

            return Ok(movie);
        }

        [HttpDelete("{movieId}")]
        public async Task<IActionResult> DeleteMovieById(int movieId, [FromServices] IRequestHandler<DeleteMovieCommand, bool> deleteMovieByIdCommand)
        {
            var result = await deleteMovieByIdCommand.Handle(new DeleteMovieCommand { MovieId = movieId });

            if (result)
            {
                return Ok(result);
            }

            return NotFound();
        }
    }
}
