using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    public class Day15
    {
        public static int Task1(long seedA, long seedB)
        {
            var numberOfMatches = 0;

            var generatorA = new Generetor(seedA, 16_807);
            var generatorB = new Generetor(seedB, 48_271);

            for (var i = 0; i < 40_000_000; i++)
            {
                var a = generatorA.NextValue();
                var b = generatorB.NextValue();

                if (IsSameLowest16Bits(a, b))
                {
                    numberOfMatches++;
                }
            }

            return numberOfMatches;
        }

        public static int Task2(long seedA, long seedB)
        {
            var numberOfMatches = 0;

            var generatorA = new Generetor(seedA, 16_807);
            var generatorB = new Generetor(seedB, 48_271);

            for (var i = 0; i < 5_000_000; i++)
            {
                var a = generatorA.NextValue(4);
                var b = generatorB.NextValue(8);

                if (IsSameLowest16Bits(a, b))
                {
                    numberOfMatches++;
                }
            }

            return numberOfMatches;
        }

        private static bool IsSameLowest16Bits(long value1, long value2)
        {
            var mask = 0b1111_1111_1111_1111;

            return (value1 & mask) == (value2 & mask);
        }

        private class Generetor
        {
            private readonly long factor;
            private static long modulus = 2_147_483_647;
            private long previousValue;

            public Generetor(long seed, long factor)
            {
                previousValue = seed;
                this.factor = factor;
            }

            public long NextValue()
            {
                previousValue = (previousValue * factor) % modulus;
                return previousValue;
            }

            public long NextValue(int multiple)
            {
                while (NextValue() % multiple != 0)
                {
                    ;
                }

                return previousValue;
            }
        }
    }
}
