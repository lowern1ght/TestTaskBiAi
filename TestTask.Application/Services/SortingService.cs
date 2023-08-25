using TestTask.Application.Services.Interfaces;

namespace TestTask.Application.Services;

public class SortingService : ISortingService
{
    public IEnumerable<int> Sort(IEnumerable<int> ints)
    {
        return BubbleSort(ints);
    }

    private IEnumerable<Int32> BubbleSort(IEnumerable<Int32> ints)
    {
        var arrSorted = ints.ToList();
        
        var n = arrSorted.Count;
        for (var i = 0; i < n - 1; i++)
        {
            for (var j = 0; j < n - i - 1; j++)
            {
                if (arrSorted[j] > arrSorted[j + 1])
                {
                    (arrSorted[j], arrSorted[j + 1]) = (arrSorted[j + 1], arrSorted[j]);
                }
            }
        }

        return arrSorted;
    }
}