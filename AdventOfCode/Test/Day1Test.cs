using AdventOfCode;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class Day1Test
    {
        [TestMethod]
        public void Task1()
        {
            Assert.AreEqual(3, Day1.Task1("1122"));
            Assert.AreEqual(4, Day1.Task1("1111"));
            Assert.AreEqual(0, Day1.Task1("1234"));
            Assert.AreEqual(9, Day1.Task1("91212129"));
        }

        [TestMethod]
        public void Task2()
        {
            Assert.AreEqual(6, Day1.Task2("1212"));
            Assert.AreEqual(0, Day1.Task2("1221"));
            Assert.AreEqual(4, Day1.Task2("123425"));
            Assert.AreEqual(12, Day1.Task2("123123"));
            Assert.AreEqual(4, Day1.Task2("12131415"));
        }
    }
}
