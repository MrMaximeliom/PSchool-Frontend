using System.Net.Http.Json;
using TestBlazor.Constants;
using TestBlazor.Models;

namespace TestBlazor.Handlers
{
    public class ParentHandler(IHttpClientFactory factory,IConfiguration configuration) : IParentHandler
    {
        private readonly string baseRequestUrl = $"{configuration.GetValue<string>("ServerUrl")}";

        private readonly string baseParentRequestUrl = PageUrls.BASE_SERVER_URL + PageUrls.MainParentUrl;

        private readonly HttpClient _httpClient = factory.CreateClient("ServerUrl");
        public async Task<List<Parent>?> GetParents()
        {

            return await _httpClient.GetFromJsonAsync<List<Parent>?>(baseParentRequestUrl);
        }
        public async Task<List<Parent>?> GetParentsWithDetails()
        {

            return await _httpClient.GetFromJsonAsync<List<Parent>?>(baseParentRequestUrl+"/with-details");
        }

        public async Task<Parent?> DeleteParentById(int parentId)
        {
            return await _httpClient.DeleteFromJsonAsync<Parent?>(baseParentRequestUrl +$"/{parentId}");
        }

        public async Task<Parent?> AddParent(Parent parent)
        {
            var response = await _httpClient.PostAsync(baseParentRequestUrl, JsonContent.Create(parent));

            if (!response.IsSuccessStatusCode)
            {
                throw new InvalidDataException();
            }

            return await response.Content.ReadFromJsonAsync<Parent>() ?? throw new InvalidDataException();
        }

        public async Task<Parent?> GetParentById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Parent?>(baseParentRequestUrl + $"/{id}");
        }
        public async Task<Parent?> GetParentWithDetailsById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Parent?>(baseParentRequestUrl + $"/with-details/{id}");
        }

        public async Task<Parent?> UpdateParent(int id, Parent parent)
        {
            var response = await _httpClient.PutAsync(baseParentRequestUrl + $"/{id}", JsonContent.Create(parent));

            if (!response.IsSuccessStatusCode)
            {
                throw new InvalidDataException();
            }

            return await response.Content.ReadFromJsonAsync<Parent>() ?? throw new InvalidDataException();
        }
        public async Task<Parent?> UpdateParentWithDetails(int id, Parent parent)
        {
            var response = await _httpClient.PutAsync(baseParentRequestUrl + $"/update-details/{id}", JsonContent.Create(parent));

            if (!response.IsSuccessStatusCode)
            {
                throw new InvalidDataException();
            }

            return await response.Content.ReadFromJsonAsync<Parent>() ?? throw new InvalidDataException();
        }
    }
}
