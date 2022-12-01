using AdventOfCode._2017;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Test._2017
{
    [TestClass]
    public class Day13Test
    {
        [TestMethod]
        public void Task1()
        {
            var layers = new List<string>
            {
                "0: 3",
                "1: 2",
                "4: 4",
                "6: 4"
            };

            Assert.AreEqual(24, Day13.Task1(layers));
        }

        [TestMethod]
        public void Task2()
        {
            var layers = new List<string>
            {
                "0: 3",
                "1: 2",
                "4: 4",
                "6: 4"
            };

            Assert.AreEqual(10, Day13.Task2(layers));
        }
    }
}
