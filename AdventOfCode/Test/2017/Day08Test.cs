using AdventOfCode._2017;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Test._2017
{
    [TestClass]
    public class Day08Test
    {
        [TestMethod]
        public void Task1()
        {
            var instructions = new List<string>
            {
                "b inc 5 if a > 1",
                "a inc 1 if b < 5",
                "c dec -10 if a >= 1",
                "c inc -20 if c == 10"
            };

            Assert.AreEqual(1, Day08.Task1(instructions));
        }

        [TestMethod]
        public void Task2()
        {
            var instructions = new List<string>
            {
                "b inc 5 if a > 1",
                "a inc 1 if b < 5",
                "c dec -10 if a >= 1",
                "c inc -20 if c == 10"
            };

            Assert.AreEqual(10, Day08.Task2(instructions));
        }
    }
}
