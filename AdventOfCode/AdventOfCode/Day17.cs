using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    public class Day17
    {
        public static int Task1(int stepSize)
        {
            var currentPosition = 0;
            var buffer = new List<int>(2018)
            {
                0
            };

            for (var i = 1; i < 2018; i++)
            {
                currentPosition = (currentPosition + stepSize) % buffer.Count + 1;
                buffer.Insert(currentPosition, i);
            }

            return buffer.ElementAt((currentPosition + 1) % 2018);
        }

        public static int Task2(int stepSize)
        {
            var currentPosition = 1;
            var result = 1;

            for (int i = 2; i <= 50_000_000; i++)
            {
                currentPosition = (currentPosition + stepSize) % i + 1;
                if (currentPosition == 1)
                {
                    result = i;
                }
            }

            return result;
        }
    }
}
