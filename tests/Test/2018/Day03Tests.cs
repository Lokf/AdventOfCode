using AdventOfCode._2018;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Test._2018
{
    [TestClass]
    public class Day03Tests
    {
        [TestMethod]
        public void Task1Test()
        {
            var claims = new List<string>
            {
                "#1 @ 1,3: 4x4",
                "#2 @ 3,1: 4x4",
                "#3 @ 5,5: 2x2",
            };
            Assert.AreEqual(4, Day03.Task1(claims));
        }

        [TestMethod]
        public void Task2Test()
        {
            var claims = new List<string>
            {
                "#1 @ 1,3: 4x4",
                "#2 @ 3,1: 4x4",
                "#3 @ 5,5: 2x2",
            };
            Assert.AreEqual(3, Day03.Task2(claims));
        }
    }
}
