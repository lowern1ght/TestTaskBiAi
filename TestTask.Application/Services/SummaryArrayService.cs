using TestTask.Application.Services.Interfaces;

namespace TestTask.Application.Services;

public class SummaryArrayService : ISummaryArrayService<Int32>
{
    private Boolean IsOdd(Int32 i)
    {
        try
        {
            return i % 2 != 0;
        }
        catch (Exception)
        {
            return false;
        }
    }
    
    // since it was not specified which type to use, I use the standard for this architecture
    // так как не было указано какой тип использовать использую стандарт для своей архитектуры процессора
    public int GetSummaryNumbers(IReadOnlyCollection<int> nums)
    {
        Int32 summary = 0, count = 0;
        
        foreach (var num in nums)
        {
            if (!IsOdd(num)) continue;
            
            if (count < 1)
            {
                count += 1;
                continue;
            }

            summary += Math.Abs(num);
            count = 0;
        }

        return summary;
    }
}