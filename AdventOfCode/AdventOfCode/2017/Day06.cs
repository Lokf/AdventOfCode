using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode._2017
{
    public class Day06
    {
        public static int Task1(string blockDistribution)
        {
            var distributition = Parse(blockDistribution);

            return CyclesBeforeRepetition(distributition);
        }

        public static int Task2(string blockDistribution)
        {
            var distributition = Parse(blockDistribution);

            CyclesBeforeRepetition(distributition);
            return CyclesBeforeRepetition(distributition);            
        }

        private static int[] Parse(string input)
        {
            return Regex
                .Replace(input, @"\s+", " ")
                .Split(' ')
                .Select(k => int.Parse(k))
                .ToArray();
        }

        private static int CyclesBeforeRepetition(int[] distributition)
        {
            var unique = new HashSet<string>
            {
                string.Join(',', distributition)
            };

            var count = 1;

            while (true)
            {
                var max = distributition.Max();
                var index = Array.IndexOf(distributition, max);
                distributition[index] = 0;

                while (max > 0)
                {
                    index++;
                    if (index == distributition.Length)
                    {
                        index = 0;
                    }

                    distributition[index]++;
                    max--;
                }

                if (!unique.Add(string.Join(',', distributition)))
                {
                    return count;
                }

                count++;
            }
        }
    }
}
