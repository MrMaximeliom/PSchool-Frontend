using TestBlazor.Models;

namespace TestBlazor.Services
{
    public interface IUserRepository
    {
        public Task<IEnumerable<User>> GetUsersAsync();

        public Task<User?> GetUserByIdAsync(string id);
    }
}
