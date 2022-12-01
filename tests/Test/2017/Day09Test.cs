using AdventOfCode._2017;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Test._2017
{
    [TestClass]
    public class Day09Test
    {
        [TestMethod]
        public void Task1()
        {
            Assert.AreEqual(1, Day09.Task1("{}"));
            Assert.AreEqual(6, Day09.Task1("{{{}}}"));
            Assert.AreEqual(5, Day09.Task1("{{},{}}"));
            Assert.AreEqual(16, Day09.Task1("{{{},{},{{}}}}"));
            Assert.AreEqual(1, Day09.Task1("{<a>,<a>,<a>,<a>}"));
            Assert.AreEqual(9, Day09.Task1("{{<ab>},{<ab>},{<ab>},{<ab>}}"));
            Assert.AreEqual(9, Day09.Task1("{{<!!>},{<!!>},{<!!>},{<!!>}}"));
            Assert.AreEqual(3, Day09.Task1("{{<a!>},{<a!>},{<a!>},{<ab>}}"));
        }

        [TestMethod]
        public void Task2()
        {
            Assert.AreEqual(0, Day09.Task2("{<>}"));
            Assert.AreEqual(17, Day09.Task2("{<random characters>}"));
            Assert.AreEqual(3, Day09.Task2("{<<<<>}"));
            Assert.AreEqual(2, Day09.Task2("{<{!>}>}"));
            Assert.AreEqual(0, Day09.Task2("{<!!>}"));
            Assert.AreEqual(0, Day09.Task2("{<!!!>>}"));
            Assert.AreEqual(10, Day09.Task2("{<{o\"i!a,<{i<a>}"));
        }
    }
}
