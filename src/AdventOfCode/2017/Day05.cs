using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode._2017
{
    public class Day05
    {
        public static int Task1(List<string> jumpOffsets)
        {
            return NumberOfJumps(jumpOffsets, NewOffset1);
        }

        public static int Task2(List<string> jumpOffsets)
        {
            return NumberOfJumps(jumpOffsets, NewOffset2);
        }

        private static int NumberOfJumps(List<string> jumpOffsets, Func<int, int> newOffset)
        {
            var offsets = jumpOffsets
                .Select(jump => int.Parse(jump))
                .ToArray();

            var exit = offsets.Length;
            var index = 0;
            var count = 0;

            while (index < exit)
            {
                var offset = offsets[index];
                offsets[index] = newOffset(offset);
                index += offset;
                count++;
            }

            return count;
        }

        private static int NewOffset1(int offset)
        {
            return offset + 1;
        }

        private static int NewOffset2(int offset)
        {
            return offset + (offset < 3 ? 1 : -1);
        }
    }
}
