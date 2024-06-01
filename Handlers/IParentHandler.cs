using TestBlazor.Models;

namespace TestBlazor.Handlers
{
    public interface IParentHandler
    {
        Task<Parent?> AddParent(Parent parent);
        Task<Parent?> DeleteParentById(int parentId);
        Task<Parent?> GetParentById(int id);
        Task<List<Parent>?> GetParents();
        Task<List<Parent>?> GetParentsWithDetails();
        Task<Parent?> GetParentWithDetailsById(int id);
        Task<Parent?> UpdateParent(int id, Parent parent);
        Task<Parent?> UpdateParentWithDetails(int id, Parent parent);
    }
}
