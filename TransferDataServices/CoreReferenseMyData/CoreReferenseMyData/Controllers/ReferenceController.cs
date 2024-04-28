using CoreReference.Contracts.Requests;
using CoreReference.Contracts.Responses;
using CoreReference.Service;
using CoreReference.Service.Commands;
using Microsoft.AspNetCore.Mvc;


namespace CoreReferenseMyData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReferenceDataController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> PostSubscribeFilmsIdAsync([FromServices] IRequestHandler<PostSubscribeFilm, SubscribeFilmsResponse> postSubscribeFilmCommand, [FromBody] SubscribeFilmsRequest request)
        {
            var subscribeFilm = await postSubscribeFilmCommand.Handle(new PostSubscribeFilm
            {
                Id = request.Id,
                SubscribeFilmsData = request.SubscribeFilms,
            });

            return Ok(subscribeFilm);
        }

        [HttpPut]
        public async Task<IActionResult> PutSubscribeFilmsIdAsync([FromServices] IRequestHandler<PutSubscribeFilmCommand, SubscribeFilmsResponse> putSubscribeFilmCommand, [FromBody] SubscribeFilmsRequest request)
        {
            var subscribeFilm = await putSubscribeFilmCommand.Handle(new PutSubscribeFilmCommand
            {
                Id = request.Id,
                SubscribeFilmsData = request.SubscribeFilms,
            });

            return Ok(subscribeFilm);
        }

        [HttpGet("{SubscribeFilmsId}")]
        public async Task<IActionResult> GetSubscribeFilmsIdByIdAsync(int SubscribeFilmsId, [FromServices] IRequestHandler<int, SubscribeFilmsResponse> getSubscribeFilmByIdQuery)
        {
            return Ok(await getSubscribeFilmByIdQuery.Handle(SubscribeFilmsId));
        }

    }
}
