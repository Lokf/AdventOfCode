namespace Lokf.AdventOfCode2022.Tests;

public sealed class Day10Tests
{
    [Fact]
    public void Task1()
    {
        var input = File
            .ReadAllLines("Day10Input.txt")
            .ToList();

        var result = Day10.Task1(input);

        result.Should().Be(13_140);
    }

    [Fact]
    public void Task2()
    {
        var input = File
            .ReadAllLines("Day10Input.txt")
            .ToList();

        var result = Day10.Task2(input);

        var expectedResult = new List<string>
        {
            "##..##..##..##..##..##..##..##..##..##..",
            "###...###...###...###...###...###...###.",
            "####....####....####....####....####....",
            "#####.....#####.....#####.....#####.....",
            "######......######......######......####",
            "#######.......#######.......#######.....",
        }; 

        result.Should().BeEquivalentTo(expectedResult);
    }
}
