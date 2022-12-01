using AdventOfCode._2017;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Test._2017
{
    [TestClass]
    public class Day24Test
    {
        [TestMethod]
        public void Task1()
        {
            var components = new string[]
            {
                "0/2",
                "2/2",
                "2/3",
                "3/4",
                "3/5",
                "0/1",
                "10/1",
                "9/10"
            };

            Assert.AreEqual(31, Day24.Task1(components));
        }

        [TestMethod]
        public void Task2()
        {
            var components = new string[]
            {
                "0/2",
                "2/2",
                "2/3",
                "3/4",
                "3/5",
                "0/1",
                "10/1",
                "9/10"
            };

            Assert.AreEqual(19, Day24.Task2(components));
        }
    }
}
