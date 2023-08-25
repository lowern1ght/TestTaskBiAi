namespace TestTask.Application.Services.Interfaces;

public interface ISummaryArrayService<TOut>
{
    TOut GetSummaryNumbers(TOut[] nums);
}