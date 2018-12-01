using AdventOfCode._2017;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Test._2017
{
    [TestClass]
    public class Day22Test
    {
        [TestMethod]
        public void Task1()
        {
            var grid = new string[]
            {
                "..#",
                "#..",
                "..."
            };

            Assert.AreEqual(5, Day22.Task1(grid, 7));
            Assert.AreEqual(41, Day22.Task1(grid, 70));
            Assert.AreEqual(5587, Day22.Task1(grid, 10000));
        }

        [TestMethod]
        public void Task2()
        {
            var grid = new string[]
            {
                "..#",
                "#..",
                "..."
            };

            Assert.AreEqual(26, Day22.Task2(grid, 100));
            Assert.AreEqual(2_511_944, Day22.Task2(grid, 10_000_000));
        }
    }
}
