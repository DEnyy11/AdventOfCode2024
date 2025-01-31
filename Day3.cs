using System;
using System.IO;
using System.Text.RegularExpressions;

namespace AdventOfCode2024 {
    internal class Day3 {
        public static void mainx() {
            string filePath = @"D:\input.txt";
            string input = File.ReadAllText(filePath);

            string pattern = @"mul\((\d{1,3}),\s*(\d{1,3})\)";
            string doPattern = @"do\(\)";
            string dontPattern = @"don't\(\)";

            Regex mulRegex = new Regex(pattern);
            Regex doRegex = new Regex(doPattern);
            Regex dontRegex = new Regex(dontPattern);

            int totalSum = 0;
            bool enabled = true;

            for (int i = 0; i < input.Length; i++) {
                if (input.Substring(i).StartsWith("do()")) {
                    enabled = true;
                    i += 3; //do delka 4 znaky
                }
                else if (input.Substring(i).StartsWith("don't()")) {
                    enabled = false;
                    i += 6; //dont delka 7 znaku
                }
                else {
                    Match match = mulRegex.Match(input, i);
                    if (match.Success && match.Index == i) {
                        if (enabled) {
                            int number1 = int.Parse(match.Groups[1].Value);
                            int number2 = int.Parse(match.Groups[2].Value);
                            totalSum += number1 * number2;
                        }
                        i += match.Length - 1; 
                    }
                }
            }
            Console.WriteLine(totalSum);
        }
    }
}
