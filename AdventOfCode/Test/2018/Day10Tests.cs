using AdventOfCode._2018;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test._2018
{
    [TestClass]
    public class Day10Tests
    {
        [TestMethod]
        public void Task1Test()
        {
            var points = new List<string>
            {
                "position=< 9,  1> velocity=< 0,  2>",
                "position=< 7,  0> velocity=<-1,  0>",
                "position=< 3, -2> velocity=<-1,  1>",
                "position=< 6, 10> velocity=<-2, -1>",
                "position=< 2, -4> velocity=< 2,  2>",
                "position=<-6, 10> velocity=< 2, -2>",
                "position=< 1,  8> velocity=< 1, -1>",
                "position=< 1,  7> velocity=< 1,  0>",
                "position=<-3, 11> velocity=< 1, -2>",
                "position=< 7,  6> velocity=<-1, -1>",
                "position=<-2,  3> velocity=< 1,  0>",
                "position=<-4,  3> velocity=< 2,  0>",
                "position=<10, -3> velocity=<-1,  1>",
                "position=< 5, 11> velocity=< 1, -2>",
                "position=< 4,  7> velocity=< 0, -1>",
                "position=< 8, -2> velocity=< 0,  1>",
                "position=<15,  0> velocity=<-2,  0>",
                "position=< 1,  6> velocity=< 1,  0>",
                "position=< 8,  9> velocity=< 0, -1>",
                "position=< 3,  3> velocity=<-1,  1>",
                "position=< 0,  5> velocity=< 0, -1>",
                "position=<-2,  2> velocity=< 2,  0>",
                "position=< 5, -2> velocity=< 1,  2>",
                "position=< 1,  4> velocity=< 2,  1>",
                "position=<-2,  7> velocity=< 2, -2>",
                "position=< 3,  6> velocity=<-1, -1>",
                "position=< 5,  0> velocity=< 1,  0>",
                "position=<-6,  0> velocity=< 2,  0>",
                "position=< 5,  9> velocity=< 1, -2>",
                "position=<14,  7> velocity=<-2,  0>",
                "position=<-3,  6> velocity=< 2, -1>",
                "position=< 0,  9> velocity=< 0,  0>",
                "position=< 0,  8> velocity=< 0,  0>",
            };

            var message = new char[,]
            {                
                { '#', '.', '.', '.', '#', '.', '.', '#', '#', '#', },
                { '#', '.', '.', '.', '#', '.', '.', '.', '#', '.', },
                { '#', '.', '.', '.', '#', '.', '.', '.', '#', '.', },
                { '#', '#', '#', '#', '#', '.', '.', '.', '#', '.', },
                { '#', '.', '.', '.', '#', '.', '.', '.', '#', '.', },
                { '#', '.', '.', '.', '#', '.', '.', '.', '#', '.', },
                { '#', '.', '.', '.', '#', '.', '.', '.', '#', '.', },
                { '#', '.', '.', '.', '#', '.', '.', '#', '#', '#', },
                { '#', '.', '.', '.', '.', '.', '.', '.', '.', '.', },
                { '#', '.', '.', '.', '.', '.', '.', '.', '.', '.', },
            };

            var result = Day10
                .Task1(points);

            foreach (var x in Enumerable.Range(0, 10))
            {
                foreach (var y in Enumerable.Range(0, 10))
                {
                    // Swapped x and y.
                    Assert.AreEqual(message[x, y], result[y, x]);
                }
            }
        }

        [TestMethod]
        public void Task2Test()
        {
            var points = new List<string>
            {
                "position=< 9,  1> velocity=< 0,  2>",
                "position=< 7,  0> velocity=<-1,  0>",
                "position=< 3, -2> velocity=<-1,  1>",
                "position=< 6, 10> velocity=<-2, -1>",
                "position=< 2, -4> velocity=< 2,  2>",
                "position=<-6, 10> velocity=< 2, -2>",
                "position=< 1,  8> velocity=< 1, -1>",
                "position=< 1,  7> velocity=< 1,  0>",
                "position=<-3, 11> velocity=< 1, -2>",
                "position=< 7,  6> velocity=<-1, -1>",
                "position=<-2,  3> velocity=< 1,  0>",
                "position=<-4,  3> velocity=< 2,  0>",
                "position=<10, -3> velocity=<-1,  1>",
                "position=< 5, 11> velocity=< 1, -2>",
                "position=< 4,  7> velocity=< 0, -1>",
                "position=< 8, -2> velocity=< 0,  1>",
                "position=<15,  0> velocity=<-2,  0>",
                "position=< 1,  6> velocity=< 1,  0>",
                "position=< 8,  9> velocity=< 0, -1>",
                "position=< 3,  3> velocity=<-1,  1>",
                "position=< 0,  5> velocity=< 0, -1>",
                "position=<-2,  2> velocity=< 2,  0>",
                "position=< 5, -2> velocity=< 1,  2>",
                "position=< 1,  4> velocity=< 2,  1>",
                "position=<-2,  7> velocity=< 2, -2>",
                "position=< 3,  6> velocity=<-1, -1>",
                "position=< 5,  0> velocity=< 1,  0>",
                "position=<-6,  0> velocity=< 2,  0>",
                "position=< 5,  9> velocity=< 1, -2>",
                "position=<14,  7> velocity=<-2,  0>",
                "position=<-3,  6> velocity=< 2, -1>",
                "position=< 0,  9> velocity=< 0,  0>",
                "position=< 0,  8> velocity=< 0,  0>",
            };

            Assert.AreEqual(3, Day10.Task2(points));
        }
    }
}
