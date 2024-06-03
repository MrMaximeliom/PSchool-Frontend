using System.Net.Http.Json;
using TestBlazor.Models;
using TestBlazor.Constants;

namespace TestBlazor.Handlers
{
    public class StudentHandler(IHttpClientFactory factory, IConfiguration configuration) : IStudentHandler
    {


        private readonly HttpClient _httpClient = factory.CreateClient("ServerUrl");

        // Get Students Data
        public async Task<Student[]?> GetStudents()
        {

            return await _httpClient.GetFromJsonAsync<Student[]?>(PageUrls.MAIN_STUDENT_URL);
        }

        public async Task<List<Student?>?> GetStudentsWithParents()
        {
                 return await _httpClient.GetFromJsonAsync<List<Student?>?>(PageUrls.LIST_STUDENTS_WITH_PARENTS_ENDPOINT);
   
           
        }

        public async Task<List<ParentShortDetails>?> GetParentShortDetails()
        {
            return await _httpClient.GetFromJsonAsync<List<ParentShortDetails>?>(PageUrls.LIST_PARENTS_SHORT_DETAILS_ENDPOINT);

        }

        public async Task<string[]?> GetParentsFullNames()
        {
            return await _httpClient.GetFromJsonAsync <string[]?>(PageUrls.LIST_PARENTS_NAMES_ENDPOINT);
        }

        public async Task<IEnumerable<Parent>?> GetParentsWithStudents()
        {
            return await _httpClient.GetFromJsonAsync <IEnumerable<Parent>?>(PageUrls.LIST_PARENT_STUDENTS_ENDPOINT);
        }

        public async Task<Student?> AddStudent(Student student)
        {
            var response = await _httpClient.PostAsync(PageUrls.MAIN_STUDENT_ENDPOINT, JsonContent.Create(student));

            if (!response.IsSuccessStatusCode)
            {
                throw new InvalidDataException();
            }

            return await response.Content.ReadFromJsonAsync<Student>() ?? throw new InvalidDataException();
        }
        public async Task<Student?> UpdateStudent(int id,Student student)
        {
            var response = await _httpClient.PutAsync(PageUrls.MAIN_STUDENT_ENDPOINT + $"/{id}", JsonContent.Create(student));

            if (!response.IsSuccessStatusCode)
            {
                throw new InvalidDataException();
            }

            return await response.Content.ReadFromJsonAsync<Student>() ?? throw new InvalidDataException();
        }

        public async Task<Student?> GetStudentById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Student?>(PageUrls.MAIN_STUDENT_ENDPOINT + $"/{id}");
        }

        public async Task<Student?> DeleteStudentById(int id) => await _httpClient.DeleteFromJsonAsync<Student?>(PageUrls.MAIN_STUDENT_ENDPOINT + $"/{id}");



    }
}
