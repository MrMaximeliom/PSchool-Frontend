using Blazored.SessionStorage;
using TestBlazor.Models;
using System.Text.Json;
using System.Net.Http.Json;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Data;

namespace TestBlazor.Services
{
    public class AuthenticationService(IHttpClientFactory factory, ISessionStorageService sessionStorageService) : IAuthenticationService
    {
        private readonly IHttpClientFactory _factory = factory;

        private readonly ISessionStorageService _sessionStorageService = sessionStorageService;


        private const string JWT_KEY = nameof(JWT_KEY);
        private const string EMAIL = nameof(EMAIL);
        private const string FIRST_NAME = nameof(FIRST_NAME);
        private const string LAST_NAME = nameof(LAST_NAME);
        private const string ROLES = nameof(ROLES);

        private string? _jwtCache;

        public event Action<string?>? LoginChange;

        public async Task<Auth> LoginAsync(LoginModel model)
        {
            var client = _factory.CreateClient("ServerApi");

          

            var response = await client.PostAsync("/api/auth/login", JsonContent.Create(model));

      

            if (!response.IsSuccessStatusCode)
            {

           

                // Deserialize JSON string into WeatherForecast array
                throw new UnauthorizedAccessException("Login Faild");

            }

            var content = await response.Content.ReadFromJsonAsync<Auth>() ?? throw new InvalidDataException();
             await _sessionStorageService.SetItemAsync(JWT_KEY, content.Token);
            var jwt = new JwtSecurityToken(content.Token);

           // Console.WriteLine( jwt);
            //Console.WriteLine("value is: ",jwt.Claims.First( c => c.Type == ClaimTypes.Name));




            //await _localStorageService.SetItem(JWT_KEY, content.Token);

            LoginChange?.Invoke(GetEmail(content));

           

            return content;
        }

        public async ValueTask<string> GetJwtAsync()
        {
            if (string.IsNullOrEmpty(_jwtCache))
            {
                _jwtCache = await _sessionStorageService.GetItemAsync<string>(JWT_KEY);
            }
            return _jwtCache;

        }

        public async Task LogoutAsync()
        {
            await _sessionStorageService.RemoveItemAsync(JWT_KEY);

            _jwtCache = null;

            LoginChange?.Invoke(null);
        }

        public static string GetEmail(Auth model)
        {
     
            var jwt = new JwtSecurityToken(model.Token);
            Console.WriteLine(jwt.Claims.First(c => c.Type == ClaimTypes.Email).Value);


            return jwt.Claims.First(c => c.Type == ClaimTypes.Email).Value;
      
        }

        public async Task<string?> GetClaimTypeByTokenAsync(string claimType)
        {
             string? token = await _sessionStorageService.GetItemAsync<string>(JWT_KEY);
            if(!string.IsNullOrEmpty(token))
            {
                var jwt = new JwtSecurityToken(token);
                return jwt.Claims.First(c => c.Type == claimType).Value;

            }
            return null;


        }
        
    }
}
