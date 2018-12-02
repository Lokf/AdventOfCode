using AdventOfCode._2018;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test._2018
{
    [TestClass]
    public class Day02Tests
    {
        [TestMethod]
        public void Task1Test()
        {
            var boxIds = new List<string> {
                "abcdef",
                "bababc",
                "abbcde",
                "abcccd",
                "aabcdd",
                "abcdee",
                "ababab",
            };
            Assert.AreEqual(12, Day02.Task1(boxIds));
        }

        [TestMethod]
        public void Task2Test()
        {
            var boxIds = new List<string> {
                "abcde",
                "fghij",
                "klmno",
                "pqrst",
                "fguij",
                "axcye",
                "wvxyz",
            };

            Assert.AreEqual("fgij", Day02.Task2(boxIds));
        }
    }
}
