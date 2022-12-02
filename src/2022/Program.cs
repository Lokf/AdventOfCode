using Lokf.AdventOfCode2022;

var input1 = File
    .ReadAllLines(@"Day01Input.txt")
    .ToList();

Console.WriteLine($"Day 1, Task 1: {Day01.Task1(input1)}");
Console.WriteLine($"Day 1, Task 2: {Day01.Task2(input1)}");

var input2 = File
    .ReadAllLines(@"Day02Input.txt")
    .ToList();

Console.WriteLine($"Day 2, Task 1: {Day02.Task1(input2)}");
Console.WriteLine($"Day 2, Task 2: {Day02.Task2(input2)}");