namespace Lokf.AdventOfCode2022;

public static class Day03
{
    public static int Task1(IEnumerable<string> lines)
    {
        return lines
            .Select(CalculatePrioritOfMissplacedItem)
            .Sum();
    }

    public static int Task2(IEnumerable<string> lines)
    {
        return lines
            .Chunk(3)
            .Select(CalculatePriorityOfBadge)
            .Sum();
    }

    private static int CalculatePrioritOfMissplacedItem(string rucksack)
    {
        var firstCompartment = rucksack[..(rucksack.Length / 2)].ToHashSet();

        foreach (var item in rucksack[(rucksack.Length / 2)..])
        {
            if (firstCompartment.Contains(item))
            {
                return CalculatePriority(item);
            }
        }

        return 0;
    }

    private static int CalculatePriorityOfBadge(IEnumerable<string> rucksacks)
    {
        var items = rucksacks.First().ToHashSet();

        foreach (var rucksack in rucksacks.Skip(1))
        {
            items.IntersectWith(rucksack);
        }

        return CalculatePriority(items.Single());
    }

    private static int CalculatePriority(char item)
    {
        if (char.IsAsciiLetterLower(item))
        {
            return item - 'a' + 1;
        }

        return item - 'A'+ 27;
    }
}
