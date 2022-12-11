using Lokf.AdventOfCode2022;

var input1 = File
    .ReadAllLines("Day01Input.txt")
    .ToList();
Console.WriteLine($"Day 1, Task 1: {Day01.Task1(input1)}");
Console.WriteLine($"Day 1, Task 2: {Day01.Task2(input1)}");

var input2 = File
    .ReadAllLines("Day02Input.txt")
    .ToList();
Console.WriteLine($"Day 2, Task 1: {Day02.Task1(input2)}");
Console.WriteLine($"Day 2, Task 2: {Day02.Task2(input2)}");

var input3 = File
    .ReadAllLines("Day03Input.txt")
    .ToList();
Console.WriteLine($"Day 3, Task 1: {Day03.Task1(input3)}");
Console.WriteLine($"Day 3, Task 2: {Day03.Task2(input3)}");

var input4 = File
    .ReadAllLines("Day04Input.txt")
    .ToList();
Console.WriteLine($"Day 4, Task 1: {Day04.Task1(input4)}");
Console.WriteLine($"Day 4, Task 2: {Day04.Task2(input4)}");

var input5 = File
    .ReadAllLines("Day05Input.txt")
    .ToList();
Console.WriteLine($"Day 5, Task 1: {Day05.Task1(input5)}");
Console.WriteLine($"Day 5, Task 2: {Day05.Task2(input5)}");

var input6 = File
    .ReadAllText("Day06Input.txt");
Console.WriteLine($"Day 6, Task 1: {Day06.Task1(input6)}");
Console.WriteLine($"Day 6, Task 2: {Day06.Task2(input6)}");

var input7 = File
    .ReadAllLines("Day07Input.txt")
    .ToList();
Console.WriteLine($"Day 7, Task 1: {Day07.Task1(input7)}");
Console.WriteLine($"Day 7, Task 2: {Day07.Task2(input7)}");

var input8 = File
    .ReadAllLines("Day08Input.txt")
    .ToList();
Console.WriteLine($"Day 8, Task 1: {Day08.Task1(input8)}");
Console.WriteLine($"Day 8, Task 2: {Day08.Task2(input8)}");

var input9 = File
    .ReadAllLines("Day09Input.txt")
    .ToList();
Console.WriteLine($"Day 9, Task 1: {Day09.Task1(input9)}");
Console.WriteLine($"Day 9, Task 2: {Day09.Task2(input9)}");

var input10 = File
    .ReadAllLines("Day10Input.txt")
    .ToList();
Console.WriteLine($"Day 10, Task 1: {Day10.Task1(input10)}");
var output = Day10.Task2(input10);
Console.WriteLine("Day 10, Task 2:");
foreach (var row in output)
{
    Console.WriteLine(row);
}

var input11 = File
    .ReadAllLines("Day11Input.txt")
    .ToList();
Console.WriteLine($"Day 11, Task 1: {Day11.Task1(input11)}");
Console.WriteLine($"Day 11, Task 2: {Day11.Task2(input11)}");
