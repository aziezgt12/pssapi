using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
namespace krodect.api.Utility
{
    public class ApiClient
    {

        private readonly HttpClient _httpClient;

        public ApiClient(string baseApiUrl)
        {
            // Inisialisasi HttpClient dengan URL base API yang diberikan
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(baseApiUrl);
        }

        public async Task<string> Get(string endpoint)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(endpoint);
            return await HandleResponseAsync(response);
        }

        public async Task<string> Post(string endpoint, string content)
        {
            HttpContent httpContent = new StringContent(content, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync(endpoint, httpContent);
            return await HandleResponseAsync(response);
        }

        public async Task<string> Put(string endpoint, string content)
        {
            HttpContent httpContent = new StringContent(content, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PutAsync(endpoint, httpContent);
            return await HandleResponseAsync(response);
        }

        public async Task<string> Delete(string endpoint)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync(endpoint);
            return await HandleResponseAsync(response);
        }

        private async Task<string> HandleResponseAsync(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                return content;
            }
            else
            {
                throw new Exception($"Error: {response.StatusCode}");
            }
        }
    }

}

