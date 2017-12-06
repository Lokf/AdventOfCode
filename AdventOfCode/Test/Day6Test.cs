using AdventOfCode;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Test
{
    [TestClass]
    public class Day6Test
    {
        [TestMethod]
        public void Task1()
        {
            Assert.AreEqual(5, Day6.Task1("0    2   7   0"));
        }

        [TestMethod]
        public void Task2()
        {
            Assert.AreEqual(4, Day6.Task2("0    2   7   0"));
        }
    }
}
