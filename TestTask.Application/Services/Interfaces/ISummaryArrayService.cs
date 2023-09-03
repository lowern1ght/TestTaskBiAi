namespace TestTask.Application.Services.Interfaces;

public interface ISummaryArrayService<TOut>
{
    TOut GetSummaryNumbers(IReadOnlyCollection<TOut> nums);
}