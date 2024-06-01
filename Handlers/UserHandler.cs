using System.Net.Http.Json;
using TestBlazor.Constants;
using TestBlazor.Models;

namespace TestBlazor.Handlers
{
    public class UserHandler(IHttpClientFactory factory) : IUserHandler
    {
        private readonly HttpClient _httpClient = factory.CreateClient("ServerUrl");

        private readonly string baseUserRequestUrl = PageUrls.BASE_SERVER_URL + PageUrls.MAIN_USER_ROUTE;

        public async Task<User> AddUserAsync(RegisterUser registerUser)
        {
            var response = await _httpClient.PostAsync(baseUserRequestUrl, JsonContent.Create(registerUser));

            if (!response.IsSuccessStatusCode)
            {
                throw new InvalidDataException();
            }

            return await response.Content.ReadFromJsonAsync<User>() ?? throw new InvalidDataException();


        }

        public async Task<User?> GetUserById(int id)
        {
            return await _httpClient.GetFromJsonAsync<User?>(baseUserRequestUrl + $"/{id}");
        }
    }
}
