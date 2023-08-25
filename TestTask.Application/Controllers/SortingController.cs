using Microsoft.AspNetCore.Mvc;
using TestTask.Application.Services.Interfaces;

namespace TestTask.Application.Controllers;

[ApiController]
[Route("api/v1/[controller]/[action]")]
public class SortingController : Controller
{
    private readonly ISortingService _sortingService;
    private readonly ILogger<SortingController> _logger;

    public SortingController(ISortingService sortingService, ILogger<SortingController> logger)
    {
        _logger = logger;
        _sortingService = sortingService;
    }

    [HttpPost]
    public Task<ActionResult<IEnumerable<Int32>>> SortAsync([FromBody] Int32[] ints)
    {
        try
        {
            var array = _sortingService.Sort(ints).ToArray();
            return Task.FromResult<ActionResult<IEnumerable<int>>>(array);
        }
        catch (Exception exception)
        {
            _logger.Log(LogLevel.Error, exception.Message, exception.Data);
        }
        
        return Task.FromResult<ActionResult<IEnumerable<int>>>(Array.Empty<Int32>());
    }
}