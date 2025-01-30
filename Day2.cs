namespace AdventOfCode2024 {
    internal class Day2 {
        public static void mainx() {
            GetAnswer();
        }
        static void GetAnswer() {

            string filePath = @"D:\input.txt";

            int safeCount = 0;

            foreach (var line in File.ReadAllLines(filePath)) {

                var numbers = line.Split(' ').Select(int.Parse).ToList();
                if (Dampener(numbers) == true) {
                    safeCount++;
                }
            }
            Console.WriteLine(safeCount);
        }

        private static bool isSafe(List<int> numbers) {

            if (numbers[0] > numbers[1]) {
                for (int i = 0; i < numbers.Count - 1; i++) {
                    if (numbers[i] <= numbers[i + 1]) {
                        return false;
                    }
                }
            }
            else if (numbers[0] < numbers[1]) {
                for (int i = 0; i < numbers.Count - 1; i++) {
                    if (numbers[i] >= numbers[i + 1]) {
                        return false;
                    }
                }
            }
            else { return false; }

            for (int i = 0; i < numbers.Count - 1; i++) {
                if (Math.Abs(numbers[i] - numbers[i + 1]) > 3) {
                    return false;
                }
            }
            return true;
        }

        private static bool Dampener(List<int> numbers) {
            if (isSafe(numbers)) { return true; }
            else {
                for (int i = 0; i < numbers.Count; i++) {
                    var editedNumbers = new List<int>(numbers);
                    editedNumbers.RemoveAt(i);
                    if (isSafe(editedNumbers)) { return true; }
                }
            }
            return false;
        }
    }
}
