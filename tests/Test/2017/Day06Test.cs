using AdventOfCode._2017;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Test._2017
{
    [TestClass]
    public class Day06Test
    {
        [TestMethod]
        public void Task1()
        {
            Assert.AreEqual(5, Day06.Task1("0    2   7   0"));
        }

        [TestMethod]
        public void Task2()
        {
            Assert.AreEqual(4, Day06.Task2("0    2   7   0"));
        }
    }
}
