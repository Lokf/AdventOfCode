namespace Lokf.AdventOfCode2022.Tests;

public sealed class Day12Tests
{
    [Fact]
    public void Task1()
    {
        var input = File
            .ReadAllLines("Day12Input.txt")
            .ToList();

        var result = Day12.Task1(input);

        result.Should().Be(31);
    }

    [Fact]
    public void Task2()
    {
        var input = File
            .ReadAllLines("Day12Input.txt")
            .ToList();

        var result = Day12.Task2(input);

        result.Should().Be(29);
    }
}
