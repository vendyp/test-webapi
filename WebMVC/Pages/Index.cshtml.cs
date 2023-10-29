using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebMVC.Abstractions;

namespace WebMVC.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IWeatherService _weatherService;

    public IndexModel(ILogger<IndexModel> logger, IWeatherService weatherService)
    {
        _logger = logger;
        _weatherService = weatherService;
        Cities = new List<string>();
    }

    public List<string> Cities { get; }

    public async Task OnGet()
    {
        Cities.AddRange(await _weatherService.GetAllCityAsync(CancellationToken.None));
    }
    
    
}