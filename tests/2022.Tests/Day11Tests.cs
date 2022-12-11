namespace Lokf.AdventOfCode2022.Tests;

public sealed class Day11Tests
{
    [Fact]
    public void Task1()
    {
        var input = File
            .ReadAllLines("Day11Input.txt")
            .ToList();

        var result = Day11.Task1(input);

        result.Should().Be(10_605);
    }

    [Fact]
    public void Task2()
    {
        var input = File
            .ReadAllLines("Day11Input.txt")
            .ToList();

        var result = Day11.Task2(input);

        result.Should().Be(2_713_310_158);
    }
}
