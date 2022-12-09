namespace Lokf.AdventOfCode2022.Tests;

public sealed class Day08Tests
{
    [Fact]
    public void Task1()
    {
        var input = File
            .ReadAllLines("Day08Input.txt")
            .ToList();

        var result = Day08.Task1(input);

        result.Should().Be(21);
    }

    [Fact]
    public void Task2()
    {
        var input = File
            .ReadAllLines("Day08Input.txt")
            .ToList();

        var result = Day08.Task2(input);

        result.Should().Be(8);
    }
}
