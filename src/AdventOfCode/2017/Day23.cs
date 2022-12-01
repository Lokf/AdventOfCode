using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode._2017
{
    public class Day23
    {
        public static int Task1(string[] instructions)
        {
            var program = new Program(instructions);
            while (program.ExecuteNextInstruction())
            {
                ;
            }

            return program.MultiplyCount;
        }

        public static int Task2(string[] instructions)
        {
            // 93 * 100 + 100 000.
            var primesInRange = Primes
                .PrimesInRange(109_300, 126_300)
                .ToHashSet();

            return Enumerable.Range(0, 1001)
                .Select(x => x * 17 + 109_300)
                .Where(x => !primesInRange.Contains(x))
                .Count();
        }

        private class Program
        {
            private readonly Dictionary<char, long> registers = new Dictionary<char, long>
            {
                { 'a', 0},
                { 'b', 0},
                { 'c', 0},
                { 'd', 0},
                { 'e', 0},
                { 'f', 0},
                { 'g', 0},
                { 'h', 0},
            };
            private readonly IInstruction[] instructions;
            private long index = 0;

            public int MultiplyCount { get; private set; } = 0;

            public Program(string[] instructions)
            {
                this.instructions = ParseInstructions(instructions);
            }

            public bool ExecuteNextInstruction()
            {
                if (index < 0 || index >= instructions.Length)
                {
                    return false;
                }

                var instruction = instructions[index];
                var success = ExecuteInstruction(instruction);

                if (success)
                {
                    index++;
                }

                return success;
            }

            private bool ExecuteInstruction(IInstruction instruction)
            {
                switch (instruction)
                {
                    case SetInstruction set:
                        return ExecuteInstruction(set);
                    case SubstractionInstruction sub:
                        return ExecuteInstruction(sub);
                    case MultiplyInstruction multiply:
                        return ExecuteInstruction(multiply);
                    case ModulusInstruction modulus:
                        return ExecuteInstruction(modulus);
                    case JumpInstruction jump:
                        return ExecuteInstruction(jump);
                    default:
                        throw new InvalidOperationException($"Unknown instruction: {instruction.GetType()}.");
                }
            }

            private bool ExecuteInstruction(SetInstruction instruction)
            {
                registers[instruction.RegisterAddress] = instruction.Value;
                return true;
            }

            private bool ExecuteInstruction(SubstractionInstruction instruction)
            {
                registers[instruction.RegisterAddress] -= instruction.Value;
                return true;
            }

            private bool ExecuteInstruction(MultiplyInstruction instruction)
            {
                MultiplyCount++;
                registers[instruction.RegisterAddress] *= instruction.Value;
                return true;
            }

            private bool ExecuteInstruction(ModulusInstruction instruction)
            {
                registers[instruction.RegisterAddress] %= instruction.Value;
                return true;
            }

            private bool ExecuteInstruction(JumpInstruction instruction)
            {
                if (instruction.CompareValue != 0)
                {
                    index += instruction.JumpValue - 1;
                }
                return true;
            }

            private IInstruction[] ParseInstructions(string[] instructions)
            {
                return instructions
                    .Select(ParseInstruction)
                    .ToArray();
            }

            private IInstruction ParseInstruction(string instruction)
            {
                var parts = instruction
                        .Split(' ')
                        .ToArray();

                switch (parts[0])
                {
                    case "set":
                        return new SetInstruction(parts[1][0], GetValue(parts[2]));
                    case "sub":
                        return new SubstractionInstruction(parts[1][0], GetValue(parts[2]));
                    case "mul":
                        return new MultiplyInstruction(parts[1][0], GetValue(parts[2]));
                    case "mod":
                        return new ModulusInstruction(parts[1][0], GetValue(parts[2]));
                    case "jnz":
                        return new JumpInstruction(GetValue(parts[1]), GetValue(parts[2]));
                    default:
                        throw new ArgumentException($"Unknown instruction: {parts[0]}.", nameof(instruction));
                }
            }

            private IValue GetValue(string value)
            {
                if (long.TryParse(value, out var a))
                {
                    return new ScalarValue(a);
                }

                return new RegisterValue(value[0], registers);
            }
        }

        private interface IValue
        {
            long Value { get; }
        }

        private class ScalarValue : IValue
        {
            public long Value { get; }

            public ScalarValue(long value)
            {
                Value = value;
            }
        }

        private class RegisterValue : IValue
        {
            private readonly char key;
            private readonly Dictionary<char, long> registers;
            public long Value => registers[key];

            public RegisterValue(char key, Dictionary<char, long> registers)
            {
                this.key = key;
                this.registers = registers;
            }
        }

        private interface IInstruction { }

        private abstract class RegisterAddressAndValueInstruction : IInstruction
        {
            private readonly IValue value;
            public long Value => value.Value;
            public char RegisterAddress { get; }

            public RegisterAddressAndValueInstruction(char registerAddress, IValue value)
            {
                RegisterAddress = registerAddress;
                this.value = value;
            }
        }

        private class SetInstruction : RegisterAddressAndValueInstruction
        {
            public SetInstruction(char registerAddress, IValue value)
                : base(registerAddress, value) { }
        }

        private class SubstractionInstruction : RegisterAddressAndValueInstruction
        {
            public SubstractionInstruction(char registerAddress, IValue value)
               : base(registerAddress, value) { }
        }

        private class MultiplyInstruction : RegisterAddressAndValueInstruction
        {
            public MultiplyInstruction(char registerAddress, IValue value)
               : base(registerAddress, value) { }
        }

        private class ModulusInstruction : RegisterAddressAndValueInstruction
        {
            public ModulusInstruction(char registerAddress, IValue value)
               : base(registerAddress, value) { }
        }

        private class JumpInstruction : IInstruction
        {
            private readonly IValue compareValue;
            private readonly IValue jumpValue;
            public long CompareValue => compareValue.Value;
            public long JumpValue => jumpValue.Value;

            public JumpInstruction(IValue compareValue, IValue jumpValue)
            {
                this.compareValue = compareValue;
                this.jumpValue = jumpValue;
            }
        }

        private class Primes
        {
            public static IEnumerable<int> PrimesUpTo(int upperBound)
            {
                // The first prime number is 2.
                yield return 2;

                var composite = new BitArray((upperBound - 1) / 2);
                var limit = ((int)(Math.Sqrt(upperBound)) - 1) / 2;
                for (var i = 0; i < limit; i++)
                {
                    if (composite[i])
                    {
                        continue;
                    }

                    // The first number not crossed out is prime.
                    var prime = 2 * i + 3;
                    yield return prime;

                    // Cross out all multiples of this prime, starting at the prime squared.
                    for (var j = (prime * prime - 2) >> 1; j < composite.Count; j += prime)
                    {
                        composite[j] = true;
                    }
                }

                // The remaining numbers not crossed out are also primes.
                for (int i = limit; i < composite.Count; i++)
                {
                    if (!composite[i])
                    {
                        yield return 2 * i + 3;
                    }
                }
            }

            public static IEnumerable<int> PrimesInRange(int lowerBound, int upperBound)
            {
                return PrimesUpTo(upperBound)
                    .Where(prime => prime >= lowerBound);
            }
        }
    }
}

