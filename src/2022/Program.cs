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

var input3 = File
    .ReadAllLines(@"Day03Input.txt")
    .ToList();
Console.WriteLine($"Day 3, Task 1: {Day03.Task1(input3)}");
Console.WriteLine($"Day 3, Task 2: {Day03.Task2(input3)}");

var input4 = File
    .ReadAllLines(@"Day04Input.txt")
    .ToList();
Console.WriteLine($"Day 4, Task 1: {Day04.Task1(input4)}");
Console.WriteLine($"Day 4, Task 2: {Day04.Task2(input4)}");
