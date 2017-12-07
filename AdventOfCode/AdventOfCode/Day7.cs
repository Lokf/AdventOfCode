using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

namespace AdventOfCode
{
    public class Day7
    {
        public static string Task1(List<string> towers)
        {
            var kalle = towers
                .Select(ParseLine)
                .ToList();

            return Root(kalle);
        }

        public static int Task2(List<string> towers)
        {
            var kalle = towers
                .Select(ParseLine)
                .ToList();

            var root = Root(kalle);

            return 0;
        }

        private static int Kalle(Tower root)
        {
            if (!root.SubTowers.Any())
            {
                return 0;
            }

            var weights = root.SubTowers.Select(t => t.Weight).ToList();

            if (weights.Distinct().Count() == 1)
            {
                return root.SubTowers.Select(Kalle).Sum();
            }

            var kalle = new Dictionary<int, int>();
            foreach (var weight in weights)
            {
                if (kalle.TryGetValue(weight, out var a))
                {
                    kalle[weight]++;
                }
                else
                {
                    kalle.Add(weight, 1);
                }
            }

            return kalle.First(x => x.Value > 1).Value;
        }

        private static string Root(List<Tower> towers)
        {
            var all = towers.Select(tower => tower.Name).ToList();
            var sub = towers.SelectMany(tower => tower.Names).ToHashSet();

            foreach (var a in all)
            {
                var b = sub.Add(a);

                if (b)
                {
                    return a;
                }
            }

            return "";
        }

        private static Tower ParseLine(string input)
        {
            var index = input.IndexOf(' ');
            var name = input.Substring(0, index);
            var startIndex = input.IndexOf('(') + 1;
            var stopIndex = input.IndexOf(')');
            var r = input.Substring(startIndex, stopIndex - startIndex);
            var weight = int.Parse(r);
            var subTowerIndex = input.IndexOf("->");
            var anka = new List<string>();

            if (subTowerIndex > 0)
            {
                var kalle = input.Substring(subTowerIndex + 3);
                var ka = kalle.Split(',');

                foreach (var k in ka)
                {
                    anka.Add(k.Replace(" ", ""));
                }
            }


            return new Tower
            {
                Name = name,
                Weight = weight,
                Names = anka
            };
        }

        private static void Kalle(List<Tower> all)
        {
            var kalle = all.ToDictionary(x => x.Name, x => x);

            foreach (var anka in all)
            {
                foreach (var a in anka.Names)
                {
                    anka.SubTowers.Add(kalle[a]);
                }
            }
        }

        private class Tower
        {
            public string Name { get; set; }
            public int Weight { get; set; }
            public List<Tower> SubTowers { get; } = new List<Tower>();
            public List<string> Names { get; set; } = new List<string>();
        }
    }
}
