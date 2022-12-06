namespace Lokf.AdventOfCode2022;

public static partial class Day06
{
    public static int Task1(string signal)
    {
        return DetectUniqueWindow(signal, 4);
    }

    public static int Task2(string signal)
    {
        return DetectUniqueWindow(signal, 14);
    }

    private static int DetectUniqueWindow(string signal, int threshold)
    {
        var window = new Queue<char>();
        var count = threshold;
        foreach (var character in signal.Take(threshold))
        {
            window.Enqueue(character);
        }

        foreach (var character in signal.Skip(threshold))
        {
            if (window.Distinct().Count() == threshold)
            {
                break;
            }

            window.Dequeue();
            window.Enqueue(character);
            count++;
        }

        return count;
    }
}
