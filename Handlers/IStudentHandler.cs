using TestBlazor.Models;

namespace TestBlazor.Handlers
{
    public interface IStudentHandler
    {
        Task<Student[]?> GetStudents();

        Task<List<Student?>?> GetStudentsWithParents();

        Task<string[]?> GetParentsFullNames();

        Task<IEnumerable<Parent>> GetParentsWithStudents(); 
    }
}