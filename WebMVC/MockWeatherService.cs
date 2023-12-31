﻿using System.Text.Json;
using WebMVC.Abstractions;
using WebMVC.Models;

namespace WebMVC;

public class MockWeatherService : IWeatherService
{
    private readonly Dictionary<string, WeatherDto?> _mockData;

    public MockWeatherService()
    {
        _mockData = new Dictionary<string, WeatherDto?>();

        var jsonZocca = @"
{
  ""coord"": {
    ""lon"": 10.99,
    ""lat"": 44.34
  },
  ""weather"": [
    {
      ""id"": 501,
      ""main"": ""Rain"",
      ""description"": ""moderate rain"",
      ""icon"": ""10d""
    }
  ],
  ""base"": ""stations"",
  ""main"": {
    ""temp"": 298.48,
    ""feels_like"": 298.74,
    ""temp_min"": 297.56,
    ""temp_max"": 300.05,
    ""pressure"": 1015,
    ""humidity"": 64,
    ""sea_level"": 1015,
    ""grnd_level"": 933
  },
  ""visibility"": 10000,
  ""wind"": {
    ""speed"": 0.62,
    ""deg"": 349,
    ""gust"": 1.18
  },
  ""rain"": {
    ""1h"": 3.16
  },
  ""clouds"": {
    ""all"": 100
  },
  ""dt"": 1661870592,
  ""sys"": {
    ""type"": 2,
    ""id"": 2075663,
    ""country"": ""IT"",
    ""sunrise"": 1661834187,
    ""sunset"": 1661882248
  },
  ""timezone"": 7200,
  ""id"": 3163858,
  ""name"": ""Zocca"",
  ""cod"": 200
}                        
                        ";
        _mockData["Zocca"] = JsonSerializer.Deserialize<WeatherDto>(jsonZocca, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
    }

    public Task<List<string>> GetAllCountryAsync(CancellationToken cancellationToken)
    {
        return Task.FromResult(new List<string>
        {
            "England",
            "Indonesia",
            "Italia",
        });
    }

    public Task<List<string>> GetAllCityAsync(CancellationToken cancellationToken)
    {
        return Task.FromResult(new List<string>
        {
            "London",
            "Zocca",
            "Jakarta"
        });
    }

    public Task<List<string>> GetAllCityAsync(string country, CancellationToken cancellationToken)
    {
        if (country == "Italia")
            return Task.FromResult(new List<string>
            {
                "Zocca"
            });

        return Task.FromResult(new List<string>());
    }

    public Task<WeatherDto?> GetWeatherAsync(string city, CancellationToken cancellationToken)
    {
        return _mockData.TryGetValue(city, out var weatherDto)
            ? Task.FromResult(weatherDto)
            : Task.FromResult<WeatherDto?>(null);
    }
}