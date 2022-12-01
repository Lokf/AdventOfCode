using AdventOfCode._2018;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test._2018
{
    [TestClass]
    public class Day11Tests
    {
        [TestMethod]
        public void Task1Test()
        {
            Assert.AreEqual((33, 45), Day11.Task1(18));
            Assert.AreEqual((21, 61), Day11.Task1(42));
        }

        [TestMethod]
        public void Task2Test()
        {
            Assert.AreEqual((90, 269, 16), Day11.Task2(18));
            Assert.AreEqual((232, 251, 12), Day11.Task2(42));
        }
    }
}
