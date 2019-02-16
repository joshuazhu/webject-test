using System;
using Infrastructure.Interface;
using Infrastructure.Model;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Infrastructure
{
    public class HttpClientService : IHttpClientService
    {
        private readonly HttpClient _client;
        private AppSettings _settings { get;}

        public HttpClientService(IOptions<AppSettings> settings)
        {
            _settings = settings.Value;
            _client = new HttpClient
            {
                Timeout = TimeSpan.FromSeconds(5)
            };

            InitHttpAuthHeader();
        }

        public async Task<T> GetData<T>(string url)
        {
            var response = await _client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
        }

        private void InitHttpAuthHeader()
        {
            _client.DefaultRequestHeaders.Add("x-access-token", _settings.ApiAuthToken);
        }
    }
}
