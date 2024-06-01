using TestBlazor.Models;

namespace TestBlazor.Handlers
{
    public interface IUserHandler
    {
        public Task<User> AddUserAsync(RegisterUser registerUser);
        Task<User?> GetUserById(int id);
    }
}
