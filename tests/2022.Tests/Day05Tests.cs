namespace Lokf.AdventOfCode2022.Tests;

public sealed class Day05Tests
{
    [Fact]
    public void Task1()
    {
        var input = File
            .ReadAllLines("Day05Input.txt")
            .ToList();

        var result = Day05.Task1(input);

        result.Should().Be("CMZ");
    }

    [Fact]
    public void Task2()
    {
        var input = File
            .ReadAllLines("Day05Input.txt")
            .ToList();

        var result = Day05.Task2(input);

        result.Should().Be("MCD");
    }
}
