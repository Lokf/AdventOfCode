using AdventOfCode._2017;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Test._2017
{
    [TestClass]
    public class Day04Test
    {
        [TestMethod]
        public void Task1()
        {
            var passphrases = new List<string>
            {
                "aa bb cc dd ee",
                "aa bb cc dd aa",
                "aa bb cc dd aaa"
            };

            Assert.AreEqual(2, Day04.Task1(passphrases));
        }

        [TestMethod]
        public void Task2()
        {
            var passphrases = new List<string>
            {
                "abcde fghij",
                "abcde xyz ecdab",
                "a ab abc abd abf abja",
                "iiii oiii ooii oooi oooo",
                "oiii ioii iioi iiio"
            };

            Assert.AreEqual(3, Day04.Task2(passphrases));
        }
    }
}
