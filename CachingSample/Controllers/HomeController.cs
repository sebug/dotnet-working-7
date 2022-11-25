using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CachingSample.Models;
using Microsoft.Extensions.Caching.Memory;

namespace CachingSample.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IMemoryCache _cache;

    public HomeController(ILogger<HomeController> logger,
    IMemoryCache memoryCache)
    {
        _logger = logger;
        _cache = memoryCache;
    }

    //[ResponseCache(Duration=10)]
    public IActionResult Index()
    {
        ViewData["TheTime"] = _cache.GetOrCreate("TheTime", (entry) => {
            entry.SlidingExpiration = TimeSpan.FromSeconds(7);
            return DateTime.Now;
        });
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
