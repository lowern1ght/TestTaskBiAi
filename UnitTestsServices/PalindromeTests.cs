using TestTask.Application.Services;

namespace UnitTestsServices;

public class PalindromeTests
{
    [Theory]
    [InlineData("казак", true)]
    [InlineData("serval kazban", false)]
    [InlineData("А роза упала на лапу Азора", true)]
    public void PalindromeServiceTest(String s, Boolean expected)
    {
        var service = new PalindromeService();
        Assert.Equal(expected, service.IsPalindrome(s));
    }
}