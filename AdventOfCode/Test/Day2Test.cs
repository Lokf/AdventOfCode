using AdventOfCode;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Test
{
    [TestClass]
    public class Day2Test
    {
        [TestMethod]
        public void Task1()
        {
            var spreadsheat = new List<string>
            {
                "5 1 9 5",
                "7 5 3",
                "2 4 6 8"
            };

            Assert.AreEqual(18, Day2.Task1(spreadsheat));
        }

        [TestMethod]
        public void Task2()
        {
            var spreadsheat = new List<string>
            {
                "5 9 2 8",
                "9 4 7 3",
                "3 8 6 5"
            };

            Assert.AreEqual(9, Day2.Task2(spreadsheat));
        }
    }
}
