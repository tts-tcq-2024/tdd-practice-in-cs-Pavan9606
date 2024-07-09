using System;
using System.Collections.Generic;
using System.Linq;

public class StringCalculator
{
    public int Add(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return 0;
        }

        char[] delimiters = GetDelimiters(input);

        var numbers = ParseNumbers(input, delimiters);

        CheckForNegativeNumbers(numbers);

        numbers = FilterNumbers(numbers);

        return SumNumbers(numbers);
    }

    private char[] GetDelimiters(string input)
    {
        char[] defaultDelimiters = { ',', '\n' };

        if (input.StartsWith("//"))
        {
            int delimiterIndex = input.IndexOf('\n');
            string delimiterLine = input.Substring(2, delimiterIndex - 2);
            return new[] { delimiterLine[0] };
        }

        return defaultDelimiters;
    }

    private List<int> ParseNumbers(string input, char[] delimiters)
    {
        return input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();
    }

    private void CheckForNegativeNumbers(List<int> numbers)
    {
        var negativeNumbers = numbers.Where(n => n < 0);
        if (negativeNumbers.Any())
        {
            throw new Exception($"Negatives not allowed: {string.Join(",", negativeNumbers)}");
        }
    }

    private List<int> FilterNumbers(List<int> numbers)
    {
        return numbers.Where(n => n <= 1000).ToList();
    }

    private int SumNumbers(List<int> numbers)
    {
        return numbers.Sum();
    }

}
