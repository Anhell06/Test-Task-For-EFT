using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Test_Task.JsonModel.Image;

namespace Test_Task
{
    public class WeatherImageLoader : ITextLoader
    {
        private string URL;

        public WeatherImageLoader()
        {
            this.URL = Settings.ImageURLApi;
        }

        public async Task<string> GetDataAsync(params string[] parametrs)
        {
            var sb = new StringBuilder();
            foreach (var param in parametrs)
            {
                sb.Append($"?{param}");
            }
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {

                Method = HttpMethod.Get,
                RequestUri = new Uri($"{URL}{sb.ToString()}"),
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
        private ImageRoot ParsToJSON(string body)
        {
            var deserializator = JsonConvert.DeserializeObject<ImageRoot[]>("[" + body + "]");
            return deserializator[0];
        }
    }
}
