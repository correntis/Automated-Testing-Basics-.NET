using System;
using NUnit.Framework;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите строку: ");
        string input = Console.ReadLine();

        int maxUniqueCount = GetMaxUniqueCount(input);
        int maxConsecutiveLettersCount = GetMaxConsecutiveLettersCount(input);
        int maxConsecutiveDigitsCount = GetMaxConsecutiveDigitsCount(input);

        Console.WriteLine($"Максимальное количество неодинаковых последовательных символов: {maxUniqueCount}");
        Console.WriteLine($"Максимальное количество последовательных одинаковых букв латинского алфавита: {maxConsecutiveLettersCount}");
        Console.WriteLine($"Максимальное количество последовательных одинаковых цифр: {maxConsecutiveDigitsCount}");

        Console.ReadLine();
    }

    static int GetMaxUniqueCount(string input)
    {
        int maxCount = 0;
        int currentCount = 0;

        for (int i = 0; i < input.Length; i++)
        {
            if (i == 0 || input[i] != input[i - 1])
            {
                currentCount = 1;
            }
            else
            {
                currentCount++;
            }

            if (currentCount > maxCount)
            {
                maxCount = currentCount;
            }
        }

        return maxCount;
    }

    static int GetMaxConsecutiveLettersCount(string input)
    {
        int maxCount = 0;
        int currentCount = 0;

        foreach (char c in input)
        {
            if (Char.IsLetter(c))
            {
                if (currentCount == 0 || c == input[currentCount - 1])
                {
                    currentCount++;
                }
                else
                {
                    currentCount = 1;
                }

                if (currentCount > maxCount)
                {
                    maxCount = currentCount;
                }
            }
            else
            {
                currentCount = 0;
            }
        }

        return maxCount;
    }

    static int GetMaxConsecutiveDigitsCount(string input)
    {
        int maxCount = 0;
        int currentCount = 0;

        foreach (char c in input)
        {
            if (Char.IsDigit(c))
            {
                if (currentCount == 0 || c == input[currentCount - 1])
                {
                    currentCount++;
                }
                else
                {
                    currentCount = 1;
                }

                if (currentCount > maxCount)
                {
                    maxCount = currentCount;
                }
            }
            else
            {
                currentCount = 0;
            }
        }

        return maxCount;
    }
}

[TestFixture]
public class ProgramTests
{
    [TestCase("abbcccddddd", 5)]
    [TestCase("abcdefg", 1)]
    [TestCase("122333444455555", 5)]
    [TestCase("aabbccddeeffgg", 2)]
    [TestCase("", 0)]
    public void GetMaxUniqueCount_ShouldReturnCorrectCount(string input, int expectedCount)
    {
        int result = Program.GetMaxUniqueCount(input);

        Assert.AreEqual(expectedCount, result);
    }

    [TestCase("abbcccddddd", 3)]
    [TestCase("abcdefg", 1)]
    [TestCase("aabbccddeeffgg", 2)]
    [TestCase("123456789", 0)]
    [TestCase("", 0)]
    public void GetMaxConsecutiveLettersCount_ShouldReturnCorrectCount(string input, int expectedCount)
    {
        int result = Program.GetMaxConsecutiveLettersCount(input);

        Assert.AreEqual(expectedCount, result);
    }

    [TestCase("abbcccddddd", 5)]
    [TestCase("abcdefg", 0)]
    [TestCase("aabbccddeeffgg", 0)]
    [TestCase("123456789", 9)]
    [TestCase("", 0)]
    public void GetMaxConsecutiveDigitsCount_ShouldReturnCorrectCount(string input, int expectedCount)
    {
        int result = Program.GetMaxConsecutiveDigitsCount(input);

        Assert.AreEqual(expectedCount, result);
    }
}
