using AdventOfCode._2017;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Test._2017
{
    [TestClass]
    public class Day21Test
    {
        [TestMethod]
        public void Task1()
        {
            var rules = new string[]
            {
                "../.# => ##./#../...",
                ".#./..#/### => #..#/..../..../#..#"
            };

            Assert.AreEqual(12, Day21.Task1(rules, 2));
        }

        [TestMethod]
        public void Task2()
        {
        }
    }
}
