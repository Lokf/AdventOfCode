using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode._2018
{
    public class Day13
    {
        public static (int x, int y) Task1(IEnumerable<string> initialState)
        {
            var (map, carts) = ParseMap(initialState);

            while (true)
            {
                var orderedCarts = carts
                    .OrderBy(cart => cart.Position.Y)
                    .ThenBy(cart => cart.Position.X)
                    .ToList();

                foreach (var cart in orderedCarts)
                {
                    var newPosition = cart.Move(map);

                    if (IsCollisison(carts.Select(c => c.Position)))
                    {
                        return (newPosition.X, newPosition.Y);
                    }
                }
            }
        }

        public static (int x, int y) Task2(IEnumerable<string> initialState)
        {
            var (map, carts) = ParseMap(initialState);

            while (true)
            {
                if (carts.Count() == 1)
                {
                    var lastPosition = carts.Single().Position;
                    return (lastPosition.X, lastPosition.Y);
                }

                var orderedCarts = carts
                    .OrderBy(cart => cart.Position.Y)
                    .ThenBy(cart => cart.Position.X)
                    .ToList();

                foreach (var cart in orderedCarts)
                {
                    var newPosition = cart.Move(map);

                    if (IsCollisison(carts.Select(c => c.Position)))
                    {
                        carts = carts.Where(c => c.Position != newPosition).ToList();                        
                    }
                }
            }
        }

        private static (Dictionary<Position, char> map, IEnumerable<Cart> carts) ParseMap(IEnumerable<string> initialState)
        {
            var map = new Dictionary<Position, char>();
            var carts = new List<Cart>();

            var y = 0;
            foreach (var row in initialState)
            {
                var x = -1;
                foreach (var mapInfo in row)
                {
                    var track = mapInfo;
                    x++;
                    switch (mapInfo)
                    {
                        case ' ':
                            continue;
                        case '^':
                        case '<':
                        case 'v':
                        case '>':
                            carts.Add(new Cart(new Position(x, y), mapInfo));
                            track = '?';
                            break;
                    }

                    map.Add(new Position(x, y), track);
                }
                y++;
            }

            ResolveUnknowns(map);
            return (map, carts);
        }

        private static void ResolveUnknowns(Dictionary<Position, char> map)
        {
            var unknownTracks = map
                .Where(track => track.Value == '?')
                .ToList();

            foreach (var unknownTrack in unknownTracks)
            {
                if (IsIntersection(map, unknownTrack.Key))
                {
                    map[unknownTrack.Key] = '+';
                }
                else if (map.ContainsKey(unknownTrack.Key.Up)
                    && map.ContainsKey(unknownTrack.Key.Down))
                {
                    map[unknownTrack.Key] = '|';
                }
                else if (map.ContainsKey(unknownTrack.Key.Left)
                    && map.ContainsKey(unknownTrack.Key.Right))
                {
                    map[unknownTrack.Key] = '-';
                }
                else if (map.ContainsKey(unknownTrack.Key.Up)
                    && map.ContainsKey(unknownTrack.Key.Right))
                {
                    map[unknownTrack.Key] = '\\';
                }
                else if (map.ContainsKey(unknownTrack.Key.Down)
                    && map.ContainsKey(unknownTrack.Key.Left))
                {
                    map[unknownTrack.Key] = '\\';
                }
                else if (map.ContainsKey(unknownTrack.Key.Up)
                    && map.ContainsKey(unknownTrack.Key.Left))
                {
                    map[unknownTrack.Key] = '/';
                }
                else if (map.ContainsKey(unknownTrack.Key.Down)
                    && map.ContainsKey(unknownTrack.Key.Right))
                {
                    map[unknownTrack.Key] = '/';
                }
            }
        }

        private static bool IsIntersection(Dictionary<Position, char> map, Position position)
        {
            if (!map.TryGetValue(position.Up, out var up))
            {
                return false;
            }
            if (!map.TryGetValue(position.Down, out var down))
            {
                return false;
            }
            if (!map.TryGetValue(position.Left, out var left))
            {
                return false;
            }
            if (!map.TryGetValue(position.Right, out var right))
            {
                return false;
            }
            if (up == '-')
            {
                return false;
            }
            if (down == '-')
            {
                return false;
            }
            if (left == '|')
            {
                return false;
            }
            if (right == '|')
            {
                return false;
            }

            return true;
        }

        private static bool IsCollisison(IEnumerable<Position> positions)
        {
            return positions
                .GroupBy(position => position)
                .OrderByDescending(position => position.Count())
                .First()
                .Count() > 1;
        }

        private class Cart
        {
            private static readonly Dictionary<(char, IntersectionChoice), char> intersectionTurns = new Dictionary<(char, IntersectionChoice), char>
            {
                { ('^', IntersectionChoice.Left), '<' },
                { ('<', IntersectionChoice.Left), 'v' },
                { ('v', IntersectionChoice.Left), '>' },
                { ('>', IntersectionChoice.Left), '^' },
                { ('^', IntersectionChoice.Straight), '^' },
                { ('<', IntersectionChoice.Straight), '<' },
                { ('v', IntersectionChoice.Straight), 'v' },
                { ('>', IntersectionChoice.Straight), '>' },
                { ('^', IntersectionChoice.Right), '>' },
                { ('<', IntersectionChoice.Right), '^' },
                { ('v', IntersectionChoice.Right), '<' },
                { ('>', IntersectionChoice.Right), 'v' },
            };

            private static readonly Dictionary<(char, char), char> turns = new Dictionary<(char, char), char>
            {
                { ('^', '\\'), '<' },
                { ('<', '\\'), '^' },
                { ('v', '\\'), '>' },
                { ('>', '\\'), 'v' },
                { ('^', '/'), '>' },
                { ('<', '/'), 'v' },
                { ('v', '/'), '<' },
                { ('>', '/'), '^' },
            };

            public Position Position { get; private set; }       
            private char direction;
            private IntersectionChoice intersectionChoice;

            public Cart(Position position, char direction)
            {
                Position = position;
                this.direction = direction;
                intersectionChoice = IntersectionChoice.Left;
            }

            public Position Move(Dictionary<Position, char> map)
            {
                Move();
                Turn(map[Position]);
                return Position;
            }

            private void Move()
            {
                switch (direction)
                {
                    case '^':
                        Position = Position.Up;
                        return;
                    case '<':
                        Position = Position.Left;
                        return;
                    case 'v':
                        Position = Position.Down;
                        return;
                    case '>':
                        Position = Position.Right;
                        return;
                }
            }

            private void Turn(char track)
            {
                switch (track)
                {
                    case '+':
                        direction = intersectionTurns[(direction, intersectionChoice)];
                        intersectionChoice = (IntersectionChoice)((int)(intersectionChoice + 1) % 3);
                        return;
                    case '\\':
                        direction = turns[(direction, '\\')];
                        return;
                    case '/':
                        direction = turns[(direction, '/')];
                        return;
                }
            }

            private enum IntersectionChoice
            {
                Left,
                Straight,
                Right
            }
        }

        private class Position : IEquatable<Position>
        {
            public Position(int x, int y)
            {
                X = x;
                Y = y;
            }

            public int X { get; }
            public int Y { get; }

            public Position Up => new Position(X, Y - 1);
            public Position Down => new Position(X, Y + 1);
            public Position Left => new Position(X - 1, Y);
            public Position Right => new Position(X + 1, Y);

            public override string ToString()
            {
                return $"({X}, {Y})";
            }

            public override bool Equals(object obj)
            {
                return Equals(obj as Position); 
            }

            public override int GetHashCode()
            {
                var hashCode = 1861411795;
                hashCode = hashCode * -1521134295 + X.GetHashCode();
                hashCode = hashCode * -1521134295 + Y.GetHashCode();
                return hashCode;
            }

            public bool Equals(Position other)
            {
                if (other == null)
                {
                    return false;
                }
                return X == other.X
                    && Y == other.Y;
            }

            public static bool operator ==(Position obj1, Position obj2)
            {
                if (ReferenceEquals(obj1, obj2))
                {
                    return true;
                }

                if (obj1 is null)
                {
                    return false;
                }
                if (obj2 is null)
                {
                    return false;
                }

                return obj1.Equals(obj2);
            }

            public static bool operator !=(Position obj1, Position obj2)
            {
                return !(obj1 == obj2);
            }
        }        
    }
}
