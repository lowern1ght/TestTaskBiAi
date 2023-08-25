using Microsoft.AspNetCore.Mvc;
using TestTask.Application.Services.Interfaces;

namespace TestTask.Application.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class SummaryController : Controller
{
    private readonly ILogger<SummaryController> _logger;
    private readonly ISummaryArrayService<int> _summaryArrayService;

    public SummaryController(ILogger<SummaryController> logger, ISummaryArrayService<Int32> summaryArrayService)
    {
        _logger = logger;
        _summaryArrayService = summaryArrayService;
    }
    
    [HttpPost]
    public Task<ActionResult<Int32>> GetAsync([FromBody] Int32[] ints)
    {
        try
        {
            var result = _summaryArrayService.GetSummaryNumbers(ints);
            _logger.Log(LogLevel.Information, "{Controller} is returned: {Result}",
                nameof(SummaryController), result);
            
            return Task.FromResult<ActionResult<int>>(result);
        }
        catch (Exception e)
        {
            _logger.Log(LogLevel.Error, e.Message, e.Data);
        }

        return Task.FromResult<ActionResult<int>>(Int32.MinValue);
    }
}