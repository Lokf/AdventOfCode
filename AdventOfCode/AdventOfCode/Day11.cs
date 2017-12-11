using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    public class Day11
    {
        public static int Task1(List<string> path)
        {
            var journey = new Journey();

            path.ForEach(stage => journey.Travel(stage));

            return journey.DistanceFromStart();
        }

        public static int Task2(List<string> path)
        {
            var journey = new Journey();
            var max = int.MinValue;

            foreach (var stage in path)
            {
                journey.Travel(stage);
                max = Math.Max(max, journey.DistanceFromStart());
            }

            return max;
        }               

        private class Journey
        {
            public int North { get; private set; }
            public int Northeast { get; private set; }
            public int Southeast { get; private set; }
            public int South { get; private set; }
            public int Southwest { get; private set; }
            public int Northwest { get; private set; }

            public void Travel(string stage)
            {
                switch (stage)
                {
                    case "n":
                        North++;
                        break;
                    case "ne":
                        Northeast++;
                        break;
                    case "se":
                        Southeast++;
                        break;
                    case "s":
                        South++;
                        break;
                    case "sw":
                        Southwest++;
                        break;
                    case "nw":
                        Northwest++;
                        break;
                }
            }

            public int DistanceFromStart()
            {
                var longitude = Math.Abs(Northwest + Southwest - Northeast - Southeast);
                var latitude = Math.Abs(2 * North + Northwest + Northeast - 2 * South - Southeast - Southwest);

                return longitude + (latitude - longitude) / 2;               
            }
        }
    }
}
