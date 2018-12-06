using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2018
{
    public class Day06
    {
        public static int Task1(IEnumerable<string> coordinates)
        {
            var parsedCoordinates = coordinates
                .Select((c, i) => Parse(i, c))
                .ToList();

            var (left, right, top, bottom) = CalculateBorders(parsedCoordinates);

            var infinites = new HashSet<int>();
            var grid = new int?[right - left + 1, top - bottom + 1];

            for (int x = left; x <= right; x++)
            {
                for (int y = bottom; y <= top; y++)
                {
                    var nearestCoordinates = parsedCoordinates
                        .Select(c => new
                        {
                            Distance = Distance(x, y, c),
                            Name = c.Name,
                        })
                        .OrderBy(c => c.Distance)
                        .Take(2)
                        .ToArray();

                    if (nearestCoordinates[0].Distance < nearestCoordinates[1].Distance)
                    {
                        if (x == left || x == right || y == top || y == bottom)
                        {
                            infinites.Add(nearestCoordinates[0].Name);
                        }
                        grid[x - left, y - bottom] = nearestCoordinates[0].Name;
                    }
                    else
                    {
                        grid[x - left, y - bottom] = null;
                    }

                }
            }

            var counts = new Dictionary<int, int>();

            foreach (var cell in grid)
            {
                if (!cell.HasValue)
                {
                    continue;
                }
                if (infinites.Contains(cell.Value))
                {
                    continue;
                }
                counts.TryAdd(cell.Value, 0);
                counts[cell.Value]++;
            }

            return counts.OrderByDescending(c => c.Value).First().Value;
        }

        public static int Task2(IEnumerable<string> coordinates, int threshold)
        {
            var parsedCoordinates = coordinates
                .Select((c, i) => Parse(i, c))
                .ToList();

            var (left, right, top, bottom) = CalculateBorders(parsedCoordinates);

            var count = 0;

            for (int x = left; x <= right; x++)
            {
                for (int y = bottom; y <= top; y++)
                {
                    if (parsedCoordinates.Sum(c => Distance(x, y, c)) < threshold)
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        private static (int left, int right, int top, int bottom) CalculateBorders(IEnumerable<Coordinate> coordinates)
        {
            var left = coordinates.Min(c => c.X);
            var right = coordinates.Max(c => c.X);
            var top = coordinates.Max(c => c.Y);
            var bottom = coordinates.Min(c => c.Y);

            return (left, right, top, bottom);
        }

        private static int Distance(int x, int y, Coordinate coordinate)
        {
            return Math.Abs(coordinate.X - x) + Math.Abs(coordinate.Y - y);
        }

        private static Coordinate Parse(int name, string input)
        {
            var parts = input.Split(", ");
            return new Coordinate(name, int.Parse(parts[0]), int.Parse(parts[1]));
        }

        private class Coordinate
        {
            public Coordinate(int name, int x, int y)
            {
                Name = name;
                X = x;
                Y = y;
            }

            public int Name { get; }

            public int X { get; }

            public int Y { get; }
        }
    }
}
