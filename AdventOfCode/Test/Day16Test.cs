using AdventOfCode;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    [TestClass]
    public class Day16Test
    {
        [TestMethod]
        public void Task1()
        {
            Assert.AreEqual("baedc", Day16.Task1(5, "s1,x3/4,pe/b"));
        }

        [TestMethod]
        public void Task2()
        {
            Assert.AreEqual("ceadb", Day16.Task2(5, "s1,x3/4,pe/b", 2));
        }
    }
}
