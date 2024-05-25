using TestBlazor.Models;

namespace TestBlazor.Services
{
    public interface IAuthenticationService
    {
        event Action<string?>? LoginChange;

        ValueTask<string> GetJwtAsync();
        Task<Auth> LoginAsync(LoginModel model);
        Task LogoutAsync();

        Task<string?> GetClaimTypeByTokenAsync( string claimType);
    }
}