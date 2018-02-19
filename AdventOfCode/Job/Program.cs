using AdventOfCode;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Job
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Advent of Code!");

            var captha = File.
                ReadAllText("Day01.txt");
            Console.WriteLine("Day 1:");
            Console.WriteLine($"Task 1: {Day01.Task1(captha)}");
            Console.WriteLine($"Task 2: {Day01.Task2(captha)}");
            Console.WriteLine();

            var speadsheet = File
                .ReadAllLines("Day02.txt")
                .ToList();
            Console.WriteLine("Day 2:");
            Console.WriteLine($"Task1: {Day02.Task1(speadsheet)}");
            Console.WriteLine($"Task2: {Day02.Task2(speadsheet)}");
            Console.WriteLine();

            var square = 361527;
            Console.WriteLine("Day 3:");
            Console.WriteLine($"Task1: {Day03.Task1(square)}");
            Console.WriteLine($"Task2: {Day03.Task2(square)}");
            Console.WriteLine();

            var passphrases = File
                .ReadAllLines("Day04.txt")
                .ToList();
            Console.WriteLine("Day 4:");
            Console.WriteLine($"Task1: {Day04.Task1(passphrases)}");
            Console.WriteLine($"Task2: {Day04.Task2(passphrases)}");
            Console.WriteLine();

            var jumpOffsets = File
                .ReadAllLines("Day05.txt")
                .ToList();
            Console.WriteLine("Day 5:");
            Console.WriteLine($"Task1: {Day05.Task1(jumpOffsets)}");
            Console.WriteLine($"Task2: {Day05.Task2(jumpOffsets)}");
            Console.WriteLine();

            var blockDistribution = "2	8	8	5	4	2	3	1	5	5	1	2	15	13	5	14";
            Console.WriteLine("Day 6:");
            Console.WriteLine($"Task1: {Day06.Task1(blockDistribution)}");
            Console.WriteLine($"Task2: {Day06.Task2(blockDistribution)}");
            Console.WriteLine();

            var towers = File
                .ReadAllLines("Day07.txt")
                .ToList();
            Console.WriteLine("Day 7:");
            Console.WriteLine($"Task1: {Day07.Task1(towers)}");
            Console.WriteLine($"Task2: {Day07.Task2(towers)}");
            Console.WriteLine();

            var instructions = File
               .ReadAllLines("Day08.txt")
               .ToList();
            Console.WriteLine("Day 8:");
            Console.WriteLine($"Task1: {Day08.Task1(instructions)}");
            Console.WriteLine($"Task2: {Day08.Task2(instructions)}");
            Console.WriteLine();

            var stream = File
               .ReadAllText("Day09.txt");
            Console.WriteLine("Day 9:");
            Console.WriteLine($"Task1: {Day09.Task1(stream)}");
            Console.WriteLine($"Task2: {Day09.Task2(stream)}");
            Console.WriteLine();

            var lengths = "192,69,168,160,78,1,166,28,0,83,198,2,254,255,41,12"
                .Split(',')
                .Select(x => int.Parse(x))
                .ToList();
            var lengths2 = "192,69,168,160,78,1,166,28,0,83,198,2,254,255,41,12".ToCharArray();
            Console.WriteLine("Day 10:");
            Console.WriteLine($"Task1: {Day10.Task1(lengths, 256)}");
            Console.WriteLine($"Task2: {Day10.Task2(lengths2, 256)}");
            Console.WriteLine();

            var path = File
               .ReadAllText("Day11.txt")
               .Split(',')
               .ToList();
            Console.WriteLine("Day 11:");
            Console.WriteLine($"Task1: {Day11.Task1(path)}");
            Console.WriteLine($"Task2: {Day11.Task2(path)}");
            Console.WriteLine();

            var pipes = File
               .ReadAllLines("Day12.txt")
               .ToList();
            Console.WriteLine("Day 12:");
            Console.WriteLine($"Task1: {Day12.Task1(pipes)}");
            Console.WriteLine($"Task2: {Day12.Task2(pipes)}");
            Console.WriteLine();

            var layers = File
               .ReadAllLines("Day13.txt")
               .ToList();
            Console.WriteLine("Day 13:");
            Console.WriteLine($"Task1: {Day13.Task1(layers)}");
            Console.WriteLine($"Task2: {Day13.Task2(layers)}");
            Console.WriteLine();

            var key = "nbysizxe";
            Console.WriteLine("Day 14:");
            Console.WriteLine($"Task1: {Day14.Task1(key)}");
            Console.WriteLine($"Task2: {Day14.Task2(key)}");
            Console.WriteLine();

            Console.WriteLine("Day 15:");
            Console.WriteLine($"Task1: {Day15.Task1(512, 191)}");
            Console.WriteLine($"Task2: {Day15.Task2(512, 191)}");
            Console.WriteLine();

            var danceMoves = File
               .ReadAllText("Day16.txt");
            Console.WriteLine("Day 16:");
            Console.WriteLine($"Task1: {Day16.Task1(16, danceMoves)}");
            Console.WriteLine($"Task2: {Day16.Task2(16, danceMoves, 1_000_000_000)}");
            Console.WriteLine();

            Console.WriteLine("Day 17:");
            Console.WriteLine($"Task1: {Day17.Task1(335)}");
            Console.WriteLine($"Task2: {Day17.Task2(335)}");
            Console.WriteLine();

            var instructions2 = File
               .ReadAllLines("Day18.txt")
               .ToArray();
            Console.WriteLine("Day 18:");
            Console.WriteLine($"Task1: {Day18.Task1(instructions2)}");
            Console.WriteLine($"Task2: {Day18.Task2(instructions2)}");
            Console.WriteLine();

            var routingDiagram = File
               .ReadAllLines("Day19.txt")
               .ToArray();
            Console.WriteLine("Day 19:");
            Console.WriteLine($"Task1: {Day19.Task1(routingDiagram)}");
            Console.WriteLine($"Task2: {Day19.Task2(routingDiagram)}");
            Console.WriteLine();

            var particles = File
               .ReadAllLines("Day20.txt")
               .ToArray();
            Console.WriteLine("Day 20:");
            Console.WriteLine($"Task1: {Day20.Task1(particles)}");
            Console.WriteLine($"Task2: {Day20.Task2(particles)}");
            Console.WriteLine();

            var rules = File
               .ReadAllLines("Day21.txt")
               .ToArray();
            Console.WriteLine("Day 21:");
            Console.WriteLine($"Task1: {Day21.Task1(rules, 5)}");
            Console.WriteLine($"Task2: {Day21.Task1(rules, 18)}");
            Console.WriteLine();

            var rows = File
               .ReadAllLines("Day22.txt")
               .ToArray();
            Console.WriteLine("Day 22:");
            Console.WriteLine($"Task1: {Day22.Task1(rows, 10_000)}");
            Console.WriteLine($"Task2: {Day22.Task2(rows, 10_000_000)}");
            Console.WriteLine();

            var instructions3 = File
               .ReadAllLines("Day23.txt")
               .ToArray();
            Console.WriteLine("Day 23:");
            Console.WriteLine($"Task1: {Day23.Task1(instructions3)}");
            Console.WriteLine($"Task2: {Day23.Task2(instructions3)}");
            Console.WriteLine();

            var components = File
               .ReadAllLines("Day24.txt")
               .ToArray();
            Console.WriteLine("Day 24:");
            Console.WriteLine($"Task1: {Day24.Task1(components)}");
            Console.WriteLine($"Task2: {Day24.Task2(components)}");
            Console.WriteLine();

            var blueprint = File
               .ReadAllLines("Day25.txt")
               .ToArray();
            Console.WriteLine("Day 25:");
            Console.WriteLine($"Task1: {Day25.Task1(blueprint)}");
            Console.WriteLine($"Task2: {Day25.Task2(blueprint)}");
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
