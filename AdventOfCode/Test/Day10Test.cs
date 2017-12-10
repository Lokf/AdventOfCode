using AdventOfCode;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Test
{
    [TestClass]
    public class Day10Test
    {
        [TestMethod]
        public void Task1()
        {
            var lenghts = new List<int> {
                3,
                4,
                1,
                5
            };

            Assert.AreEqual(12, Day10.Task1(lenghts, 5));
        }

        [TestMethod]
        public void Task2()
        {
            Assert.AreEqual("a2582a3a0e66e6e86e3812dcb672a272", Day10.Task2("".ToCharArray(), 256));
            Assert.AreEqual("33efeb34ea91902bb2f59c9920caa6cd", Day10.Task2("AoC 2017".ToCharArray(), 256));
            Assert.AreEqual("3efbe78a8d82f29979031a4aa0b16a9d", Day10.Task2("1,2,3".ToCharArray(), 256));
            Assert.AreEqual("63960835bcdc130f0b66d7ff4f6a5a8e", Day10.Task2("1,2,4".ToCharArray(), 256));
        }
    }
}
