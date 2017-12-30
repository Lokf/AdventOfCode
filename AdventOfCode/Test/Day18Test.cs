using AdventOfCode;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    [TestClass]
    public class Day18Test
    {
        [TestMethod]
        public void Task1()
        {
            var instructions = new string[]
            {
                "set a 1",
                "add a 2",
                "mul a a",
                "mod a 5",
                "snd a",
                "set a 0",
                "rcv a",
                "jgz a -1",
                "set a 1",
                "jgz a -2"
            };

            Assert.AreEqual(4, Day18.Task1(instructions));
        }

        [TestMethod]
        public void Task2()
        {
            var instructions = new string[]
            {
                "snd 1",
                "snd 2",
                "snd p",
                "rcv a",
                "rcv b",
                "rcv c",
                "rcv d"
            };

            Assert.AreEqual(3, Day18.Task2(instructions));
        }
    }
}
