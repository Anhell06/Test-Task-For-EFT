﻿
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Test_Task.JsonModel.Weather;

namespace Test_Task
{
    public class WeatherTextLoader : ITextLoader
    {
        private readonly string URL;


        public WeatherTextLoader(string URL, string APIToken)
        {
            this.URL = URL + APIToken;
        }

        public async Task<string> GetDataAsync(CancellationTokenSource token)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(URL),
                };

                string body;

                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    body = await response.Content.ReadAsStringAsync();
                }
                return ParsToJSON(body).ToString();
            }
            catch (OperationCanceledException)
            {

                throw;
            }
        }

        private WeatherRoot ParsToJSON(string body)
        {
            var deserializator = JsonConvert.DeserializeObject<WeatherRoot[]>("["+body+"]");
            return deserializator[0];
        }
    }
}
