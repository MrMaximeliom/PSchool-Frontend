using System.Net.Http.Json;
using TestBlazor.Constants;
using TestBlazor.Models;

namespace TestBlazor.Handlers
{
    public class ParentHandler(IHttpClientFactory factory,IConfiguration configuration) : IParentHandler
    {

        private readonly HttpClient _httpClient = factory.CreateClient("ServerUrl");
        public async Task<List<Parent>?> GetParents()
        {

            return await _httpClient.GetFromJsonAsync<List<Parent>?>(PageUrls.MAIN_PARENT_ENDPOINT);
        }
        public async Task<List<Parent>?> GetParentsWithDetails()
        {

            return await _httpClient.GetFromJsonAsync<List<Parent>?>(PageUrls.LIST_PARENTS_WITH_DETAILS_ENDPOINT);
        }

        public async Task<Parent?> DeleteParentById(int parentId)
        {
            return await _httpClient.DeleteFromJsonAsync<Parent?>(PageUrls.MAIN_PARENT_ENDPOINT +$"/{parentId}");
        }

        public async Task<Parent?> AddParent(Parent parent)
        {
            var response = await _httpClient.PostAsync(PageUrls.MAIN_PARENT_ENDPOINT, JsonContent.Create(parent));

            if (!response.IsSuccessStatusCode)
            {
                throw new InvalidDataException();
            }

            return await response.Content.ReadFromJsonAsync<Parent>() ?? throw new InvalidDataException();
        }

        public async Task<Parent?> GetParentById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Parent?>(PageUrls.MAIN_PARENT_ENDPOINT + $"/{id}");
        }
        public async Task<Parent?> GetParentWithDetailsById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Parent?>(PageUrls.LIST_PARENTS_WITH_DETAILS_ENDPOINT + $"/{id}");
        }

        public async Task<Parent?> UpdateParent(int id, Parent parent)
        {
            var response = await _httpClient.PutAsync(PageUrls.MAIN_PARENT_ENDPOINT + $"/{id}", JsonContent.Create(parent));

            if (!response.IsSuccessStatusCode)
            {
                throw new InvalidDataException();
            }

            return await response.Content.ReadFromJsonAsync<Parent>() ?? throw new InvalidDataException();
        }
        public async Task<Parent?> UpdateParentWithDetails(int id, Parent parent)
        {
            var response = await _httpClient.PutAsync(PageUrls.UPDATE_PARENT_DETAILS_ENDPOINT + $"/{id}", JsonContent.Create(parent));

            if (!response.IsSuccessStatusCode)
            {
                throw new InvalidDataException();
            }

            return await response.Content.ReadFromJsonAsync<Parent>() ?? throw new InvalidDataException();
        }
    }
}
