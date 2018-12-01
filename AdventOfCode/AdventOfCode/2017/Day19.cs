using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2017
{
    public class Day19
    {        
        public static string Task1(string[] routingDiagram)
        {
            var mazeRunner = new MazeRunner(routingDiagram);
            return mazeRunner.Run();
        }

        public static int Task2(string[] routingDiagram)
        {
            var mazeRunner = new MazeRunner(routingDiagram);
            mazeRunner.Run();

            return mazeRunner.Steps + 1;
        }

        private class MazeRunner
        {
            private readonly string[] routingDiagram;
            private readonly List<char> letters = new List<char>();
            private int row;
            private int column;
            private Direction direction = Direction.Down;
            public int Steps { get; private set; }

            public MazeRunner(string[] routingDiagram)
            {
                this.routingDiagram = routingDiagram;
            }

            public string Run()
            {
                row = 0;
                column = routingDiagram[0].IndexOf('|');

                while (true)
                {
                    direction = Direction.Down;
                    var steps = MoveAlongLine();

                    if (steps == 0)
                    {
                        direction = Direction.Up;
                        steps = MoveAlongLine();

                        if (steps == 0)
                        {
                            break;
                        }
                    }

                    Steps += steps;

                    direction = Direction.Left;
                    steps = MoveAlongLine();

                    if (steps == 0)
                    {
                        direction = Direction.Right;
                        steps = MoveAlongLine();

                        if (steps == 0)
                        {
                            break;
                        }
                    }

                    Steps += steps;
                }

                return string.Concat(letters);
            }

            private int MoveAlongLine()
            {
                var steps = 0;

                while (true)
                {
                    Move();
                    var kalle = routingDiagram[row][column];

                    if (kalle == ' ')
                    {
                        UnMove();
                        break;
                    }

                    steps++;

                    if (kalle == '+')
                    {
                        break;
                    }

                    if (char.IsLetter(kalle))
                    {
                        letters.Add(kalle);
                    }
                }

                return steps;
            }

            private void Move()
            {
                switch (direction)
                {
                    case Direction.Down:
                        row++;
                        return;
                    case Direction.Up:
                        row--;
                        return;
                    case Direction.Left:
                        column--;
                        return;
                    case Direction.Right:
                        column++;
                        return;
                }
            }

            private void UnMove()
            {
                switch (direction)
                {
                    case Direction.Down:
                        row--;
                        return;
                    case Direction.Up:
                        row++;
                        return;
                    case Direction.Left:
                        column++;
                        return;
                    case Direction.Right:
                        column--;
                        return;
                }
            }

            private enum Direction
            {
                Down = 1,
                Up = 2,
                Left = 3,
                Right = 4
            }
        }
    }
}
