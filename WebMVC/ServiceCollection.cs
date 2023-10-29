using WebMVC.Abstractions;

namespace WebMVC;

public static class ServiceCollection
{
    public static void AddDevelopmentInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IWeatherService, MockWeatherService>();
    }

    public static void AddInfrastructure(this IServiceCollection services)
    {
        //here is add real weather service
        //services.AddScoped<IWeatherService, WeatherService>();
    }
}