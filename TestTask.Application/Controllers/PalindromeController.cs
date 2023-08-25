using Microsoft.AspNetCore.Mvc;
using TestTask.Application.Services.Interfaces;

namespace TestTask.Application.Controllers;

[ApiController]
[Route("api/v1/[controller]/[action]")]
public class PalindromeController : Controller
{
    private readonly ILogger<PalindromeController> _logger;
    private readonly IPalindromeService _palindromeService;

    public PalindromeController(IPalindromeService palindromeService, ILogger<PalindromeController> logger)
    {
        _logger = logger;
        _palindromeService = palindromeService;
    }

    [HttpPost]
    public Task<ActionResult<Boolean>> IsPalindromeAsync([FromBody] String s)
    {
        try
        {
            var result = _palindromeService.IsPalindrome(s);
            return Task.FromResult<ActionResult<bool>>(result);
        }
        catch (Exception exception)
        {
            _logger.Log(LogLevel.Error, exception.Message, exception.Data);
        }
        
        return Task.FromResult<ActionResult<bool>>(false);
    }
}