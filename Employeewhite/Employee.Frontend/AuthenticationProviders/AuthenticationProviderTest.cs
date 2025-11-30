using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace Employee.Frontend.AuthenticationProviders
{
    public class AuthenticationProviderTest : AuthenticationStateProvider
    {
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            await Task.Delay(1000);
            var anonimous = new ClaimsIdentity();
            var user = new ClaimsIdentity(authenticationType: "test");
            var admin = new ClaimsIdentity(
            [
                new("FirstName", "Juan"),
                new("LastName", "Ospina"),
                new(ClaimTypes.Name, "juan@yopmail.com"),
                new(ClaimTypes.Role, "Admin")
            ],
            authenticationType: "test");

            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(admin)));
        }
    }
}