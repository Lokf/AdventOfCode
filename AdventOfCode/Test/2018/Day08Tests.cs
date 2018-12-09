using AdventOfCode._2018;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Test._2018
{
    [TestClass]
    public class Day08Tests
    {
        [TestMethod]
        public void Task1Test()
        {
            var tree = new List<int>
            {
                2,
                3,
                0,
                3,
                10,
                11,
                12,
                1,
                1,
                0,
                1,
                99,
                2,
                1,
                1,
                2,
            };

            Assert.AreEqual(138, Day08.Task1(tree));
        }

        [TestMethod]
        public void Task2Test()
        {
            var tree = new List<int>
            {
                2,
                3,
                0,
                3,
                10,
                11,
                12,
                1,
                1,
                0,
                1,
                99,
                2,
                1,
                1,
                2,
            };

            Assert.AreEqual(66, Day08.Task2(tree));
        }
    }
}
