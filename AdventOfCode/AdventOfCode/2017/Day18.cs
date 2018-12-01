using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2017
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

        public static int Task2(string[] instructions)
        {
            var send0 = new Queue<long>();
            var send1 = new Queue<long>();

            var program0 = new Program(0, instructions, send0, send1);
            var program1 = new Program(1, instructions, send1 ,send0);                      

            while (program0.ExecuteNextInstruction() || program1.ExecuteNextInstruction())
            {
                ;
            }

            return program1.SendCount;
        }

        private class Program
        {
            private readonly Dictionary<char, long> registers = new Dictionary<char, long>();
            private readonly IInstruction[] instructions;
            private readonly Queue<long> send;
            private readonly Queue<long> receive;
            private long index = 0;

            public int SendCount { get; private set; } = 0;

            public Program(long programId, string[] instructions, Queue<long> send, Queue<long> receive)
            {
                this.instructions = ParseInstructions(instructions);
                this.send = send;
                this.receive = receive;

                var registerKeys = instructions
                    .Select(x => x.Split(' '))
                    .Select(x => x[1][0])
                    .Distinct()
                    .Where(x => x != '\0' && !char.IsDigit(x));

                foreach (var key in registerKeys)
                {
                    registers.Add(key, 0);
                }

                registers['p'] = programId;
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
                    case SendInstruction send:
                        return ExecuteInstruction(send);
                    case ReceiveInstruction receive:
                        return ExecuteInstruction(receive);
                    case SetInstruction set:
                        return ExecuteInstruction(set);
                    case AddInstruction add:
                        return ExecuteInstruction(add);
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

            private bool ExecuteInstruction(SendInstruction instruction) {
                send.Enqueue(instruction.Value);
                SendCount++;
                return true;
            }

            private bool ExecuteInstruction(ReceiveInstruction instruction)
            {
                if (receive.Count == 0)
                {
                    return false;
                }

                registers[instruction.RegisterAddress] = receive.Dequeue();
                return true;
            }

            private bool ExecuteInstruction(SetInstruction instruction)
            {
                registers[instruction.RegisterAddress] = instruction.Value;
                return true;
            }

            private bool ExecuteInstruction(AddInstruction instruction)
            {
                registers[instruction.RegisterAddress] += instruction.Value;
                return true;
            }

            private bool ExecuteInstruction(MultiplyInstruction instruction)
            {
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
                if (instruction.CompareValue > 0)
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
                    case "snd":
                        return new SendInstruction(GetValue(parts[1]));
                    case "rcv":
                        return new ReceiveInstruction(parts[1][0]);
                    case "set":
                        return new SetInstruction(parts[1][0], GetValue(parts[2]));
                    case "add":
                        return new AddInstruction(parts[1][0], GetValue(parts[2]));
                    case "mul":
                        return new MultiplyInstruction(parts[1][0], GetValue(parts[2]));
                    case "mod":
                        return new ModulusInstruction(parts[1][0], GetValue(parts[2]));
                    case "jgz":
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

        private class SendInstruction : IInstruction
        {
            private readonly IValue value;
            public long Value => value.Value;

            public SendInstruction(IValue value)
            {
                this.value = value;
            }
        }

        private class ReceiveInstruction : IInstruction
        {
            public char RegisterAddress { get; }

            public ReceiveInstruction(char registerAddress)
            {
                RegisterAddress = registerAddress;
            }
        }

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

        private class AddInstruction : RegisterAddressAndValueInstruction
        {
            public AddInstruction(char registerAddress, IValue value)
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
    }
}
