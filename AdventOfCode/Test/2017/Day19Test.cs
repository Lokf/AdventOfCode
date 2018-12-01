using AdventOfCode._2017;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Test._2017
{
    [TestClass]
    public class Day19Test
    {
        [TestMethod]
        public void Task1()
        {
            var routingDiagram = new string[]
            {
                "     |          ",
                "     |  +--+    ",
                "     A  |  C    ",
                " F---|----E|--+ ",
                "     |  |  |  D ",
                "     +B-+  +--+ ",
                "                "
            };

            Assert.AreEqual("ABCDEF", Day19.Task1(routingDiagram));
        }

        [TestMethod]
        public void Task2()
        {
            var routingDiagram = new string[]
            {
                "     |          ",
                "     |  +--+    ",
                "     A  |  C    ",
                " F---|----E|--+ ",
                "     |  |  |  D ",
                "     +B-+  +--+ ",
                "                "
            };

            Assert.AreEqual(38, Day19.Task2(routingDiagram));
        }
    }
}
