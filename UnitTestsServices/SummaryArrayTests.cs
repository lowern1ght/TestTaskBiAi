using TestTask.Application.Services;

namespace UnitTestsServices;

public class SummaryArrayTests
{
    [Theory]
    [InlineData(new [] { 2, 4, 5, 11, -13, 20, 45, 41, 20, 31}, 87)]
    [InlineData(new [] { 3, -3, 5, -11, -101, -21, 4, 8, 21, 302, 4011}, 4046)]
    public void TestSummary(Int32[] ints, Int32 excepted)
    {
        var service = new SummaryArrayService();
        Assert.Equal(excepted, service.GetSummaryNumbers(ints));
    }
}