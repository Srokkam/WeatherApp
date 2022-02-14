using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ApiClient
    {
        private static HttpClient _client;
        public ApiClient()
        {
            if (_client == null)
            {
                _client = new HttpClient();

            }
        }

        public async Task<T> GetTAsync<T>(string path)
        {
            var content = await _client.GetStreamAsync(path);
            return await System.Text.Json.JsonSerializer.DeserializeAsync<T>(content);
        }
    }
}
