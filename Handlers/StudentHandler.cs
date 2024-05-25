using System.Net.Http.Json;
using TestBlazor.Models;
using static System.Net.WebRequestMethods;
using TestBlazor.Pages;
using System.Text.Json;
using Mapster;

namespace TestBlazor.Handlers
{
    public class StudentHandler(IHttpClientFactory factory, IConfiguration configuration) : IStudentHandler
    {
        private readonly string baseRequestUrl = $"{configuration.GetValue<string>("ServerUrl")}";

        private readonly string baseStudentsRequestUrl = $"{configuration.GetValue<string>("ServerUrl")}/students";

        private readonly HttpClient _httpClient = factory.CreateClient("ServerUrl");

        // Get Students Data
        public async Task<Student[]?> GetStudents()
        {

            return await _httpClient.GetFromJsonAsync<Student[]?>(baseStudentsRequestUrl);
        }

        public async Task<List<Student?>?> GetStudentsWithParents()
        {
           // return await _httpClient.GetFromJsonAsync<List<Student>?>(baseStudentsRequestUrl+"/with-parents");

           //var result =  await _httpClient.GetFromJsonAsync<IEnumerable<Student>?>(baseStudentsRequestUrl+"/with-parents");
           return await _httpClient.GetFromJsonAsync<List<Student?>?>(baseStudentsRequestUrl + "/with-parents");
           // return result?.Adapt<IEnumerable<Student>?>();
           
        }

        public async Task<string[]?> GetParentsFullNames()
        {
            return await _httpClient.GetFromJsonAsync <string[]?>(baseStudentsRequestUrl + "/parents-names");
        }

        public async Task<IEnumerable<Parent>?> GetParentsWithStudents()
        {
            return await _httpClient.GetFromJsonAsync <IEnumerable<Parent>?>(baseRequestUrl + "/parents/students");
        }


       
    }
}
