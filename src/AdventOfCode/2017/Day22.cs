using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode._2017
{
    public class Day22
    {
        public static int Task1(string[] grid, int numberOfBursts)
        {
            var map = ParseMap(grid);
            var virus = new Virus();
            var infections = 0;

            for (int i = 0; i < numberOfBursts; i++)
            {
                (var row, var column) = virus.Position();
                var status = map.GetValueAt(row, column);
                if (status == '#')
                {
                    virus.TurnRight();
                    map.SetValueAt(row, column, '.');
                }
                else
                {
                    virus.TurnLeft();
                    map.SetValueAt(row, column, '#');
                    infections++;
                }

                virus.Move();
            }

            return infections;            
        }

        public static int Task2(string[] grid, int numberOfBursts)
        {
            var map = ParseMap(grid);
            var virus = new Virus();
            var infections = 0;

            for (int i = 0; i < numberOfBursts; i++)
            {
                (var row, var column) = virus.Position();
                var status = map.GetValueAt(row, column);
                if (status == '#')
                {
                    virus.TurnRight();
                    map.SetValueAt(row, column, 'F');
                }
                else if (status == 'W')
                {
                    infections++;
                    map.SetValueAt(row, column, '#');
                }
                else if (status == 'F')
                {
                    virus.Turn180();
                    map.SetValueAt(row, column, '.');
                }
                else
                {
                    virus.TurnLeft();
                    map.SetValueAt(row, column, 'W');                    
                }

                virus.Move();
            }

            return infections;
        }

        private static Map ParseMap(string[] rows)
        {
            var map = new Map();
            var offset = rows.Length / 2;
            var i = -offset;
            foreach (var row in rows)
            {
                var j = -offset;
                foreach (var node in row)
                {
                    map.SetValueAt(i, j, node);
                    j++;
                }

                i++;
            }

            return map;
        }

        private class Map
        {
            private Dictionary<(int, int), char> nodes = new Dictionary<(int, int), char>();

            public char GetValueAt(int row, int column)
            {
                if (nodes.TryGetValue((row, column), out var value))
                {
                    return value;
                }

                return '.';
            }

            public void SetValueAt(int row, int column, char value)
            {
                if (nodes.ContainsKey((row, column)))
                {
                    nodes[(row, column)] = value;
                }
                else
                {
                    nodes.Add((row, column), value);
                }
            }
        }

        private class Virus
        {
            private int row;
            private int column;
            private Direction direction;

            public void TurnLeft()
            {
                direction = (Direction)(((int)direction + 3) % 4);
            }

            public void TurnRight()
            {
                direction = (Direction)(((int)direction + 1) % 4);
            }

            public void Turn180()
            {
                direction = (Direction)(((int)direction + 2) % 4);
            }
            
            public void Move()
            {
                switch (direction)
                {
                    case Direction.Up:
                        row--;
                        return;
                    case Direction.Right:
                        column++;
                        return;
                    case Direction.Down:
                        row++;
                        return;
                    case Direction.Left:
                        column--;
                        return;
                }
            }

            public (int row, int column) Position()
            {
                return (row, column);
            }
        }               

        private enum Direction
        {
            Up = 0,
            Right = 1,
            Down = 2,
            Left = 3
        }
    }
}
