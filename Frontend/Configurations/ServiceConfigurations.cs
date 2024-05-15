using Frontend.Interfaces;
using Frontend.Services;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Frontend.Configurations;

public static class ServiceConfigurations
{
    public static void RegisterService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped(sp => new HttpClient());
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<AddressService>();
        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie();
    }
}
