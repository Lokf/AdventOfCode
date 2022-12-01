using FluentAssertions;

namespace Lokf.AdventOfCode2022.Tests;

public sealed class Day01Tests
{
    [Fact]
    public void Task1()
    {
        var input = File
            .ReadAllLines(@"Day01Input.txt")
            .ToList();

        var result = Day01.Task1(input);

        result.Should().Be(24_000);
    }

    [Fact]
    public void Task2()
    {
        var input = File
            .ReadAllLines(@"Day01Input.txt")
            .ToList();

        var result = Day01.Task2(input);

        result.Should().Be(45_000);
    }
}
