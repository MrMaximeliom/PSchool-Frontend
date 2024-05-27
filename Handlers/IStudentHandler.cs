using TestBlazor.Models;

namespace TestBlazor.Handlers
{
    public interface IStudentHandler
    {
        Task<Student[]?> GetStudents();

        Task<List<Student?>?> GetStudentsWithParents();

        Task<string[]?> GetParentsFullNames();

        Task<IEnumerable<Parent>> GetParentsWithStudents();
        Task<List<ParentShortDetails>?> GetParentShortDetails();
        Task<Student?> AddStudent(Student student);
        Task<Student?> GetStudentById(int id);
        Task<Student?> UpdateStudent(int id, Student student);
        Task<Student?> DeleteStudentById(int id);
    }
}