using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2018
{
    public class Day16
    {
        public static int Task1(IEnumerable<string> input)
        {
            return ParseExamples(input)
                .Select(example => example.CalculateNumberOfPossibleOpcodes())
                .Count(x => x >= 3);
        }

        public static int Task2(IEnumerable<string> input)
        {
            var examples = ParseExamples(input);
            var opcodes = DeduceOpcodes(examples);
            var instructions = ParseInstructions(input).ToList();

            var registerState = new RegisterState(new List<int>
            {
                0,
                0,
                0,
                0,
            });

            foreach (var instruction in instructions)
            {
                registerState = instruction.Execute(registerState, opcodes);
            }

            return registerState[0];
        }

        private static IEnumerable<Instruction> ParseInstructions(IEnumerable<string> input)
        {
            var numberOfConsecutiveBlankRows = 0;
            var rowNumber = 0;
            foreach (var row in input)
            {
                if (numberOfConsecutiveBlankRows == 3)
                {
                    break;
                }

                if (row == string.Empty)
                {
                    numberOfConsecutiveBlankRows++;
                }
                else
                {
                    numberOfConsecutiveBlankRows = 0;
                }

                rowNumber++;
            }

            foreach (var instruction in input.Skip(rowNumber))
            {
                var instructionValues = instruction
                    .Split(" ")
                    .Select(int.Parse)
                    .ToArray();

                yield return new Instruction(instructionValues[0], instructionValues[1], instructionValues[2], instructionValues[3]);
            }
        }

        private static Dictionary<int, Func<RegisterState, int, int, int, RegisterState>> DeduceOpcodes(IEnumerable<Example> examples)
        {
            var opcodesMethod = new Dictionary<int, Func<RegisterState, int, int, int, RegisterState>>();

            var opcodeInfos = examples
                .Select(example => (Opcode: example.Instruction.Opcode, PossibleMethods: example.PossibleOpcodes().ToList()))
                .OrderBy(opcodeInfo => opcodeInfo.PossibleMethods.Count())
                .ToList();

            while (true)
            {
                if (opcodesMethod.Count == 16)
                {
                    return opcodesMethod;
                }

                var opcodeInfo = opcodeInfos.First();
                var method = opcodeInfo.PossibleMethods.Single();

                opcodesMethod.Add(opcodeInfo.Opcode, method);
                foreach (var (_, PossibleMethods) in opcodeInfos)
                {
                    PossibleMethods.Remove(method);
                }

                opcodeInfos = opcodeInfos
                    .Where(oi => oi.PossibleMethods.Any())
                    .OrderBy(oi => oi.PossibleMethods.Count())
                    .ToList();
            }
        }

        private static IEnumerable<Func<RegisterState, int, int, int, RegisterState>> Opcodes()
        {
            yield return Addr;
            yield return Addi;
            yield return Mulr;
            yield return Muli;
            yield return Banr;
            yield return Bani;
            yield return Borr;
            yield return Bori;
            yield return Setr;
            yield return Seti;
            yield return Gtir;
            yield return Gtri;
            yield return Gtrr;
            yield return Eqir;
            yield return Eqri;
            yield return Eqrr;
        }

        private static RegisterState Addr(RegisterState before, int a, int b, int c)
        {
            var value = before[a] + before[b];
            return before.With(value, c);
        }

        private static RegisterState Addi(RegisterState before, int a, int b, int c)
        {
            var value = before[a] + b;
            return before.With(value, c);
        }

        private static RegisterState Mulr(RegisterState before, int a, int b, int c)
        {
            var value = before[a] * before[b];
            return before.With(value, c);
        }

        private static RegisterState Muli(RegisterState before, int a, int b, int c)
        {
            var value = before[a] * b;
            return before.With(value, c);
        }

        private static RegisterState Banr(RegisterState before, int a, int b, int c)
        {
            var value = before[a] & before[b];
            return before.With(value, c);
        }

        private static RegisterState Bani(RegisterState before, int a, int b, int c)
        {
            var value = before[a] & b;
            return before.With(value, c);
        }

        private static RegisterState Borr(RegisterState before, int a, int b, int c)
        {
            var value = before[a] | before[b];
            return before.With(value, c);
        }

        private static RegisterState Bori(RegisterState before, int a, int b, int c)
        {
            var value = before[a] | b;
            return before.With(value, c);
        }

        private static RegisterState Setr(RegisterState before, int a, int b, int c)
        {
            return before.With(before[a], c);
        }

        private static RegisterState Seti(RegisterState before, int a, int b, int c)
        {
            return before.With(a, c);
        }

        private static RegisterState Gtir(RegisterState before, int a, int b, int c)
        {
            var value = a > before[b] ? 1 : 0;
            return before.With(value, c);
        }

        private static RegisterState Gtri(RegisterState before, int a, int b, int c)
        {
            var value = before[a] > b ? 1 : 0;
            return before.With(value, c);
        }

        private static RegisterState Gtrr(RegisterState before, int a, int b, int c)
        {
            var value = before[a] > before[b] ? 1 : 0;
            return before.With(value, c);
        }

        private static RegisterState Eqir(RegisterState before, int a, int b, int c)
        {
            var value = a == before[b] ? 1 : 0;
            return before.With(value, c);
        }

        private static RegisterState Eqri(RegisterState before, int a, int b, int c)
        {
            var value = before[a] == b ? 1 : 0;
            return before.With(value, c);
        }

        private static RegisterState Eqrr(RegisterState before, int a, int b, int c)
        {
            var value = before[a] == before[b] ? 1 : 0;
            return before.With(value, c);
        }

        private static IEnumerable<Example> ParseExamples(IEnumerable<string> input)
        {
            var enumerator = input.GetEnumerator();
            enumerator.MoveNext();

            while (enumerator.Current != null && enumerator.Current.Length > 6 && enumerator.Current.Substring(0, 6) == "Before")
            {
                var registerValuesBefore = enumerator
                    .Current
                    .Substring(9, 10)
                    .Split(", ")
                    .Select(int.Parse);

                var before = new RegisterState(registerValuesBefore);
                enumerator.MoveNext();

                var instructionValues = enumerator
                    .Current
                    .Split(" ")
                    .Select(int.Parse)
                    .ToArray();

                var instruction = new Instruction(instructionValues[0], instructionValues[1], instructionValues[2], instructionValues[3]);
                enumerator.MoveNext();

                var registerValuesAfter = enumerator
                    .Current
                    .Substring(9, 10)
                    .Split(", ")
                    .Select(int.Parse);

                var after = new RegisterState(registerValuesAfter);
                enumerator.MoveNext();
                enumerator.MoveNext();

                yield return new Example(before, instruction, after);
            }
        }

        private class Example
        {
            public Example(RegisterState before, Instruction instruction, RegisterState after)
            {
                Before = before;
                Instruction = instruction;
                After = after;
            }

            public RegisterState Before { get; }
            public Instruction Instruction { get; }
            public RegisterState After { get; }

            public int CalculateNumberOfPossibleOpcodes()
            {
                return PossibleOpcodes().Count();
            }

            public IEnumerable<Func<RegisterState, int, int, int, RegisterState>> PossibleOpcodes()
            {
                foreach (var opcode in Opcodes())
                {
                    var after = opcode(Before, Instruction.A, Instruction.B, Instruction.C);
                    if (after == After)
                    {
                        yield return opcode;
                    }
                }
            }
        }

        private class Instruction
        {
            public Instruction(int opcode, int a, int b, int c)
            {
                Opcode = opcode;
                A = a;
                B = b;
                C = c;
            }

            public int Opcode { get; }
            public int A { get; }
            public int B { get; }
            public int C { get; }

            public RegisterState Execute(RegisterState state, Dictionary<int, Func<RegisterState, int, int, int, RegisterState>> opcodes)
            {
                return opcodes[Opcode](state, A, B, C);
            }
        }

        private class RegisterState : IEquatable<RegisterState>
        {
            private readonly Dictionary<int, int> registerValues = new Dictionary<int, int>();

            public RegisterState(IEnumerable<int> registerValues)
            {
                var register = 0;
                foreach (var value in registerValues)
                {
                    this.registerValues.Add(register, value);
                    register++;
                }
            }

            public int this[int register]
                => registerValues[register];

            public static bool operator ==(RegisterState obj1, RegisterState obj2)
            {
                if (ReferenceEquals(obj1, obj2))
                {
                    return true;
                }

                if (obj1 is null)
                {
                    return false;
                }
                if (obj2 is null)
                {
                    return false;
                }

                return obj1.Equals(obj2);
            }

            public static bool operator !=(RegisterState obj1, RegisterState obj2)
            {
                return !(obj1 == obj2);
            }

            public override bool Equals(object obj)
            {
                return Equals(obj as RegisterState);
            }

            public bool Equals(RegisterState other)
            {
                if (other == null)
                {
                    return false;
                }

                return registerValues.Count == other.registerValues.Count
                    && !registerValues.Except(other.registerValues).Any();
            }

            public override int GetHashCode()
            {
                return 1447235606 & registerValues.GetHashCode();
            }

            public RegisterState With(int value, int register)
            {
                return new RegisterState(registerValues
                    .Values
                    .Select((v, r) => r == register ? value : v));
            }
        }
    }
}
