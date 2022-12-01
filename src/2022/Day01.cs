namespace Lokf.AdventOfCode2022;

public static class Day01
{
    public static int Task1(IEnumerable<string> lines)
    {
        return Parse(lines)
            .MaxBy(a => a.Foods.Sum())
            .Foods
            .Sum();
    }

    public static int Task2(IEnumerable<string> lines)
    {
        return Parse(lines)
            .OrderByDescending(elf => elf.Foods.Sum())
            .Take(3)
            .Select(elf => elf.Foods.Sum())
            .Sum();
    }

    private static IEnumerable<Elf> Parse(IEnumerable<string> input)
    {
        var temp = new List<int>();

        foreach (var line in input)
        {
            if (string.IsNullOrEmpty(line))
            {
                if (temp.Any())
                {
                    yield return new Elf(temp.ToList());
                }

                temp.Clear();
                continue;
            }

            temp.Add(int.Parse(line));
        }

        if (temp.Any())
        {
            yield return new Elf(temp.ToList());
        }
    }

    private sealed record Elf(
        IEnumerable<int> Foods);
}
