using TestBlazor.Models;
using System.Net.Http.Json;
using System.Net.Http;
namespace TestBlazor.Services
{
    public class UserRepository(IHttpClientFactory factory) : IUserRepository
    {
        private readonly HttpClient _httpClient = factory.CreateClient("ServerApi");

        public async Task<User?> GetUserByIdAsync(string id)
        {
            return await _httpClient.GetFromJsonAsync<User>("users") ?? null;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
              return await _httpClient.GetFromJsonAsync<User[]>("users") ?? []; 
        }
    }
}
