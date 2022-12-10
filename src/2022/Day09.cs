namespace Lokf.AdventOfCode2022;

public static partial class Day09
{
    public static int Task1(IEnumerable<string> lines)
    {
        var motions = Parse(lines);

        return CalcualteVisistedPositionsByTail1(motions).Count;
    }

    public static int Task2(IEnumerable<string> lines)
    {
        var motions = Parse(lines);

        return CalcualteVisistedPositionsByTail2(motions).Count;
    }

    private static IEnumerable<Motion> Parse(IEnumerable<string> lines)
    {
        return lines.Select(line => new Motion(line[0], int.Parse(line[2..])));
    }

    private static HashSet<(int, int)> CalcualteVisistedPositionsByTail1(IEnumerable<Motion> motions)
    {
        var head = (0, 0);
        var tail = (0, 0);
        var visitedPositions = new HashSet<(int, int)>
        {
            tail,
        };

        foreach (var motion in motions)
        {
            foreach (var _ in Enumerable.Range(0, motion.NumberOfSteps))
            {
                head = MoveHead(head, motion.Direction);
                tail = MoveTail(head, tail);
                visitedPositions.Add(tail);
            }
        }

        return visitedPositions;
    }

    private static HashSet<(int, int)> CalcualteVisistedPositionsByTail2(IEnumerable<Motion> motions)
    {
        var head = (0, 0);
        var tail1 = (0, 0);
        var tail2 = (0, 0);
        var tail3 = (0, 0);
        var tail4 = (0, 0);
        var tail5 = (0, 0);
        var tail6= (0, 0);
        var tail7 = (0, 0);
        var tail8 = (0, 0);
        var tail9 = (0, 0);
        var visitedPositions = new HashSet<(int, int)>
        {
            tail9,
        };

        foreach (var motion in motions)
        {
            foreach (var _ in Enumerable.Range(0, motion.NumberOfSteps))
            {
                head = MoveHead(head, motion.Direction);
                tail1 = MoveTail(head, tail1);
                tail2 = MoveTail(tail1, tail2);
                tail3 = MoveTail(tail2, tail3);
                tail4 = MoveTail(tail3, tail4);
                tail5 = MoveTail(tail4, tail5);
                tail6 = MoveTail(tail5, tail6);
                tail7 = MoveTail(tail6, tail7);
                tail8 = MoveTail(tail7, tail8);
                tail9 = MoveTail(tail8, tail9);
                visitedPositions.Add(tail9);
            }
        }

        return visitedPositions;
    }

    private static (int, int) MoveHead((int, int) head, char direction)
    {
        return direction switch
        {
            'U' => (head.Item1, head.Item2 + 1),
            'D' => (head.Item1, head.Item2 - 1),
            'R' => (head.Item1 + 1, head.Item2),
            'L' => (head.Item1 - 1, head.Item2),
            _ => throw new ArgumentOutOfRangeException(nameof(direction)),
        };
    }

    private static (int, int) MoveTail((int, int) head, (int, int) tail)
    {
        if (IsTouching(head, tail))
        {
            return tail;
        }

        var x = CalculateNewPosition(head.Item1, tail.Item1);
        var y = CalculateNewPosition(head.Item2, tail.Item2);

        return (x, y);
    }

    private static int CalculateNewPosition(int head, int tail)
    {
        return tail.CompareTo(head) switch
        {
            0 => tail,
            -1 => tail + 1,
            +1 => tail - 1,
            _ => throw new InvalidOperationException("Unknown comparison"),
        };
    }

    private static bool IsTouching((int, int) head, (int, int) tail)
    {
        var xDiff = Math.Abs(head.Item1 - tail.Item1);
        var yDiff = Math.Abs(head.Item2 - tail.Item2);

        return xDiff < 2 && yDiff < 2;
    }

    private sealed record Motion(char Direction, int NumberOfSteps);
}
