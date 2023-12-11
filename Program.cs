
namespace Aoc2023day01;

class Program
{
    static void Main(string[] args)
    {
        var lines = FileReader.ReadFile("d1.txt");
        var listOfDigits = lines.Select(l => GetAllDigits(l)).ToArray();
        var listOfNum = listOfDigits.Select(l => int.Parse(l)).ToArray();
        Console.WriteLine(listOfNum.Sum());
    }

    public static string GetAllDigits(string word)
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

        return resultPart2[0].ToString() + resultPart2[resultPart2.Length - 1].ToString();
    }
}
