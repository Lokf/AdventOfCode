using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode._2018
{
    public class Day05
    {
        public static int Task1(string polymer)
        {
            return React(polymer);
        }

        public static int Task2(string polymer)
        {
            var unitTypes = polymer
                .Where(c => c < 97)
                .Distinct();

            var lenghts = new List<int>();

            foreach (var unitType in unitTypes)
            {
                var reducedPolymer = polymer
                    .Replace(unitType.ToString(), "")
                    .Replace(((char)(unitType + 32)).ToString(), "");

                lenghts.Add(React(reducedPolymer));
            }

            return lenghts.Min();
        }

        private static int React(string polymer)
        {
            var remainingIndexes = new Stack<int>();
            var index = 0;
            var lastRemainingIndex = -1;
            do
            {
                if (!remainingIndexes.TryPeek(out lastRemainingIndex))
                {
                    remainingIndexes.Push(index);
                    index++;
                    continue;
                }

                if (IsReacting(polymer[lastRemainingIndex], polymer[index]))
                {
                    remainingIndexes.Pop();
                    index++;
                }
                else
                {
                    remainingIndexes.Push(index);
                    index++;
                }
            }
            while (index < polymer.Length);

            return remainingIndexes.Count;
        }

        private static bool IsReacting(char left, char right)
        {
            return Math.Abs(left - right) == 32;
        }
    }
}
