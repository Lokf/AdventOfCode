using System.Text.RegularExpressions;

namespace Lokf.AdventOfCode2022;

public static partial class Day05
{
    public static string Task1(IEnumerable<string> lines)
    {
        var (dock, instrctions) = Parse(lines.ToList());

        foreach (var instruction in instrctions)
        {
            dock.MoveOneByOne(instruction);
        }

        return dock.TopCrates();
    }

    public static string Task2(IEnumerable<string> lines)
    {
        var (dock, instrctions) = Parse(lines.ToList());

        foreach (var instruction in instrctions)
        {
            dock.MoveInOneMove(instruction);
        }

        return dock.TopCrates();
    }

    private static (Dock Dock, IEnumerable<Instruction> Instructions) Parse(IReadOnlyCollection<string> lines)
    {
        return (ParseStacks(lines), ParseInstructions(lines));
    }

    private static Dock ParseStacks(IReadOnlyCollection<string> lines)
    {
        var numberOfStacks = lines.First().Length / 4 + 1;
        var dock = new Stack<char>[numberOfStacks];

        for (var i = 0; i < numberOfStacks; i++)
        {
            dock[i] = new Stack<char>();
        }

        foreach (var line in lines)
        {
            if (!line.Contains('['))
            {
                for (var i = 0; i < numberOfStacks; i++)
                {
                    dock[i] = new Stack<char>(dock[i]);
                }

                return new Dock(dock);
            }

            foreach (var index in Enumerable.Range(0, numberOfStacks))
            {
                var pos = index * 4 + 1;
                var crate = line[pos];
                if (crate == ' ')
                {
                    continue;
                }

                dock[index].Push(crate);
            }
        }

        throw new ArgumentException("Invalid input");
    }

    private static IEnumerable<Instruction> ParseInstructions(IEnumerable<string> lines)
    {
        var regex = InstructionFormat();

        foreach (var line in lines)
        {
            if (!line.StartsWith("move"))
            {
                continue;
            }

            var kalle = regex.Match(line);
            yield return new Instruction(
                int.Parse(kalle.Groups["source"].Value),
                int.Parse(kalle.Groups["target"].Value),
                int.Parse(kalle.Groups["quantity"].Value));
        }
    }

    private sealed class Dock
    {
        private readonly Stack<char>[] stacks;

        public Dock(Stack<char>[] stacks)
        {
            this.stacks = stacks;
        }

        public void MoveOneByOne(Instruction instruction)
        {
            foreach (var _ in Enumerable.Range(0, instruction.Quantity))
            {
                stacks[instruction.TargetStack - 1].Push(stacks[instruction.SourceStack - 1].Pop());
            }
        }

        public void MoveInOneMove(Instruction instruction)
        {
            var temp = new Stack<char>();
            foreach (var _ in Enumerable.Range(0, instruction.Quantity))
            {
                temp.Push(stacks[instruction.SourceStack - 1].Pop());
            }

            foreach (var crate in temp)
            {
                stacks[instruction.TargetStack - 1].Push(crate);
            }
        }

        public string TopCrates()
        {
            return new string(stacks
                .Select(x => x.Pop())
                .ToArray());
        }
    }

    private sealed record Instruction(int SourceStack, int TargetStack, int Quantity);

    [GeneratedRegex("^move (?'quantity'\\d+) from (?'source'\\d+) to (?'target'\\d+)$")]
    private static partial Regex InstructionFormat();
}
