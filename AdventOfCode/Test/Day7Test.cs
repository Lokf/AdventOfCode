using AdventOfCode;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Test
{
    [TestClass]
    public class Day7Test
    {
        [TestMethod]
        public void Task1()
        {
            var towers = new List<string>
            {
                "pbga (66)",
                "xhth (57)",
                "ebii (61)",
                "havc (66)",
                "ktlj (57)",
                "fwft (72) -> ktlj, cntj, xhth",
                "qoyq (66)",
                "padx (45) -> pbga, havc, qoyq",
                "tknk (41) -> ugml, padx, fwft",
                "jptl (61)",
                "ugml (68) -> gyxo, ebii, jptl",
                "gyxo (61)",
                "cntj (57)"
            };

            Assert.AreEqual("tknk", Day7.Task1(towers));
        }

        [TestMethod]
        public void Task2()
        {
            //Assert.AreEqual(4, Day7.Task2("0    2   7   0"));
        }
    }
}
