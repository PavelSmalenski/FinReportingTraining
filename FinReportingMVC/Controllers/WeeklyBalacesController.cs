using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FinReportingMVC.Models;
using System.Threading.Tasks;

namespace FinReportingMVC.Controllers;

public class WeeklyBalancesController : Controller
{
    private readonly ILogger<WeeklyBalancesController> _logger;

    public WeeklyBalancesController(ILogger<WeeklyBalancesController> logger)
    {
        _logger = logger;
    }

    public async Task<IActionResult> WeeklyBalancesReport([FromServices] IHttpClientFactory httpClientFactory)
    {
        var httpClient = httpClientFactory.CreateClient("DataAPI");

        var headerDataResponse = await httpClient.GetAsync("rpt1/heading/1/860040119");
        var j = await headerDataResponse.Content.ReadAsStringAsync();

        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}