using AdventOfCode;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    [TestClass]
    public class Day14Test
    {
        [TestMethod]
        public void Task1()
        {
            Assert.AreEqual(8108, Day14.Task1("flqrgnkx"));
        }

        [TestMethod]
        public void Task2()
        {
            Assert.AreEqual(1242, Day14.Task2("flqrgnkx"));
        }
    }
}
