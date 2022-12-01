using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode._2018
{
    public class Day10
    {
        private const string pattern = @"position=<\s*(?'x'-?\d+),\s*(?'y'-?\d+)> velocity=<\s*(?'horizontalSpeed'-?\d+),\s*(?'verticalSpeed'-?\d+)>";
        private static readonly Regex regex = new Regex(pattern);

        public static char[,] Task1(IEnumerable<string> points)
        {
            var sky = Parse(points);
            while (true)
            {
                var dimensions = sky.CalculateDimensions();
                var (_, verticalSpread) = dimensions.Spread;
                if (verticalSpread == 10)
                {
                    return sky.Draw(dimensions);
                }

                sky.NextSecond();
            }
        }

        public static int Task2(IEnumerable<string> points)
        {
            var second = 0;
            var sky = Parse(points);
            while (true)
            {
                var dimensions = sky.CalculateDimensions();
                var (_, verticalSpread) = dimensions.Spread;
                if (verticalSpread == 10)
                {
                    return second;
                }

                sky.NextSecond();
                second++;
            }
        }

        private static Sky Parse(IEnumerable<string> points)
        {
            return new Sky(points.Select(Parse));
        }

        private static Point Parse(string input)
        {
            var matches = regex.Match(input);
            var initialPosition = new Position(int.Parse(matches.Groups["x"].Value), int.Parse(matches.Groups["y"].Value));
            var velocity = new Velocity(int.Parse(matches.Groups["horizontalSpeed"].Value), int.Parse(matches.Groups["verticalSpeed"].Value));
            return new Point(velocity, initialPosition);
        }

        public static void Print(char[,] skyFrame)
        {
            Console.WriteLine();
            foreach (var y in Enumerable.Range(0, skyFrame.GetLength(1)))
            {
                foreach (var x in Enumerable.Range(0, skyFrame.GetLength(0)))
                {
                    Console.Write(skyFrame[x, y]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private class Position
        {
            public Position(int x, int y)
            {
                X = x;
                Y = y;
            }

            public int X { get; }

            public int Y { get; }

            public Position Move(Velocity velocity)
            {
                return new Position(X + velocity.HorizontalSpeed, Y + velocity.VerticalSpeed);
            }
        }

        private class Point
        {
            private readonly Velocity velocity;

            public Point(Velocity velocity, Position position)
            {
                this.velocity = velocity;
                Position = position;
            }

            public Position Position { get; private set; }

            public void Move()
            {
                Position = Position.Move(velocity);
            }
        }

        private class Velocity
        {
            public Velocity(int horizontalSpeed, int verticalSpeed)
            {
                HorizontalSpeed = horizontalSpeed;
                VerticalSpeed = verticalSpeed;
            }

            public int HorizontalSpeed { get; }

            public int VerticalSpeed { get; }
        }

        private class Sky
        {
            private readonly IEnumerable<Point> points;

            public Sky(IEnumerable<Point> points)
            {
                this.points = points.ToList();
            }

            public void NextSecond()
            {
                foreach (var point in points)
                {
                    point.Move();
                }
            }

            public Dimensions CalculateDimensions()
            {
                var left = points.Min(point => point.Position.X);
                var right = points.Max(point => point.Position.X);
                var bottom = points.Min(point => point.Position.Y);
                var top = points.Max(point => point.Position.Y);

                return new Dimensions(left, right, bottom, top);
            }

            public char[,] Draw(Dimensions dimensions)
            {
                var skyFrame = EmptySkyFram(dimensions);

                foreach (var point in points)
                {
                    if (dimensions.Contains(point.Position))
                    {
                        skyFrame[point.Position.X - dimensions.Left, point.Position.Y - dimensions.Bottom] = '#';
                    }
                }

                return skyFrame;
            }

            private char[,] EmptySkyFram(Dimensions dimensions)
            {
                var (horizontalSpread, verticalSpread) = dimensions.Spread;
                var skyFrame = new char[horizontalSpread, verticalSpread];

                foreach (var x in Enumerable.Range(0, horizontalSpread))
                {
                    foreach (var y in Enumerable.Range(0, verticalSpread))
                    {
                        skyFrame[x, y] = '.';
                    }
                }

                return skyFrame;
            }
        }

        private class Dimensions
        {
            public Dimensions(int left, int right, int bottom, int top)
            {
                Left = left;
                Right = right;
                Bottom = bottom;
                Top = top;
            }

            public int Left { get; }
            public int Right { get; }
            public int Bottom { get; }
            public int Top { get; }

            public bool Contains(Position position)
            {
                return Left <= position.X
                    && Right >= position.X
                    && Bottom <= position.Y
                    && Top >= position.Y;
            }

            public (int horizontalSpread, int verticalSpread) Spread
                => (Right - Left + 1, Top - Bottom + 1);
        }
    }
}
