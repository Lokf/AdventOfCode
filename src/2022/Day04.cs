namespace Lokf.AdventOfCode2022;

public static class Day04
{
    public static int Task1(IEnumerable<string> lines)
    {
        return Parse(lines)
            .Count(assignment => assignment.First.HasFullOverlap(assignment.Second));
    }

    public static int Task2(IEnumerable<string> lines)
    {
        return Parse(lines)
            .Count(assignment => assignment.First.HasAnyOverlap(assignment.Second));
    }

    private static IEnumerable<(Assignment First, Assignment Second)> Parse(IEnumerable<string> lines)
    {
        foreach (var line in lines)
        {
            var index = line.IndexOf(',');
            var first = Parse(line[..(index)]);
            var second = Parse(line[(index+1)..]);

            yield return (first, second);
        }
    }

    private static Assignment Parse(string input)
    {
        var index = input.IndexOf('-');
        var lower = int.Parse(input[..(index)]);
        var upper = int.Parse(input[(index + 1)..]);

        return new Assignment(lower, upper);
    }

    private sealed record Assignment(int LowerBound, int UpperBound)
    {
        public bool HasFullOverlap(Assignment other)
        {
            if (LowerBound == other.LowerBound)
            {
                return true;
            }
            else if (LowerBound < other.LowerBound)
            {
                return UpperBound >= other.UpperBound;
            }
            else
            {
                return UpperBound <= other.UpperBound;
            }
        }

        public bool HasAnyOverlap(Assignment other)
        {
            if (LowerBound <= other.LowerBound)
            {
                return UpperBound >= other.LowerBound;
            }
            else
            {
                return LowerBound <= other.UpperBound;
            }
        }
    }
}
