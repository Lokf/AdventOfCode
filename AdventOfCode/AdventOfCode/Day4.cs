using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    public class Day4
    {
        public static int Task1(List<string> passphrases)
        {
            return passphrases
                .Where(IsValidPassphrase1)
                .Count();
        }

        public static int Task2(List<string> passphrases)
        {
            return passphrases
                .Where(IsValidPassphrase2)
                .Count();
        }

        private static bool IsValidPassphrase1(string passphrase)
        {         
            var words = passphrase.Split(" ");
            var distinctWords = new HashSet<string>(words.Count());

            foreach(var word in words)
            {
                var isDistinct = distinctWords.Add(word);
                if (!isDistinct)
                {
                    return false;
                }
            }

            return true;
        }

        private static bool IsValidPassphrase2(string passphrase)
        {
            var words = passphrase.Split(" ");
            var distinctWords = new HashSet<string>(words.Count());

            foreach (var word in words)
            {
                var isDistinct = distinctWords.Add(string.Concat(word.OrderBy(character => character)));
                if (!isDistinct)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
