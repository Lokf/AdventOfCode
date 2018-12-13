using AdventOfCode._2018;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test._2018
{
    [TestClass]
    public class Day13Tests
    {
        [TestMethod]
        public void Task1Test()
        {
            var map = new List<string>
            {
                @"/->-\        ",
                @"|   |  /----\",
                @"| /-+--+-\  |",
                @"| | |  | v  |",
                @"\-+-/  \-+--/",
                @"  \------/   ",
            };

            Assert.AreEqual((7, 3), Day13.Task1(map));
        }

        [TestMethod]
        public void Task2Test()
        {
            var map = new List<string>
            {
                @"/>-<\  ",
                @"|   |  ",
                @"| /<+-\",
                @"| | | v",
                @"\>+</ |",
                @"  |   ^",
                @"  \<->/",
            };

            Assert.AreEqual((6, 4), Day13.Task2(map));
        }
    }
}
