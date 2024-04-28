using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MovieManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReferenceDataController : ControllerBase
	{
		private readonly IRefDataService _refDataService;

		public ReferenceDataController(IRefDataService refDataService)
		{
			_refDataService = refDataService;
		}

        [HttpGet("{subscribeFilmsId}")]
        public async Task<IActionResult> GetSubscribeFilmAsync(int subscribeFilmsId)
		{
			return Ok(await _refDataService.GetData(subscribeFilmsId));
		}

		[HttpPost]
		public async Task<IActionResult> PostSubscribeFilmAsync([FromBody] SubscribeFilm subscribeFilm)
		{
			var test = await _refDataService.PostData(subscribeFilm);
			return Ok(test);
		}

        [HttpPut("{subscribeFilmsId}")]
        public async Task<IActionResult> PutSubscribeFilmAsync([FromBody] SubscribeFilm subscribeFilm)
        {
            return Ok(await _refDataService.PutData(subscribeFilm));
        }
    }
}
