namespace Lokf.AdventOfCode2022;

public static partial class Day10
{
    public static int Task1(IEnumerable<string> lines)
    {
        return CalculateRegisterValues(lines)
            .Select((x, i) => x * (i + 1))
            .Where((a, i) => (i - 19) % 40 == 0)
            .Take(6)
            .Sum();
    }

    public static IEnumerable<string> Task2(IEnumerable<string> lines)
    {
        return CalculateRegisterValues(lines)
            .Select((x, i) => Math.Abs(x - (i % 40)) < 2 ? '#' : '.')
            .Chunk(40)
            .Select(row => new string(row));
    }

    private static IEnumerable<int> CalculateRegisterValues(IEnumerable<string> lines)
    {
        var x = 1;
        foreach (var line in lines)
        {
            if (line == "noop")
            {
                yield return x;
                continue;
            }

            var value = int.Parse(line[5..]);
            yield return x;
            yield return x;
            x += value;
        }
    }
}
