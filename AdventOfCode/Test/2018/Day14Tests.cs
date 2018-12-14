using AdventOfCode._2018;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test._2018
{
    [TestClass]
    public class Day14Tests
    {
        [TestMethod]
        public void Task1Test()
        {
            Assert.AreEqual("5158916779", Day14.Task1(9));
            Assert.AreEqual("0124515891", Day14.Task1(5));
            Assert.AreEqual("9251071085", Day14.Task1(18));
            Assert.AreEqual("5941429882", Day14.Task1(2018));
        }

        [TestMethod]
        public void Task2Test()
        {
            Assert.AreEqual(9, Day14.Task2("51589"));
            Assert.AreEqual(5, Day14.Task2("01245"));
            Assert.AreEqual(18, Day14.Task2("92510"));
            Assert.AreEqual(2018, Day14.Task2("59414"));
        }
    }
}
