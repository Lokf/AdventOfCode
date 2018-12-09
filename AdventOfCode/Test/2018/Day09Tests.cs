using AdventOfCode._2018;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test._2018
{
    [TestClass]
    public class Day09Tests
    {
        [TestMethod]
        public void Task1Test()
        {
            Assert.AreEqual(32, Day09.Task1("9 players; last marble is worth 25 points"));
            Assert.AreEqual(8317, Day09.Task1("10 players; last marble is worth 1618 points"));
            Assert.AreEqual(146373, Day09.Task1("13 players; last marble is worth 7999 points"));
            Assert.AreEqual(2764, Day09.Task1("17 players; last marble is worth 1104 points"));
            Assert.AreEqual(54718, Day09.Task1("21 players; last marble is worth 6111 points"));
            Assert.AreEqual(37305, Day09.Task1("30 players; last marble is worth 5807 points"));
        }
    }
}
