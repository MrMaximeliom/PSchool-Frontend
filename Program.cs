using Blazored.LocalStorage;
using Blazored.SessionStorage;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TestBlazor;
using TestBlazor.Constants;
using TestBlazor.Handlers;
using TestBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
/*builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddOidcAuthentication(
    options =>
    {
        builder.Configuration.Bind("OidcConfiguration", options.ProviderOptions);
        // options.UserOptions.RoleClaim = "Admin";
         options.UserOptions.RoleClaim = "User";
    }
    );*/
// Adding policies
/*builder.Services.AddAuthorizationCore(config =>
{
    config.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
    config.AddPolicy("UserOnly", policy => policy.RequireRole("User"));

});*/
//builder.Services.AddTransient<CustomAuthorizationMessageHandler>();
builder.Services.AddSweetAlert2();

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBlazoredSessionStorage();

builder.Services.AddTransient<AuthenticationHandler>();
builder.Services.AddScoped<IStudentHandler,StudentHandler>();
builder.Services.AddScoped<IParentHandler,ParentHandler>();
builder.Services.AddScoped<IUserHandler,UserHandler>();


builder.Services.AddHttpClient("ServerApi")
    .ConfigureHttpClient(c => c.BaseAddress = new Uri(builder.Configuration["ServerUrl"] ?? ""))
    .AddHttpMessageHandler<CustomAuthorizationMessageHandler>();

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddSingleton<PageUrls>();
/*builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
*/

await builder.Build().RunAsync();
