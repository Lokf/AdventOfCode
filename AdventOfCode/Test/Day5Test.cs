using AdventOfCode;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Test
{
    [TestClass]
    public class Day5Test
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

            Assert.AreEqual(5, Day5.Task1(offsets));
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

            Assert.AreEqual(10, Day5.Task2(offsets));
        }
    }
}
