using AdventOfCode._2017;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test._2017
{
    [TestClass]
    public class Day01Test
    {
        [TestMethod]
        public void Task1()
        {
            Assert.AreEqual(3, Day01.Task1("1122"));
            Assert.AreEqual(4, Day01.Task1("1111"));
            Assert.AreEqual(0, Day01.Task1("1234"));
            Assert.AreEqual(9, Day01.Task1("91212129"));
        }

        [TestMethod]
        public void Task2()
        {
            Assert.AreEqual(6, Day01.Task2("1212"));
            Assert.AreEqual(0, Day01.Task2("1221"));
            Assert.AreEqual(4, Day01.Task2("123425"));
            Assert.AreEqual(12, Day01.Task2("123123"));
            Assert.AreEqual(4, Day01.Task2("12131415"));
        }
    }
}
