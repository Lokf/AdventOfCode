using AdventOfCode._2018;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Test._2018
{
    [TestClass]
    public class Day06Tests
    {
        [TestMethod]
        public void Task1()
        {
            var coordinates = new List<string>
            {
                "1, 1",
                "1, 6",
                "8, 3",
                "3, 4",
                "5, 5",
                "8, 9",
            };

            Assert.AreEqual(17, Day06.Task1(coordinates));
        }

        [TestMethod]
        public void Task2()
        {
            var coordinates = new List<string>
            {
                "1, 1",
                "1, 6",
                "8, 3",
                "3, 4",
                "5, 5",
                "8, 9",
            };

            Assert.AreEqual(16, Day06.Task2(coordinates, 32));
        }
    }
}
