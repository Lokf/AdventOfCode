using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public class Day02
    {
        public static int Task1(List<string> spreadsheet)
        {
            return spreadsheet
                .Select(ParseRow)
                .Select(RowDifference)
                .Sum();
        }

        public static int Task2(List<string> spreadsheet)
        {
            return spreadsheet
                .Select(ParseRow)
                .Select(RowQuotient)
                .Sum();
        }

        private static IEnumerable<int> ParseRow(string row)
        {
            row = Regex.Replace(row, @"\s+", " ");

            return row
                .Split(' ')
                .Select(int.Parse)
                .ToList();
        }

        private static int RowQuotient(IEnumerable<int> row)
        {
            var sortedValues = row
                .OrderBy(value => value)
                .ToArray();

            foreach (var divisor in sortedValues)
            {
                for (int i = sortedValues.Length - 1; i > 0; i--)
                {
                    var dividend = sortedValues[i];

                    if (dividend == divisor)
                    {
                        break;
                    }

                    if (dividend % divisor == 0)
                    {
                        return dividend / divisor;
                    }
                }
            }

            return -1;
        }

        private static int RowDifference(IEnumerable<int> row)
        {
            var minMax = MinMax(row);
            return minMax.max - minMax.min;
        }

        private static (int min, int max) MinMax(IEnumerable<int> row)
        {
            var min = int.MaxValue;
            var max = int.MinValue;

            foreach (var value in row)
            {
                min = Math.Min(value, min);
                max = Math.Max(value, max);
            }

            return (min, max);
        }
    }
}
