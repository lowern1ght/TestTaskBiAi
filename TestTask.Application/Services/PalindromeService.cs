using TestTask.Application.Services.Interfaces;

namespace TestTask.Application.Services;

public class PalindromeService : IPalindromeService
{
    public bool IsPalindrome(string s)
    {
        if (s.Length == 0)
            return false;

        // it was also not said about case accounting, so I brought all the characters to lowercase
        // про учет регистра, тоже не было сказано, поэтому я привел все символы к нижнему регистру
        var stringWithSpace = s.ToLower().Replace(" ", "");
        
        var center = (int)Math.Round((double)(stringWithSpace.Length / 2 + 1), MidpointRounding.ToEven);

        // there was also no condition about performance, so I allowed myself to use LINQ
        // также не было никаких условий относительно производительности, поэтому я позволил себе использовать LINQ
        var a1 = new string(stringWithSpace.Skip(center).ToArray());
        var a2 = new string(stringWithSpace.Take(center - 1).Reverse().ToArray());
        
        return String.Equals(a1, a2);
    }
}