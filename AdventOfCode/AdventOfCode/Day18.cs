using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public class Day18
    {        
        public static long Task1(string[] instructions)
        {
            var registers = new Dictionary<char, long>();

            var index = 0L;
            var sound = 0L;
            while (true)
            {
                var instruction = instructions[index]
                    .Split(' ')
                    .ToArray();

                switch (instruction[0])
                {
                    case "snd":
                        sound = GetValue(registers, instruction[1][0]);
                        break;
                    case "set":
                        SetValue(registers, instruction[1][0], GetValue(registers, instruction[2]));
                        break;
                    case "add":
                        SetValue(registers, instruction[1][0], GetValue(registers, instruction[1][0]) + GetValue(registers, instruction[2]));
                        break;
                    case "mul":
                        SetValue(registers, instruction[1][0], GetValue(registers, instruction[1][0]) * GetValue(registers, instruction[2]));
                        break;
                    case "mod":
                        SetValue(registers, instruction[1][0], GetValue(registers, instruction[1][0]) % GetValue(registers, instruction[2]));
                        break;
                    case "rcv":
                        if (GetValue(registers, instruction[1][0]) != 0)
                        {
                            return sound;
                        }
                        break;
                    case "jgz":
                        if (GetValue(registers, instruction[1][0]) > 0)
                        {
                            index += GetValue(registers, instruction[2]);
                            continue;
                        }
                        break;
                }

                index++;
            }
        }

        public static int Task2(string[] instructions)
        {
            var program0 = new Program(0, instructions);
            var program1 = new Program(1, instructions);
            
            var send0 = new Queue<long>();
            var send1 = new Queue<long>();

            while (program0.ExecuteNextInstruction(send0, send1) || program1.ExecuteNextInstruction(send1, send0))
            {
                ;
            }

            return program1.SendCount;
        }

        private static long GetValue(Dictionary<char, long> dictionary, char register)
        {
            if (dictionary.TryGetValue(register, out var value))
            {
                return value;
            }

            return 0;
        }

        private static long GetValue(Dictionary<char, long> dictionary, string value)
        {
            if (long.TryParse(value, out var kalle))
            {
                return kalle;
            }

            return GetValue(dictionary, value[0]);
        }

        private static void SetValue(Dictionary<char, long> dictionary, char key, long value)
        {
            if (dictionary.ContainsKey(key))
            {
                dictionary[key] = value;
                return;
            }

            dictionary.Add(key, value);
        }

        private class Program
        {
            private readonly Dictionary<char, long> registers = new Dictionary<char, long>();
            private readonly string[] instructions;
            private long index = 0;

            public int SendCount { get; private set; } = 0;

            public Program(long programId, string[] instructions)
            {
                var registerKeys = instructions
                    .Select(x => x.Split(' '))
                    .ToArray()[1]
                    .Distinct()
                    .Select(x => x[0]);

                foreach (var key in registerKeys)
                {
                    registers.Add(key, 0);
                }

                registers['p'] = programId;

                this.instructions = instructions; 
            }

            public bool ExecuteNextInstruction(Queue<long> send, Queue<long> receive)
            {
                if (index < 0 || index >= instructions.Length)
                {
                    return false;
                }

                var instruction = instructions[index]
                    .Split(' ')
                    .ToArray();

                switch (instruction[0])
                {
                    case "snd":
                        send.Enqueue(GetValue(instruction[1]));
                        SendCount++;
                        break;
                    case "set":
                        registers[instruction[1][0]] = GetValue(instruction[2]);
                        break;
                    case "add":
                        registers[instruction[1][0]] += GetValue(instruction[2]);
                        break;
                    case "mul":
                        registers[instruction[1][0]] *= GetValue(instruction[2]);
                        break;
                    case "mod":
                        registers[instruction[1][0]] %= GetValue(instruction[2]);
                        break;
                    case "rcv":
                        if (receive.Count == 0)
                        {
                            return false;
                        }
                        registers[instruction[1][0]] = receive.Dequeue();
                        break;
                    case "jgz":
                        if (GetValue(instruction[1]) > 0)
                        {
                            index += GetValue(instruction[2]) - 1;
                        }
                        break;
                }

                index++;
                return true;
            }

            private long GetValue(string value)
            {
                if (long.TryParse(value, out var kalle))
                {
                    return kalle;
                }

                return registers[value[0]];
            }
        }
    }
}
