namespace TestTask.Application.Services.Interfaces;

public interface ISortingService
{
    IEnumerable<Int32> Sort(IEnumerable<Int32> ints);
}