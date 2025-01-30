using System.Text.RegularExpressions;

namespace AdventOfCode2024 {
    internal class Day3 {
        public static void mainx() {
            string filePath = @"D:\input.txt";
            string input = File.ReadAllText(filePath);

            string pattern = @"mul\((\d{1,3}),\s*(\d{1,3})\)";
            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(input);

            int totalSum = 0;

            foreach (Match match in matches) {
                int number1 = int.Parse(match.Groups[1].Value);
                int number2 = int.Parse(match.Groups[2].Value);
                int sum = number1 * number2;
                totalSum += sum;
            }

            Console.WriteLine(totalSum);
        }
    }
}
