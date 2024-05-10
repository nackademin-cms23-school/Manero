namespace Frontend.Configurations;

public static class ServiceConfigurations
{
    public static void RegisterService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped(sp => new HttpClient());
    }
}
