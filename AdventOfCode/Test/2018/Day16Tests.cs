using AdventOfCode._2018;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Test._2018
{
    [TestClass]
    public class Day16Tests
    {
        [TestMethod]
        public void Task1Test()
        {
            var input = new List<string>
            {
                "Before: [3, 2, 1, 1]",
                "9 2 1 2",
                "After:  [3, 2, 2, 1]",
            };

            Assert.AreEqual(1, Day16.Task1(input));
        }
    }
}
