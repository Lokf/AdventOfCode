using AdventOfCode;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    [TestClass]
    public class Day11Test
    {
        [TestMethod]
        public void Task1()
        {
            Assert.AreEqual(3, Day11.Task1("ne,ne,ne".Split(',').ToList()));
            Assert.AreEqual(0, Day11.Task1("ne,ne,sw,sw".Split(',').ToList()));
            Assert.AreEqual(2, Day11.Task1("ne,ne,s,s".Split(',').ToList()));
            Assert.AreEqual(3, Day11.Task1("se,sw,se,sw,sw".Split(',').ToList()));
            Assert.AreEqual(2, Day11.Task1("nw,sw".Split(',').ToList()));
        }

        [TestMethod]
        public void Task2()
        {
            Assert.AreEqual(3, Day11.Task2("ne,ne,ne".Split(',').ToList()));
            Assert.AreEqual(2, Day11.Task2("ne,ne,sw,sw".Split(',').ToList()));
            Assert.AreEqual(2, Day11.Task2("ne,ne,s,s".Split(',').ToList()));
            Assert.AreEqual(3, Day11.Task2("se,sw,se,sw,sw".Split(',').ToList()));
        }
    }
}
