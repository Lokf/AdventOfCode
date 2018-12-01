using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode._2017
{
    public class Day14
    {
        public static int Task1(string key)
        {
            var count = 0;
            var grid = Grid(key);
            foreach (var element in grid)
            {
                if (element.Value)
                {
                    count++;
                }
            }

            return count;
        }

        public static int Task2(string key)
        {
            var grid = Grid(key);
            return NumberOfRegions(grid);
        }

        private static Element<bool>[,] Grid(string key)
        {
            var grid = new Element<bool>[128,128];

            for (var i = 0; i < 128; i++)
            {
                var knotHash = Day10.Task2($"{key}-{i}".ToCharArray(), 256);
                var binary = string.Join("", knotHash.Select(x => Convert.ToString(Convert.ToInt32(x.ToString(), 16), 2).PadLeft(4, '0')));
                for (var j = 0; j < 128; j++)
                {
                    grid[i, j] = new Element<bool>(i, j, binary[j] == '1');
                }
            }

            return grid;
        }

        private static int NumberOfRegions(Element<bool>[,] grid)
        {
            var visitedCells = new HashSet<Element<bool>>();
            var region = 0;
            for (var i = 0; i < 128; i++)
            {
                for (var j = 0; j < 128; j++)
                {
                    var element = grid[i, j];
                    if (visitedCells.Contains(element) || !element.Value)
                    {
                        continue;
                    }

                    region++;
                    Search(element, visitedCells, grid);
                }
            }

            return region;
        }

        private static void Search(Element<bool> element, HashSet<Element<bool>> visited, Element<bool>[,] grid)
        {
            if (visited.Contains(element))
            {
                return;
            }

            visited.Add(element);

            if (!element.Value)
            {
                return;
            }

            foreach (var neighbor in element.Neighbors(grid))
            {
                Search(neighbor, visited, grid);
            }
        }

        private class Element<TValue>
        {
            public int Row { get; }
            public int Column { get; }
            public TValue Value { get; }

            public Element(int row, int column, TValue value)
            {
                Row = row;
                Column = column;
                Value = value;
            }

            public IEnumerable<Element<TValue>> Neighbors(Element<TValue>[,] grid)
            {
                if (Row > 0)
                {
                    yield return grid[Row - 1, Column];
                }
                if (Column > 0)
                {
                    yield return grid[Row, Column - 1];
                }
                if (Column < 127)
                {
                    yield return grid[Row, Column + 1];
                }
                if (Row < 127)
                {
                    yield return grid[Row + 1, Column];
                }
            }

            /// <summary>Determines whether the specified object is equal to the current object.</summary>
            /// <param name="obj">The object to compare with the current object.</param>
            /// <returns>true if the specified object  is equal to the current object; otherwise, false.</returns>
            public override bool Equals(object obj)
            {
                return Equals(obj as Element<TValue>);
            }

            /// <summary>Serves as the default hash function.</summary>
            /// <returns>A hash code for the current object.</returns>
            public override int GetHashCode()
            {
                unchecked
                {
                    return 197 * Row ^ 397 * Column;
                }
            }

            public bool Equals(Element<TValue> element)
            {
                if (element == null)
                {
                    return false;
                }

                return Row == element.Row && Column == element.Column;
            }
        }
    }
}
