namespace Lokf.AdventOfCode2022.Tests;

public sealed class Day04Tests
{
    [Fact]
    public void Task1()
    {
        var input = File
            .ReadAllLines(@"Day04Input.txt")
            .ToList();

        var result = Day04.Task1(input);

        result.Should().Be(2);
    }

    [Fact]
    public void Task2()
    {
        var input = File
            .ReadAllLines(@"Day04Input.txt")
            .ToList();

        var result = Day04.Task2(input);

        result.Should().Be(4);
    }
}
