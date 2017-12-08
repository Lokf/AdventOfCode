using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    public class Day8
    {
        public static int max = 0;

        public static int Task1(List<string> instructions)
        {
            var kalle = instructions.Select(x => x.Substring(0, x.IndexOf(' '))).Distinct();
            var registers = new Dictionary<string, int>();
            foreach (var k in kalle)
            {
                registers.Add(k, 0);
            }
           
            foreach (var instruction in instructions)
            {
                Execute(instruction, registers);
            }

            return registers.Values.Max();
        }

        public static int Task2(List<string> instructions)
        {
            var kalle = instructions.Select(x => x.Substring(0, x.IndexOf(' '))).Distinct();
            var registers = new Dictionary<string, int>();
            foreach (var k in kalle)
            {
                registers.Add(k, 0);
            }

            foreach (var instruction in instructions)
            {
                Execute(instruction, registers);
            }

            return max;
        }

        private static void Execute(string instruction, Dictionary<string, int> registers)
        {
            var parts = instruction
                .Split(' ');

 
            var k = registers[parts[4]];
            var c = parts[5];
            var d = int.Parse(parts[6]);

            if (GetOperator(c, k, d)) {
                if (parts[1] == "inc")
                {
                    registers[parts[0]] += int.Parse(parts[2]);                    
                }
                else
                {
                    registers[parts[0]] -= int.Parse(parts[2]);
                }
                if (registers[parts[0]] > max)
                {
                    max = registers[parts[0]];
                }
            }
        }

        private static bool GetOperator(string kalle, int a, int b)
        {
            switch (kalle)
            {
                case "==":
                    return a == b;
                case "!=":
                    return a != b;
                case "<":
                    return a < b;
                case "<=":
                    return a <= b;
                case ">":
                    return a > b;
                case ">=":
                    return a >= b;
                default:
                    throw new ArgumentOutOfRangeException("kalle");
            }
        }
    }
}
