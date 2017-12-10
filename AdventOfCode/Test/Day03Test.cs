using AdventOfCode;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class Day03Test
    {
        [TestMethod]
        public void Task1()
        {
            Assert.AreEqual(0, Day03.Task1(1));
            Assert.AreEqual(3, Day03.Task1(12));
            Assert.AreEqual(2, Day03.Task1(23));
            Assert.AreEqual(31, Day03.Task1(1024));
        }

        [TestMethod]
        public void Task2()
        {
            Assert.AreEqual(2, Day03.Task2(1));
            Assert.AreEqual(4, Day03.Task2(2));
            Assert.AreEqual(5, Day03.Task2(4));
            Assert.AreEqual(10, Day03.Task2(5));
            Assert.AreEqual(11, Day03.Task2(10));
            Assert.AreEqual(23, Day03.Task2(11));
            Assert.AreEqual(25, Day03.Task2(23));
            Assert.AreEqual(26, Day03.Task2(25));
            Assert.AreEqual(54, Day03.Task2(26));
            Assert.AreEqual(57, Day03.Task2(54));
            Assert.AreEqual(59, Day03.Task2(57));
            Assert.AreEqual(122, Day03.Task2(59));
            Assert.AreEqual(133, Day03.Task2(122));
            Assert.AreEqual(142, Day03.Task2(133));
            Assert.AreEqual(147, Day03.Task2(142));
            Assert.AreEqual(304, Day03.Task2(147));
            Assert.AreEqual(330, Day03.Task2(304));
            Assert.AreEqual(351, Day03.Task2(330));
            Assert.AreEqual(362, Day03.Task2(351));
            Assert.AreEqual(747, Day03.Task2(362));
            Assert.AreEqual(806, Day03.Task2(747));
        }
    }
}
