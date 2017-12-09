using AdventOfCode;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Test
{
    [TestClass]
    public class Day9Test
    {
        [TestMethod]
        public void Task1()
        {
            Assert.AreEqual(1, Day9.Task1("{}"));
            Assert.AreEqual(6, Day9.Task1("{{{}}}"));
            Assert.AreEqual(5, Day9.Task1("{{},{}}"));
            Assert.AreEqual(16, Day9.Task1("{{{},{},{{}}}}"));
            Assert.AreEqual(1, Day9.Task1("{<a>,<a>,<a>,<a>}"));
            Assert.AreEqual(9, Day9.Task1("{{<ab>},{<ab>},{<ab>},{<ab>}}"));
            Assert.AreEqual(9, Day9.Task1("{{<!!>},{<!!>},{<!!>},{<!!>}}"));
            Assert.AreEqual(3, Day9.Task1("{{<a!>},{<a!>},{<a!>},{<ab>}}"));
        }

        [TestMethod]
        public void Task2()
        {
            Assert.AreEqual(0, Day9.Task2("{<>}"));
            Assert.AreEqual(17, Day9.Task2("{<random characters>}"));
            Assert.AreEqual(3, Day9.Task2("{<<<<>}"));
            Assert.AreEqual(2, Day9.Task2("{<{!>}>}"));
            Assert.AreEqual(0, Day9.Task2("{<!!>}"));
            Assert.AreEqual(0, Day9.Task2("{<!!!>>}"));
            Assert.AreEqual(10, Day9.Task2("{<{o\"i!a,<{i<a>}"));
        }
    }
}
