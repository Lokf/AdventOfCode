using System.Text.Json;

namespace Lokf.AdventOfCode2022;

public static partial class Day13
{
    public static int Task1(IEnumerable<string> lines)
    {
        return Parse(lines)
            .Where(pair => pair.IsInOrder())
            .Sum(pair => pair.Index);
    }

    public static int Task2(IEnumerable<string> lines)
    {
        var divider1 = PacketValue.FromJson("[[2]]");
        var divider2 = PacketValue.FromJson("[[6]]");

        var pairs = Parse(lines);
        var packets = new List<PacketValue>();
        packets.AddRange(pairs.Select(pair => pair.Left));
        packets.AddRange(pairs.Select(pair => pair.Right));
        packets.Add(divider1);
        packets.Add(divider2);

        packets.Sort();

        var index1 = packets.IndexOf(divider1) + 1;
        var index2 = packets.IndexOf(divider2) + 1;

        return index1 * index2;
    }

    private static IEnumerable<Pair> Parse(IEnumerable<string> lines)
    {
        return lines
            .Chunk(3)
            .Select((chunk, i) => ParsePair(chunk, i + 1))
            .ToList();
    }

    private static Pair ParsePair(string[] input, int index)
    {
        return new Pair(index, PacketValue.FromJson(input[0]), PacketValue.FromJson(input[1]));
    }

    private abstract record PacketValue : IComparable<PacketValue>
    {
        public static PacketValue FromJson(string json)
            => FromJson((JsonElement)JsonSerializer.Deserialize<object>(json)!);

        public static PacketValue FromJson(JsonElement element)
            => element.ValueKind == JsonValueKind.Array
                ? new ListValue(element.EnumerateArray().Select(FromJson).ToArray())
                : new SingleValue(element.GetInt32());

        public int CompareTo(PacketValue? other)
        {
            return (this, other) switch
            {
                (SingleValue l, SingleValue r) => l.CompareTo(r),
                (SingleValue l, ListValue r) => l.CompareTo(r),
                (ListValue l, SingleValue r) => l.CompareTo(r),
                (ListValue l, ListValue r) => l.CompareTo(r),
                _ => throw new NotSupportedException("Unknown comparisson."),
            };
        }
    }

    private sealed record SingleValue(int Value)
        : PacketValue, IComparable<SingleValue>, IComparable<ListValue>
    {
        public int CompareTo(SingleValue? other)
        {
            return Value.CompareTo(other!.Value);
        }

        public int CompareTo(ListValue? other)
        {
            return new ListValue(new PacketValue[1] { this }).CompareTo(other);
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }

    private sealed record ListValue(PacketValue[] Values)
        : PacketValue, IComparable<SingleValue>, IComparable<ListValue>
    {
        public int CompareTo(SingleValue? other)
        {
            return CompareTo(new ListValue(new PacketValue[1] { other! }));
        }

        public int CompareTo(ListValue? other)
        {
            for (var i = 0; i < Values.Length; i++)
            {
                if (i == other!.Values.Length)
                {
                    return 1;
                }

                var compare = Values[i].CompareTo(other.Values[i]);
                if (compare == 0)
                {
                    continue;
                }

                return compare;
            }

            return Values.Length.CompareTo(other!.Values.Length);
        }

        public override string ToString()
        {
            return $"[{string.Join(',', Values.Select(value => value.ToString()))}]";
        }
    }

    private sealed record Pair(int Index, PacketValue Left, PacketValue Right)
    {
        public bool IsInOrder()
        {
            return Left.CompareTo(Right) < 0;
        }
    }
}
