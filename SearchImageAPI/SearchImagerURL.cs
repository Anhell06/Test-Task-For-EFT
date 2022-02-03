using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SearchImageAPI
{
    public class SearchImagerURL : IImageAPI
    {
        private string URL;

        public SearchImagerURL()
        {
            this.URL = Settings.ImageURLApi;
        }

        public async Task<string> GetImageURL(string discription)
        {

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {

                Method = HttpMethod.Get,
                RequestUri = new Uri($"{URL}?q={discription}"),
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


            return ParsToJSON(body).Value[0].ContentUrl;

        }

        private ImageRoot ParsToJSON(string body)
        {
            var deserializator = JsonConvert.DeserializeObject<ImageRoot>(body);
            return deserializator;
        }
    }
}
