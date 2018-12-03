using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode._2018
{
    public class Day03
    {
        public static int Task1(IEnumerable<string> claims)
        {
            const string pattern = @"#(?'id'\d+) @ (?'left'\d+),(?'top'\d+): (?'width'\d+)x(?'height'\d+)";
            var regex = new Regex(pattern);
            var fabricUsage = new HashSet<(int, int)>();
            var overlaps = new HashSet<(int, int)>();
            foreach (var claim in claims)
            {
                var matches = regex.Match(claim);
                var left = int.Parse(matches.Groups["left"].Value);
                var top = int.Parse(matches.Groups["top"].Value);
                var width = int.Parse(matches.Groups["width"].Value);
                var height = int.Parse(matches.Groups["height"].Value);

                for (var row = top; row < top + height; row++)
                {
                    for (var column = left; column < left + width; column++)
                    {
                        if (!fabricUsage.Add((row, column)))
                        {
                            overlaps.Add((row, column));
                        }
                    }
                }
            }

            return overlaps.Count;
        }

        public static int Task2(IEnumerable<string> claims)
        {
            const string pattern = @"#(?'id'\d+) @ (?'left'\d+),(?'top'\d+): (?'width'\d+)x(?'height'\d+)";
            var regex = new Regex(pattern);
            var fabricUsage = new Dictionary<(int, int), int>();
            var overlappedIds = new HashSet<int>();
            var ids = new HashSet<int>();
            foreach (var claim in claims)
            {
                var matches = regex.Match(claim);
                var id = int.Parse(matches.Groups["id"].Value);
                var left = int.Parse(matches.Groups["left"].Value);
                var top = int.Parse(matches.Groups["top"].Value);
                var width = int.Parse(matches.Groups["width"].Value);
                var height = int.Parse(matches.Groups["height"].Value);

                ids.Add(id);

                for (var row = top; row < top + height; row++)
                {
                    for (var column = left; column < left + width; column++)
                    {
                        if (!fabricUsage.TryAdd((row, column), id))
                        {
                            overlappedIds.Add(id);
                            overlappedIds.Add(fabricUsage[(row, column)]);
                        }
                    }
                }
            }

            ids.ExceptWith(overlappedIds);
            return ids.Single();
        }
    }
}
