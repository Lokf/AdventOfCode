namespace Lokf.AdventOfCode2022.Tests;

public sealed class Day13Tests
{
    [Fact]
    public void Task1()
    {
        var input = File
            .ReadAllLines("Day13Input1.txt")
            .ToList();

        var result = Day13.Task1(input);

        result.Should().Be(13);
    }

    [Fact]
    public void Task2()
    {
        var input = File
            .ReadAllLines("Day13Input2.txt")
            .ToList();

        var result = Day13.Task2(input);

        result.Should().Be(140);
    }
}
