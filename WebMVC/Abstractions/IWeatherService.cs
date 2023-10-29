using WebMVC.Models;

namespace WebMVC.Abstractions;

public interface IWeatherService
{
    Task<List<string>> GetAllCountryAsync(CancellationToken cancellationToken);
    Task<List<string>> GetAllCityAsync(CancellationToken cancellationToken);
    Task<List<string>> GetAllCityAsync(string country, CancellationToken cancellationToken);
    Task<WeatherDto?> GetWeatherAsync(string city, CancellationToken cancellationToken);
}