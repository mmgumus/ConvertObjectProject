using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using ConvertObjectProject.Models;

namespace ConvertObjectProject.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            var response = await _httpClient.GetAsync("https://gorest.co.in/public/v2/users");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var users = JsonSerializer.Deserialize<List<User>>(content,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return users ?? new List<User>();
            // var response = await _httpClient.GetAsync("https://gorest.co.in/public/v2/users");
            // response.EnsureSuccessStatusCode();
            //
            // var content = await response.Content.ReadAsStringAsync();
            // return JsonSerializer.Deserialize<List<User>>(content);
        }
    }
}