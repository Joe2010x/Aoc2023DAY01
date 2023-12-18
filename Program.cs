
namespace Aoc2023day01;

class Program
{
    static void Main(string[] args)
    {
        var lines = FileReader.ReadFile("d0.txt");
        var listOfDigits1 = lines.Select(l => GetAllDigits(l, 1)).ToArray();
        var listOfDigits2 = lines.Select(l => GetAllDigits(l, 2)).ToArray();
        var listOfNum1 = listOfDigits1.Select(l => int.Parse(l)).ToArray();
        var listOfNum2 = listOfDigits2.Select(l => int.Parse(l)).ToArray();
        Console.WriteLine("AOC 2023 Day 01 part 1 result: "+listOfNum1.Sum());
        Console.WriteLine("AOC 2023 Day 01 part 2 result: "+listOfNum2.Sum());
    }

    public static string GetAllDigits(string word, int indicator)
    {
        var digits = "0123456789";
        var wordDigits = new List<string>()
            { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        var resultPart1 = "";
        var resultPart2 = "";
        for (int i = 0; i < word.Length; i++)
        {
            var subString = word.Substring(i);
            var firstChar = subString[0];
            if (digits.Contains(firstChar))
            {
                resultPart1 += firstChar;
                resultPart2 += firstChar;
            }
            else
            {
                foreach (var wd in wordDigits)
                {
                    var length = wd.Length;
                    if (subString.Length < length) continue;
                    var subWord = subString.Substring(0, length);
                    if (wd == subWord)
                    {
                        var indexOfWord = wordDigits.IndexOf(wd).ToString();
                        resultPart2 += indexOfWord;
                    }
                }
            }

        }
        return indicator == 1 
        ? resultPart1[0].ToString() + resultPart1[resultPart1.Length - 1].ToString() 
        : resultPart2[0].ToString() + resultPart2[resultPart2.Length - 1].ToString();
    }
}
