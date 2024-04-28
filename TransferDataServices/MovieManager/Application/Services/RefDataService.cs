using Domain.Entities;
using Microsoft.Extensions.Configuration;
using MovieManager.Service.Common;
using Newtonsoft.Json;

namespace Application.Services
{
	public interface IRefDataService
	{
		Task <SubscribeFilm> GetData(int subscribeFilmsId);
		Task <SubscribeFilm> PostData(SubscribeFilm subscribeFilm);
        Task <SubscribeFilm> PutData(SubscribeFilm subscribeFilm);
    }

	public class RefDataService : HttpClientBase, IRefDataService
	{
		private readonly HttpClient _httpClient;
		private readonly IConfiguration _configuration;

		public RefDataService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
		{
			_httpClient = httpClientFactory.CreateClient();
			_configuration = configuration;
		}

		public async Task<SubscribeFilm> GetData(int subscribeFilmsId	)
		{
			var endpoint = $"{_configuration.GetSection("RefDataEndpoints:PathEndpoints").Value}/{subscribeFilmsId}";
			return (await Get <SubscribeFilm> (_httpClient, new Uri(endpoint))).Value;
		}

		public async Task<SubscribeFilm> PostData(SubscribeFilm subscribeFilm)
		{
			var endpoint = _configuration.GetSection("RefDataEndpoints:PathEndpoints").Value;
			var body = JsonConvert.SerializeObject(subscribeFilm);
			return (await Post <SubscribeFilm>(_httpClient, new Uri(endpoint), body)).Value;
		}

        public async Task<SubscribeFilm> PutData(SubscribeFilm subscribeFilm)
        {
            var endpoint = _configuration.GetSection("RefDataEndpoints:PathEndpoints").Value;
            var body = JsonConvert.SerializeObject(subscribeFilm);
            return (await Put <SubscribeFilm> (_httpClient, new Uri(endpoint), body)).Value;
        }
    }
}
