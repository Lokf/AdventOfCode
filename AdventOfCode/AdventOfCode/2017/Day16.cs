using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode._2017
{
    public class Day16
    {
        public static string Task1(int size, string danceMoves)
        {
            var programs = Enumerable
                .Range(0, size)
                .Select(x => (char)(x + 'a'))
                .ToArray();

            var moves = danceMoves
                .Split(',')
                .Select(ParseDanceMove)
                .ToList();

            foreach (var move in moves)
            {
                move.PerformMove(ref programs);
            }

            return new string(programs);
        }

        public static string Task2(int size, string danceMoves, long numberOfTimesToRepeat)
        {
            var seenStates = new Dictionary<string, int>();

            var programs = Enumerable
                .Range(0, size)
                .Select(x => (char)(x + 'a'))
                .ToArray();

            var moves = danceMoves
                .Split(',')
                .Select(ParseDanceMove)
                .ToList();

            seenStates.Add(new string(programs), 0);

            for (int i = 0; i < numberOfTimesToRepeat; i++)
            {
                foreach (var move in moves)
                {
                    move.PerformMove(ref programs);
                }

                var state = new string(programs);
                if (!seenStates.TryAdd(state, i + 1))
                {
                    var cycleStart = seenStates[state];

                    var index = cycleStart + (numberOfTimesToRepeat % (i + 1 - cycleStart));

                    return seenStates.First(x => x.Value == index).Key;
                }
            }

            return new string(programs);
        }

        private static IDanceMover ParseDanceMove(string danceMove)
        {
            switch (danceMove[0])
            {
                case 's':
                    return new Spin(int.Parse(danceMove.Substring(1)));
                case 'x':
                    var indices = danceMove
                        .Substring(1)
                        .Split('/')
                        .Select(int.Parse)
                        .ToList();
                    return new SwapIndex(indices[0], indices[1]);
                case 'p':
                    var values = danceMove
                        .Substring(1)
                        .Split('/')
                        .Select(x => x[0])
                        .ToList();
                    return new SwapValue(values[0], values[1]);
            }

            throw new ArgumentOutOfRangeException(nameof(danceMove));
        }
       
        private interface IDanceMover
        {
            void PerformMove(ref char[] programs);
        }

        private class Spin : IDanceMover
        {
            private int N { get; }
            public Spin(int n)
            {
                N = n;
            }

            public void PerformMove(ref char[] programs)
            {
                var spinnedPrograms = new List<char>(programs.Length);

                spinnedPrograms.AddRange(programs.Skip(programs.Length - N));
                spinnedPrograms.AddRange(programs.Take(programs.Length - N));

                programs = spinnedPrograms.ToArray();
            }
        }

        private class SwapIndex : IDanceMover
        {
            private int Index1 { get; }
            private int Index2 { get; }
            public SwapIndex(int index1, int index2)
            {
                Index1 = index1;
                Index2 = index2;
            }

            public void PerformMove(ref char[] programs)
            {
                var temp = programs[Index1];
                programs[Index1] = programs[Index2];
                programs[Index2] = temp;
            }
        }

        private class SwapValue : IDanceMover
        {
            private char Value1 { get; }
            private char Value2 { get; }
            public SwapValue(char value1, char value2)
            {
                Value1 = value1;
                Value2 = value2;
            }

            public void PerformMove(ref char[] programs)
            {
                var index1 = Array.IndexOf(programs, Value1);
                var index2 = Array.IndexOf(programs, Value2);
                programs[index1] = Value2;
                programs[index2] = Value1;
            }
        }
    }
}
