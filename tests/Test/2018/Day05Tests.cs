using AdventOfCode._2018;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test._2018
{
    [TestClass]
    public class Day05Tests
    {
        [TestMethod]
        public void Task1Test()
        {
            Assert.AreEqual(10, Day05.Task1("dabAcCaCBAcCcaDA"));
        }

        [TestMethod]
        public void Task2Test()
        {
            Assert.AreEqual(4, Day05.Task2("dabAcCaCBAcCcaDA"));
        }
    }
}
