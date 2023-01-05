namespace Lokf.AdventOfCode2022.Tests;

public sealed class Day14Tests
{
    [Fact]
    public void Task1()
    {
        var input = File
            .ReadAllLines("Day14Input.txt")
            .ToList();

        var result = Day14.Task1(input);

        result.Should().Be(24);
    }

    [Fact]
    public void Task2()
    {
        var input = File
            .ReadAllLines("Day14Input.txt")
            .ToList();

        var result = Day14.Task2(input);

        result.Should().Be(93);
    }
}
