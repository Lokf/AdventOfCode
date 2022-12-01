using AdventOfCode._2017;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Test._2017
{
    [TestClass]
    public class Day12Test
    {
        [TestMethod]
        public void Task1()
        {
            var connections = new List<string>
            {
                "0 <-> 2",
                "1 <-> 1",
                "2 <-> 0, 3, 4",
                "3 <-> 2, 4",
                "4 <-> 2, 3, 6",
                "5 <-> 6",
                "6 <-> 4, 5"
            };

            Assert.AreEqual(6, Day12.Task1(connections));
        }

        [TestMethod]
        public void Task2()
        {
            var connections = new List<string>
            {
                "0 <-> 2",
                "1 <-> 1",
                "2 <-> 0, 3, 4",
                "3 <-> 2, 4",
                "4 <-> 2, 3, 6",
                "5 <-> 6",
                "6 <-> 4, 5"
            };

            Assert.AreEqual(2, Day12.Task2(connections));
        }
    }
}
