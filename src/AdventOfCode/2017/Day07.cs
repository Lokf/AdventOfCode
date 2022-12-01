using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2017
{
    public class Day07
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

            Kalle(kalle);

            var root = Root(kalle);

            var root2 = kalle.First(f => f.Name == root);

            return Kalle(root2).correct;
        }

        private static (int weight, int subTowersWeight, int correct) Kalle(Tower root)
        {
            if (!root.SubTowers.Any())
            {
                return (root.Weight, 0, 0);
            }

            var weights = root.SubTowers.Select(Kalle).ToList();

            if (weights.Select(t => t.correct).Max() > 0)
            {
                return (0, 0, weights.Select(t => t.correct).Max());
            }

            if (weights.Select(t => t.subTowersWeight + t.weight).Distinct().Count() == 1)
            {
                return (root.Weight, weights.Select(t => t.subTowersWeight + t.weight).Sum(), weights.Select(t => t.correct).Max());
            }

            var most = weights
                .Select(t => t.subTowersWeight + t.weight)
                .GroupBy(i => i)
                .OrderByDescending(grp => grp.Count())
                .Select(grp => grp.Key)
                .First();

            var a = weights.Single(t => t.subTowersWeight + t.weight != most);

            return (root.Weight, weights.Select(t => t.subTowersWeight + t.weight).Sum(), most - a.subTowersWeight);
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
