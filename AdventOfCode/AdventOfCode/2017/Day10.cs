using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2017
{
    public class Day10
    {
        public static int Task1(List<int> lenghts, int size)
        {
            var list = Enumerable
                .Range(0, size)
                .ToArray();

            KnotHash(list, lenghts, 0, 0);

            return list[0] * list[1];
        }

        public static string Task2(char[] lengths, int size)
        {
            var list = Enumerable
                .Range(0, size)
                .ToArray();

            var trueLenghts = lengths
                .Select(x => (int)x)
                .ToList();

            trueLenghts.AddRange(new List<int> { 17, 31, 73, 47, 23 });
            
            var position = 0;
            var skipSize = 0;
            for (var i = 0; i < 64; i++)
            {                
                (position, skipSize) = KnotHash(list, trueLenghts, position, skipSize);
            }

            var denseHash = DenseHash(list);
            return string.Join(string.Empty, denseHash.Select(x => x.ToString("x2")));
        }

        private static int[] DenseHash(int[] sparseHash)
        {
            var denseHash = new int[16];
            for (var i = 0; i < 16; i++)
            {
                denseHash[i] = sparseHash
                    .Skip(i * 16)
                    .Take(16)
                    .Aggregate((hash, value) => hash ^ value);
            }

            return denseHash;
        }

        private static (int position, int skipSize) KnotHash(int[] list, List<int> lenghts, int position, int skipSize)
        {
            foreach (var length in lenghts)
            {
                Hash(list, position, length);
                position += length + skipSize;
                position = position % list.Length;
                skipSize++;
            }

            return (position, skipSize);
        }

        private static void Hash(int[] list, int position, int length)
        {
            for (var i = 0; i < length / 2; i++)
            {
                var index1 = (position + i) % list.Length;
                var index2 = (position + length - i - 1) % list.Length;
                Swap(list, index1, index2);
            }
        }

        private static void Swap(int[] list, int index1, int index2)
        {
            var temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
        }
    }
}
