using AdventOfCode._2017;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Test._2017
{
    [TestClass]
    public class Day05Test
    {
        [TestMethod]
        public void Task1()
        {
            var offsets = new List<string>
            {
                "0",
                "3",
                "0",
                "1",
                "-3"
            };

            Assert.AreEqual(5, Day05.Task1(offsets));
        }

        [TestMethod]
        public void Task2()
        {
            var offsets = new List<string>
            {
                "0",
                "3",
                "0",
                "1",
                "-3"
            };

            Assert.AreEqual(10, Day05.Task2(offsets));
        }
    }
}
