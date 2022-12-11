using System.Text.RegularExpressions;

namespace Lokf.AdventOfCode2022;

public static partial class Day11
{
    public static long Task1(IEnumerable<string> lines)
    {
        var monkeys = Parse(lines);
        Play(monkeys, x => (int)(x / 3), 20);
        return CalculateMonkeyBusiness(monkeys);
    }

    public static long Task2(IEnumerable<string> lines)
    {
        var monkeys = Parse(lines);
        var lcm = monkeys.Aggregate(1, (acc, monkey) => acc * monkey.Divisor);
        Play(monkeys, x => (int)(x % lcm), 10_000);
        return CalculateMonkeyBusiness(monkeys);
    }

    private static Monkey[] Parse(IEnumerable<string> lines)
    {
        return lines
            .Chunk(7)
            .Select(ParseMonkey)
            .ToArray();
    }

    private static Monkey ParseMonkey(string[] lines)
    {
        var items = lines[1][18..].Split(", ").Select(int.Parse);
        var operation = ParseOperation(lines[2]);
        var divisor = int.Parse(lines[3][21..]);
        var trueReceiver = int.Parse(lines[4][29..]);
        var falseReceiver = int.Parse(lines[5][30..]);

        return new Monkey(items, operation, divisor, trueReceiver, falseReceiver);
    }

    private static Func<int, long> ParseOperation(string line)
    {
        return line[19..] switch
        {
            var x when OldSquare().IsMatch(x) => x => (long)x * x,
            var x when OldMultiplied().IsMatch(x) => x => x * int.Parse(line.Split(" * ")[1]),
            var x when OldAdded().IsMatch(x) => x => x + int.Parse(line.Split(" + ")[1]),
            _ => throw new ArgumentException("Unknown operation", nameof(line)),
        };
    }

    private static void Play(Monkey[] monkeys, Func<long, int> relief, int numberOfRounds)
    {
        foreach (var _ in Enumerable.Range(0, numberOfRounds))
        {
            foreach (var monkey in monkeys)
            {
                while (true)
                {
                    var item = monkey.Inspect(relief);
                    if (!item.HasValue)
                    {
                        break;
                    }

                    monkeys[item.Value.Receiver].Receive(item.Value.Worry);
                }
            }
        }
    }

    private static long CalculateMonkeyBusiness(Monkey[] monkeys)
    {
        var busiestMonkeys = monkeys
            .Select(monkey => monkey.Activity)
            .OrderByDescending(monkey => monkey)
            .Take(2)
            .ToArray();

        return (long)busiestMonkeys[0] * busiestMonkeys[1];
    }

    private sealed class Monkey
    {
        private readonly Queue<int> items = new();
        private readonly Func<int, long> operation;
        private readonly int divisor;
        private readonly int trueReceiver;
        private readonly int falseReceiver;
        private int numberOfItemsInspected = 0;

        public Monkey(IEnumerable<int> items, Func<int, long> operation, int divisor, int trueReceiver, int falseReceiver)
        {
            foreach (var item in items)
            {
                this.items.Enqueue(item);
            }
            this.operation = operation;
            this.divisor = divisor;
            this.trueReceiver = trueReceiver;
            this.falseReceiver = falseReceiver;
        }

        public int Activity => numberOfItemsInspected;
        public int Divisor => divisor;

        public (int Worry, int Receiver)? Inspect(Func<long, int> relief)
        {
            if (!items.TryDequeue(out var item))
            {
                return null;
            }

            numberOfItemsInspected++;

            item = relief(operation(item));

            return (item, item % divisor == 0 ? trueReceiver : falseReceiver);
        }

        public void Receive(int item)
        {
            items.Enqueue(item);
        }
    }

    [GeneratedRegex(@"old \* old")]
    private static partial Regex OldSquare();
    [GeneratedRegex(@"old \* \d+")]
    private static partial Regex OldMultiplied();
    [GeneratedRegex(@"old \+ \d+")]
    private static partial Regex OldAdded();
}
