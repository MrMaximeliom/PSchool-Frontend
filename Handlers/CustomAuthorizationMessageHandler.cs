using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System.Net.Http.Headers;
namespace TestBlazor.Handlers
{
    public class CustomAuthorizationMessageHandler(IAccessTokenProvider provider, NavigationManager navigationManager) : DelegatingHandler
    {
        private readonly IAccessTokenProvider _provider = provider;
        private readonly NavigationManager _navigationManager = navigationManager; 
        
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var tokenResult = await _provider.RequestAccessToken();

            if(tokenResult.TryGetToken(out var token))
            {
                request.Headers.Authorization = new  AuthenticationHeaderValue("Bearer", token.Value);
            }
            else
            {
                _navigationManager.NavigateTo("login");
            }
            return await base.SendAsync(request, cancellationToken);    
        }

    }
}
