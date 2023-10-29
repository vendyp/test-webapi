using WebMVC.Models;

namespace WebMVC.Abstractions;

public interface IWeatherService
{
    Task<List<string>> GetAllCityAsync(CancellationToken cancellationToken);
    Task<WeatherDto?> GetWeatherAsync(string city, CancellationToken cancellationToken);
}