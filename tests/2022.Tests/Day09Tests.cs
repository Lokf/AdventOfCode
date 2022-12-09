namespace Lokf.AdventOfCode2022.Tests;

public sealed class Day09Tests
{
    [Fact]
    public void Task1()
    {
        var input = File
            .ReadAllLines("Day09Input1.txt")
            .ToList();

        var result = Day09.Task1(input);

        result.Should().Be(13);
    }

    [Theory]
    [InlineData("Day09Input1.txt", 1)]
    [InlineData("Day09Input2.txt", 36)]
    public void Task2(string file, int expectedValue)
    {
        var input = File
            .ReadAllLines(file)
            .ToList();

        var result = Day09.Task2(input);

        result.Should().Be(expectedValue);
    }
}
