using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    public class Day04
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
            var distinctWords = new HashSet<string>(words.Length);

            return words
                .Select(word => distinctWords.Add(word))
                .All(isDistinct => isDistinct);
        }

        private static bool IsValidPassphrase2(string passphrase)
        {
            var words = passphrase.Split(" ");
            var distinctWords = new HashSet<string>(words.Length);

            return words
                .Select(word => distinctWords.Add(string.Concat(word.OrderBy(character => character))))
                .All(isDistinct => isDistinct);
        }
    }
}
