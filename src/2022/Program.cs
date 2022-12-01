using Lokf.AdventOfCode2022;

var input = File
    .ReadAllLines(@"Day01Input.txt")
    .ToList();

Console.WriteLine($"Day 1, Task 1: {Day01.Task1(input)}");
Console.WriteLine($"Day 1, Task 2: {Day01.Task2(input)}");