using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode._2017
{
    public class Day03
    {
        public static int Task1(int square)
        {
            var coordinates = GetCoordinatesOfSquare(square);
            return Math.Abs(coordinates.X) + Math.Abs(coordinates.Y);
        }

        public static int Task2(int square)
        {
            return Values().First(value => value > square);
        }

        private static Coordinates GetCoordinatesOfSquare(int square)
        {
            var kalle = 1;
            var stepLength = 1;
            var increase = false;
            var coordinates = new Coordinates(0, 0);
            var direction = Direction.Right;

            while (kalle < square)
            {
                stepLength = Math.Min(stepLength, square - kalle);
                coordinates = NextCoordinates(coordinates, direction, stepLength);

                kalle += stepLength;
                direction = NextDirection(direction);

                if (increase)
                {
                    stepLength++;
                }

                increase = !increase;
            }

            return coordinates;
        }

        private static Coordinates NextCoordinates(Coordinates coordinates, Direction direction, int stepLength)
        {
            switch (direction)
            {
                case Direction.Up:
                    return new Coordinates(coordinates.X, coordinates.Y + stepLength);
                case Direction.Down:
                    return new Coordinates(coordinates.X, coordinates.Y - stepLength);
                case Direction.Left:
                    return new Coordinates(coordinates.X - stepLength, coordinates.Y);
                case Direction.Right:
                    return new Coordinates(coordinates.X + stepLength, coordinates.Y);

                default:
                    throw new ArgumentOutOfRangeException("direction");
            }
        }

        private static Direction NextDirection(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    return Direction.Left;
                case Direction.Down:
                    return Direction.Right;
                case Direction.Left:
                    return Direction.Down;
                case Direction.Right:
                    return Direction.Up;
                default:
                    throw new ArgumentOutOfRangeException("direction");
            }
        }

        private static IEnumerable<int> Values()
        {
            var history = new List<int>
            {
                1,
                1,
                2,
                4,
                5,
                10
            };

            yield return 1;
            yield return 1;
            yield return 2;
            yield return 4;
            yield return 5;
            yield return 10;

            var index = 6;
            var howFarBack = 6;
            var subIndex = 0;
            var size = 4;
            var increase = false;

            while (true)
            {
                int value;
                if (subIndex == 0)
                {
                    value = history[index - 1] + history[index - howFarBack];
                }
                else if (subIndex == 1)
                {
                    value = history[index - 1] + history[index - 2] + history[index - howFarBack] + history[index - howFarBack - 1];
                }
                else if (subIndex == size - 2)
                {
                    value = history[index - 1] + history[index - howFarBack - 1] + history[index - howFarBack - 2];
                }
                else if (subIndex == size - 1)
                {
                    value = history[index - 1] + history[index - howFarBack - 2];
                }
                else
                {
                    value = history[index - 1] + history[index - howFarBack] + history[index - howFarBack - 1] + history[index - howFarBack - 2];
                }

                if (subIndex == size - 1)
                {
                    subIndex = 0;
                    howFarBack += 2;
                    if (increase)
                    {
                        size ++;
                    }
                    increase = !increase;
                }
                index++;
                subIndex++;

                history.Add(value);
                yield return value;
            }
        }

        private class Coordinates
        {
            public Coordinates(int x, int y)
            {
                X = x;
                Y = y;
            }
            public int X { get; }
            public int Y { get; }
        }

        private enum Direction
        {
            Up,
            Down,
            Left,
            Right
        }
    }
}
