using AdventOfCode._2017;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Test._2017
{
    [TestClass]
    public class Day15Test
    {
        [TestMethod]
        public void Task1()
        {
            Assert.AreEqual(588, Day15.Task1(65, 8_921));
        }

        [TestMethod]
        public void Task2()
        {
            Assert.AreEqual(309, Day15.Task2(65, 8_921));
        }
    }
}
