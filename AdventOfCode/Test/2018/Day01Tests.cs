using AdventOfCode._2018;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Test._2018
{
    [TestClass]
    public class Day01Tests
    {
        [TestMethod]
        public void Task1Test()
        {
            Assert.AreEqual(3, Day01.Task1(new List<int> { +1, -2, +3, +1 }));
            Assert.AreEqual(3, Day01.Task1(new List<int> { +1, +1, +1 }));
            Assert.AreEqual(0, Day01.Task1(new List<int> { +1, +1, -2 }));
            Assert.AreEqual(-6, Day01.Task1(new List<int> { -1, -2, -3 }));
        }

        [TestMethod]
        public void Task2Test()
        {
            Assert.AreEqual(0, Day01.Task2(new List<int> { +1, -1 }));
            Assert.AreEqual(10, Day01.Task2(new List<int> { +3, +3, +4, -2, -4 }));
            Assert.AreEqual(5, Day01.Task2(new List<int> { -6, +3, +8, +5, -6 }));
            Assert.AreEqual(14, Day01.Task2(new List<int> { +7, +7, -2, -7, -4 }));
        }
    }
}
