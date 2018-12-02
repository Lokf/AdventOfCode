using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode._2018
{
    public class Day02
    {
        public static int Task1(IEnumerable<string> boxIds)
        {
            var twos = 0;
            var threes = 0;
            foreach (var boxId in boxIds)
            {
                var occurrences = boxId
                    .GroupBy(c => c)
                    .ToDictionary(c => c, c => c.Count());

                if (occurrences.Any(c => c.Value == 2))
                {
                    twos++;
                }
                if (occurrences.Any(c => c.Value == 3))
                {
                    threes++;
                }
            }

            return twos * threes;
        }

        public static string Task2(IList<string> boxIds)
        {
            var i = 1;
            foreach (var boxId in boxIds)
            {
                for (int j = i; j < boxIds.Count(); j++)
                {
                    var differences = Differences(boxId, boxIds[j]).ToList();
                    if (differences.Count == 1)
                    {
                        return boxId.Remove(differences.Single(), 1);
                    }
                }
            }

            return string.Empty;
        }

        private static IEnumerable<int> Differences(string left, string right)
        {
            for (int i = 0; i < left.Length; i++)
            {
                if (left[i] != right[i])
                {
                    yield return i;
                }
            }
        }
    }
}
