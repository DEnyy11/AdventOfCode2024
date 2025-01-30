using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024 {
    internal class Day1 {
        public static void mainx() {
            Console.WriteLine(GetAnswer());
            Console.WriteLine(GetAnswerPart2());
        }

        static long GetAnswer() {

            string filePath = @"D:\input.txt";

            var col1 = new List<int>();
            var col2 = new List<int>();

            foreach (var line in File.ReadLines(filePath)) {
                var value = line.Split("   ");

                col1.Add(int.Parse(value[0]));
                col2.Add(int.Parse(value[1]));
            }

            col1.Sort();
            col2.Sort();

            long result = 0;

            for(int i =0; i < col1.Count; i++) {
                result += Math.Abs(col1[i] - col2[i]);
            }
            return result;
        }

        static long GetAnswerPart2() {
            string filePath = @"D:\input.txt";

            var col1 = new List<int>();
            var col2 = new List<int>();

            foreach (var line in File.ReadLines(filePath)) {
                var value = line.Split("   ");

                col1.Add(int.Parse(value[0]));
                col2.Add(int.Parse(value[1]));
            }
            col1.Sort();
            col2.Sort();

            long similarity = 0;
            long result = 0;

            for(int i=0; i < col1.Count; i++) {
                for (int x=0; x<col2.Count; x++) {
                    if (col1[i] == col2[x]) {
                        similarity++;
                    }
                }
                result += col1[i] * similarity;
                similarity = 0;
            }
            return result;
        }

    }
}
