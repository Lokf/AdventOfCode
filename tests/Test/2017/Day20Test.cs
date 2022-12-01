using AdventOfCode._2017;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Test._2017
{
    [TestClass]
    public class Day20Test
    {
        [TestMethod]
        public void Task1()
        {
            var particles = new string[]
            {
                "p=<3,0,0>, v=<2,0,0>, a=<-1,0,0>",
                "p=<4,0,0>, v=<0,0,0>, a=<-2,0,0>"
            };

            Assert.AreEqual(0, Day20.Task1(particles));
        }

        [TestMethod]
        public void Task2()
        {
            var particles = new string[]
            {
                "p=<-6,0,0>, v=<3,0,0>, a=<0,0,0>",
                "p=<-4,0,0>, v=<2,0,0>, a=<0,0,0>",
                "p=<-2,0,0>, v=<1,0,0>, a=<0,0,0>",
                "p=< 3,0,0>, v=<-1,0,0>, a=<0,0,0>"
            };

            Assert.AreEqual(1, Day20.Task2(particles));
        }
    }
}
