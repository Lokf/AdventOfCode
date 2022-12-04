namespace Lokf.AdventOfCode2022.Tests;

public sealed class Day03Tests
{
    [Fact]
    public void Task1()
    {
        var input = File
            .ReadAllLines(@"Day03Input.txt")
            .ToList();

        var result = Day03.Task1(input);

        result.Should().Be(157);
    }

    [Fact]
    public void Task2()
    {
        var input = File
            .ReadAllLines(@"Day03Input.txt")
            .ToList();

        var result = Day03.Task2(input);

        result.Should().Be(70);
    }
}
