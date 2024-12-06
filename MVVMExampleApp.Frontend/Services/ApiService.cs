using MVVMExampleApp.Frontend.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MVVMExampleApp.Frontend.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<AddResponse> AddNumbersAsync(AddRequest request)
        {
            var jsonContext = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://localhost:7292/api/Add", jsonContext);

            var responseContent = await response.Content.ReadAsStringAsync();

            var addResponse = JsonConvert.DeserializeObject<AddResponse>(responseContent);

            return addResponse;
        }
    }
}
