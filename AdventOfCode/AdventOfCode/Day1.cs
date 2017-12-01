using System;
using System.Linq;

namespace AdventOfCode
{
    public class Day1
    {
        public static int Task1(string captha)
        {
            var digits = Digits(captha);

            return digits
                .Where((digit, index) => digit == NextDigit(digits, index))
                .Sum();
        }

        public static int Task2(string captha)
        {
            var digits = Digits(captha);

            return 2 * digits
                .Take(digits.Length / 2)
                .Where((digit, index) => digit == HalfwayAroundDigit(digits, index))
                .Sum();
        }

        private static int NextDigit(int[]digits, int index)
        {
            var nextIndex = (index + 1) % digits.Length;
            return digits[nextIndex];
        }

        private static int HalfwayAroundDigit(int[] digits, int index)
        {
            var halfwayAroundIndex = index + digits.Length / 2;
            return digits[halfwayAroundIndex];
        }

        private static int[] Digits(string captha)
        {
            return captha
                .Select(digit => (int)char.GetNumericValue(digit))
                .ToArray();
        }
    }
}
