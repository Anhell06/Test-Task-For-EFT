using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Test_Task.JsonModel.Image;

namespace Test_Task
{
    public class WeatherImageLoader : ITextLoader
    {

        public async Task<string> GetDataAsync(CancellationTokenSource token)
        {
            try
            {

                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://bing-image-search1.p.rapidapi.com/images/search?q=clear&sky"),
                    Headers =
                {
                    { "x-rapidapi-host", "bing-image-search1.p.rapidapi.com" },
                    { "x-rapidapi-key", "00f2a07dc4mshe9ed82422cc1a5dp124dc8jsnf73f410bbd77" },
                },
                };

                string body;

                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    body = await response.Content.ReadAsStringAsync();
                }


                return ParsToJSON(body).value[0].contentUrl;

            }
            catch (OperationCanceledException)
            {

                throw;
            }
        }
        private ImageRoot ParsToJSON(string body)
        {
            var deserializator = JsonConvert.DeserializeObject<ImageRoot[]>("[" + body + "]");
            return deserializator[0];
        }
    }
}
