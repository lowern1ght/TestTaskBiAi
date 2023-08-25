﻿using TestTask.Application.Services.Interfaces;

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
    
    //  так как не было указано какой тип
    //  использовать использую стандарт для данной архитектуры
    
    public int GetSummaryNumbers(int[] nums)
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