using AdventOfCode._2017;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Test._2017
{
    [TestClass]
    public class Day25Test
    {
        [TestMethod]
        public void Task1()
        {
            var blueprint = new[]
            {
                "Begin in state A.",
                "Perform a diagnostic checksum after 6 steps.",
                "",
                "In state A:",
                "   If the current value is 0:",
                "    -Write the value 1.",
                "   - Move one slot to the right.",
                "   - Continue with state B.",
                "  If the current value is 1:",
                "    -Write the value 0.",
                "   - Move one slot to the left.",
                "   - Continue with state B.",
                "",
                "In state B:",
                "   If the current value is 0:",
                "    -Write the value 1.",
                "   - Move one slot to the left.",
                "   - Continue with state A.",
                "  If the current value is 1:",
                "    -Write the value 1.",
                "   - Move one slot to the right.",
                "   - Continue with state A."
            };

            Assert.AreEqual(3, Day25.Task1(blueprint));
        }

        [TestMethod]
        public void Task2()
        {

        }
    }
}
