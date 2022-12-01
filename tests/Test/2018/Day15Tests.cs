using AdventOfCode._2018;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Test._2018
{
    [TestClass]
    public class Day15Tests
    {
        [TestMethod]
        public void Task1Test()
        {
            var input = new List<string>
            {
                "#######",
                "#.G...#",
                "#...EG#",
                "#.#.#G#",
                "#..G#E#",
                "#.....#",
                "#######",
            };
            Assert.AreEqual(27730, Day15.Task1(input));

            input = new List<string>
            {
                "#######",
                "#G..#E#",
                "#E#E.E#",
                "#G.##.#",
                "#...#E#",
                "#...E.#",
                "#######",
            };
            Assert.AreEqual(36334, Day15.Task1(input));

            input = new List<string>
            {
                "#######",
                "#E..EG#",
                "#.#G.E#",
                "#E.##E#",
                "#G..#.#",
                "#..E#.#",
                "#######",
            };
            Assert.AreEqual(39514, Day15.Task1(input));

            input = new List<string>
            {
                "#######",
                "#E.G#.#",
                "#.#G..#",
                "#G.#.G#",
                "#G..#.#",
                "#...E.#",
                "#######",
            };
            Assert.AreEqual(27755, Day15.Task1(input));

            input = new List<string>
            {
                "#######",
                "#.E...#",
                "#.#..G#",
                "#.###.#",
                "#E#G#G#",
                "#...#G#",
                "#######",
            };
            Assert.AreEqual(28944, Day15.Task1(input));

            input = new List<string>
            {
                "#########",
                "#G......#",
                "#.E.#...#",
                "#..##..G#",
                "#...##..#",
                "#...#...#",
                "#.G...G.#",
                "#.....G.#",
                "#########",
            };
            Assert.AreEqual(18740, Day15.Task1(input));
        }

        [TestMethod]
        public void Task2Test()
        {
            var input = new List<string>
            {
                "#######",
                "#.G...#",
                "#...EG#",
                "#.#.#G#",
                "#..G#E#",
                "#.....#",
                "#######",
            };
            Assert.AreEqual(4988, Day15.Task2(input));

            input = new List<string>
            {
                "#######",
                "#E..EG#",
                "#.#G.E#",
                "#E.##E#",
                "#G..#.#",
                "#..E#.#",
                "#######",
            };
            Assert.AreEqual(31284, Day15.Task2(input));

            input = new List<string>
            {
                "#######",
                "#E.G#.#",
                "#.#G..#",
                "#G.#.G#",
                "#G..#.#",
                "#...E.#",
                "#######",
            };
            Assert.AreEqual(3478, Day15.Task2(input));

            input = new List<string>
            {
                "#######",
                "#.E...#",
                "#.#..G#",
                "#.###.#",
                "#E#G#G#",
                "#...#G#",
                "#######",
            };
            Assert.AreEqual(6474, Day15.Task2(input));

            input = new List<string>
            {
                "#########",
                "#G......#",
                "#.E.#...#",
                "#..##..G#",
                "#...##..#",
                "#...#...#",
                "#.G...G.#",
                "#.....G.#",
                "#########",
            };
            Assert.AreEqual(1140, Day15.Task2(input));
        }
    }
}
