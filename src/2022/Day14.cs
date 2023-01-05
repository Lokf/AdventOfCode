namespace Lokf.AdventOfCode2022;

public static partial class Day14
{
    public static int Task1(IEnumerable<string> lines)
    {
        var count = 0;
        var grid = Parse(lines);

        var threshold = grid.Keys.Max(coordinate => coordinate.Y);

        while (true)
        {
            var position = CalculateNextRestingPosition1(grid, threshold);
            if (position == null)
            {
                break;
            }
            grid.Add(position, 'O');
            count++;
        }

        return count;
    }

    public static int Task2(IEnumerable<string> lines)
    {
        var count = 0;
        var grid = Parse(lines);

        var threshold = grid.Keys.Max(coordinate => coordinate.Y) + 1;
        var source = new Coordinate(500, 0);
        while (true)
        {
            var position = CalculateNextRestingPosition2(grid, threshold);
            if (position == source)
            {
                count++;
                break;
            }
            grid.Add(position, 'O');
            count++;
        }

        return count;
    }

    private static Dictionary<Coordinate, char> Parse(IEnumerable<string> lines)
    {
        var grid = new Dictionary<Coordinate, char>();

        foreach (var line in lines)
        {
            foreach (var coordinate in Parse(line))
            {
                grid.TryAdd(coordinate, '#');
            }
        }

        return grid;
    }

    private static IEnumerable<Coordinate> Parse(string line)
    {
        var coordinates = line.Split(" -> ");
        for (var i = 1; i < coordinates.Length; i++)
        {
            var a = Coordinate.Parse(coordinates[i - 1]);
            var b = Coordinate.Parse(coordinates[i]);
            foreach (var c in GetSegment(a, b))
            {
                yield return c;
            }
        }
    }

    private static IEnumerable<Coordinate> GetSegment(Coordinate a, Coordinate b)
    {
        yield return a;
        if (a.X != b.X)
        {
            var increment = a.X < b.X ? 1 : -1;
            var x = a.X;
            var length = Math.Abs(a.X - b.X);
            for (var i = 0; i < length; i++)
            {
                x += increment;
                yield return new Coordinate(x, a.Y);
            }
        }
        else
        {
            var increment = a.Y < b.Y ? 1 : -1;
            var y = a.Y;
            var length = Math.Abs(a.Y - b.Y);
            for (var i = 0; i < length; i++)
            {
                y += increment;
                yield return new Coordinate(a.X, y);
            }
        }
        yield return b;
    }

    private static Coordinate? CalculateNextRestingPosition1(Dictionary<Coordinate, char> grid, int threshold)
    {
        var position = new Coordinate(500, 0);

        while (true)
        {
            if (position.Y >= threshold)
            {
                return null;
            }

            if (!grid.ContainsKey(position.Below))
            {
                position = position.Below;
            }
            else if (!grid.ContainsKey(position.BelowLeft))
            {
                position = position.BelowLeft;
            }
            else if (!grid.ContainsKey(position.BelowRight))
            {
                position = position.BelowRight;
            }
            else
            {
                return position;
            }
        }
    }

    private static Coordinate CalculateNextRestingPosition2(Dictionary<Coordinate, char> grid, int threshold)
    {
        var position = new Coordinate(500, 0);

        while (true)
        {
            if (position.Y == threshold)
            {
                return position;
            }
            else if (!grid.ContainsKey(position.Below))
            {
                position = position.Below;
            }
            else if (!grid.ContainsKey(position.BelowLeft))
            {
                position = position.BelowLeft;
            }
            else if (!grid.ContainsKey(position.BelowRight))
            {
                position = position.BelowRight;
            }
            else 
            {
                return position;
            }
        }
    }

    private sealed record Coordinate(int X, int Y)
    {
        public static Coordinate Parse(string value)
        {
            var values = value.Split(',');
            return new Coordinate(int.Parse(values[0]), int.Parse(values[1]));
        }

        public Coordinate Below => new(X, Y + 1);
        public Coordinate BelowLeft => new(X - 1, Y + 1);
        public Coordinate BelowRight => new(X + 1, Y + 1);
    }
}
