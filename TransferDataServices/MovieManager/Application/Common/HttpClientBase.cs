using Polly;
using System.Text;

namespace MovieManager.Service.Common
{
    public abstract class HttpClientBase
    {
        public static async Task<RequestResult<T>> Put<T>(HttpClient httpClient, Uri uri, string content)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, uri)
            {
                Content = new StringContent(content, Encoding.UTF8, "application/json")
            };

            const int maxRetryAttempts = 5;
            var retryPolicy = Policy
                .Handle<HttpRequestException>()
                .WaitAndRetryAsync(maxRetryAttempts, i => TimeSpan.FromSeconds(i * 5));

            var result = new RequestResult<T>();
            try
            {
                await retryPolicy.ExecuteAsync(async () =>
                {
                    var response = await httpClient.SendAsync(request);
                    response.EnsureSuccessStatusCode();
                    result.Value = await response.Content.ReadAsAsync<T>();
                });

                result.Stop();
                return result;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
                result.Stop();
                return result;
            }
        }
        public static async Task<RequestResult<T>> Post<T>(HttpClient httpClient, Uri uri, string content)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, uri)
            {
                Content = new StringContent(content, Encoding.UTF8, "application/json")
            };

            const int maxRetryAttempts = 5;
            var retryPolicy = Policy
                .Handle<HttpRequestException>()
                .WaitAndRetryAsync(maxRetryAttempts, i => TimeSpan.FromSeconds(i * 5));

            var result = new RequestResult<T>();
            try
            {
                await retryPolicy.ExecuteAsync(async () =>
                {
                    var response = await httpClient.SendAsync(request);
                    response.EnsureSuccessStatusCode();
                    result.Value = await response.Content.ReadAsAsync<T>();
                });

                result.Stop();
                return result;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
                result.Stop();
                return result;
            }
        }

        public static async Task<RequestResult<T>> Get<T>(HttpClient httpClient, Uri uri)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            var realPositionImpuls = 1;
            var posRampTemp = 1;
            var realZadanie = 1;
            var posRampZadanieVImpuls = 1;
            var ShagRamp = 1;
            var i = 1;

            if (realPositionImpuls < posRampZadanieVImpuls && realPositionImpuls < posRampTemp)
            {
                posRampTemp = posRampZadanieVImpuls - i;
                ShagRamp = realZadanie / posRampZadanieVImpuls;
               
                if (realPositionImpuls < posRampTemp)
                {
                    realZadanie = realZadanie - ShagRamp;
                    i++;
                }                   
            }
            else 
            {
                i = 1;
                posRampTemp = posRampZadanieVImpuls;
            }
               


            const int maxRetryAttempts = 5;
            var retryPolicy = Policy
                .Handle<HttpRequestException>()
                .WaitAndRetryAsync(maxRetryAttempts, i => TimeSpan.FromSeconds(i * 5));

            var result = new RequestResult<T>();
            try
            {
                await retryPolicy.ExecuteAsync(async () =>
                {
                    var response = await httpClient.SendAsync(request);
                    response.EnsureSuccessStatusCode();

                    result.Value = await response.Content.ReadAsAsync<T>();
                });

                result.Stop();
                return result;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
                result.Stop();
                return result;
            }
        }

       
    }
}

