using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode._2018
{
    public class Day01
    {
        public static int Task1(IEnumerable<int> frequencyChanges)
        {
            return frequencyChanges.Sum();
        }

        public static int Task2(IList<int> frequencyChanges)
        {
            var frequencies = new HashSet<int>();

            var frequency = 0;
            var index = 0;
            while (frequencies.Add(frequency))
            {
                if (index == frequencyChanges.Count)
                {
                    index = 0;
                }

                frequency += frequencyChanges[index];
                index++;
            }

            return frequency;
        }
    }
}
