namespace Lokf.AdventOfCode2022.Tests;

public sealed class Day02Tests
{
    [Fact]
    public void Task1()
    {
        var input = File
            .ReadAllLines("Day02Input.txt")
            .ToList();

        var result = Day02.Task1(input);

        result.Should().Be(15);
    }

    [Fact]
    public void Task2()
    {
        var input = File
            .ReadAllLines("Day02Input.txt")
            .ToList();

        var result = Day02.Task2(input);

        result.Should().Be(12);
    }
}
 