using System.Net.Http.Json;
using TestBlazor.Models;
using static System.Net.WebRequestMethods;
using TestBlazor.Pages;
using System.Text.Json;
using Mapster;
using TestBlazor.Constants;

namespace TestBlazor.Handlers
{
    public class StudentHandler(IHttpClientFactory factory, IConfiguration configuration) : IStudentHandler
    {
        private readonly string baseRequestUrl = $"{configuration.GetValue<string>("ServerUrl")}";

        private readonly string baseStudentsRequestUrl = $"{configuration.GetValue<string>("ServerUrl")}"+PageUrls.MainStudentUrl;

        private readonly HttpClient _httpClient = factory.CreateClient("ServerUrl");

        // Get Students Data
        public async Task<Student[]?> GetStudents()
        {

            return await _httpClient.GetFromJsonAsync<Student[]?>(baseStudentsRequestUrl);
        }

        public async Task<List<Student?>?> GetStudentsWithParents()
        {
                 return await _httpClient.GetFromJsonAsync<List<Student?>?>(baseStudentsRequestUrl + "/with-parents");
   
           
        }

        public async Task<List<ParentShortDetails>?> GetParentShortDetails()
        {
            return await _httpClient.GetFromJsonAsync<List<ParentShortDetails>?>(baseRequestUrl + "/parents/with-short-details");

        }

        public async Task<string[]?> GetParentsFullNames()
        {
            return await _httpClient.GetFromJsonAsync <string[]?>(baseStudentsRequestUrl + "/parents-names");
        }

        public async Task<IEnumerable<Parent>?> GetParentsWithStudents()
        {
            return await _httpClient.GetFromJsonAsync <IEnumerable<Parent>?>(baseRequestUrl + "/parents/students");
        }

        public async Task<Student?> AddStudent(Student student)
        {
            var response = await _httpClient.PostAsync(baseStudentsRequestUrl, JsonContent.Create(student));

            if (!response.IsSuccessStatusCode)
            {
                throw new InvalidDataException();
            }

            return await response.Content.ReadFromJsonAsync<Student>() ?? throw new InvalidDataException();
        }
        public async Task<Student?> UpdateStudent(int id,Student student)
        {
            var response = await _httpClient.PutAsync(baseStudentsRequestUrl + $"/{id}", JsonContent.Create(student));

            if (!response.IsSuccessStatusCode)
            {
                throw new InvalidDataException();
            }

            return await response.Content.ReadFromJsonAsync<Student>() ?? throw new InvalidDataException();
        }

        public async Task<Student?> GetStudentById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Student?>(baseStudentsRequestUrl + $"/{id}");
        }

        public async Task<Student?> DeleteStudentById(int id) => await _httpClient.DeleteFromJsonAsync<Student?>(baseStudentsRequestUrl + $"/{id}");



    }
}
