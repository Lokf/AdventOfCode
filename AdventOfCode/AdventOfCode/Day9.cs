using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode
{
    public class Day9
    {
        public static int Task1(string stream)
        {
            return ParseGroup(stream, 1).score;
        }

        public static int Task2(string stream)
        {
            return ParseGroup(stream, 1).garbage;
        }

        private static (int score, int length, int garbage) ParseGroup(string group, int level)
        {
            var skipNext = false;
            var score = 0;
            var numberOfGarbage = 0;
            var index = 0;

            while (true)
            {                
                index++;

                if (skipNext)
                {
                    skipNext = false;
                    continue;
                }

                var character = group[index];

                switch (character)
                {
                    case '!':
                        skipNext = true;
                        continue;
                    case '{':
                        var nestedGroup = ParseGroup(group.Substring(index), level + 1);
                        score += nestedGroup.score;
                        numberOfGarbage += nestedGroup.garbage;
                        index += nestedGroup.length;
                        break;
                    case '}':
                        return (level + score, index, numberOfGarbage);
                    case '<':
                        var garbage = ParseGarbage(group.Substring(index));
                        index += garbage.length - 1;
                        numberOfGarbage += garbage.garbage;
                        break;
                    default:
                        continue;
                }
            }
        }

        private static (int length, int garbage) ParseGarbage(string garbage)
        {
            var length = 0;
            var garbage2 = 0;
            var skipNext = false;

            foreach (var character in garbage)
            {
                length++;

                if (skipNext)
                {
                    skipNext = false;
                    continue;
                }

                switch (character)
                {
                    case '!':
                        skipNext = true;
                        continue;
                    case '>':
                        return (length, garbage2 - 1);
                    default:
                        garbage2++;
                        continue;
                }
            }

            throw new ArgumentException("garbage");
        }
    }
}
