using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    public class Day13
    {
        public static int Task1(List<string> firewall)
        {
            var layers = firewall
                .Select(x => x.Split(": "))
                .Select(x => new Layer { Depth = int.Parse(x[0]), Range = int.Parse(x[1]) })
                .ToList();
            return PassFirewall(layers, 0).severity;
        }

        public static int Task2(List<string> firewall)
        {
            var count = 0;
            var layers = firewall
                .Select(x => x.Split(": "))
                .Select(x => new Layer { Depth = int.Parse(x[0]), Range = int.Parse(x[1]) })
                .ToList();
            while (true)
            {
                var passage = PassFirewall(layers, count);
                if (!passage.caught)
                {
                    return count;
                }
                count++;
            }         
        }   

        private static (int severity, bool caught) PassFirewall(List<Layer> layers, int delay)
        {
            var severity = 0;
            var caught = false;

            foreach (var layer in layers)
            {
                if (layer.IsAtTop(delay))
                {
                    severity += layer.Depth * layer.Range;
                    caught = true;
                }
            }

            return (severity, caught);
        }

        private class Layer
        {
            public int Depth { get; set; }
            public int Range { get; set; }

            public bool IsAtTop(int picosecond)
            {
                return (Depth + picosecond) % (2 * Range - 2) == 0;
            }
        }
    }
}
