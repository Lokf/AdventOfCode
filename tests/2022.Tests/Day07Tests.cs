namespace Lokf.AdventOfCode2022.Tests;

public sealed class Day07Tests
{
    [Fact]
    public void Task1()
    {
        var input = File
            .ReadAllLines(@"Day07Input.txt")
            .ToList();

        var result = Day07.Task1(input);

        result.Should().Be(95437);
    }

    [Fact]
    public void Task2()
    {
        var input = File
            .ReadAllLines(@"Day07Input.txt")
            .ToList();

        var result = Day07.Task2(input);

        result.Should().Be(24933642);
    }
}
