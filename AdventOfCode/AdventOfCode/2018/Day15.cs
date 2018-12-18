using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2018
{
    public class Day15
    {
        public static int Task1(IEnumerable<string> input)
        {
            var (map, elves, goblins) = ParseInput(input);

            var units = new List<Unit>(elves);
            units.AddRange(goblins);

            var (score, winner, numberOfSurvivors) = Battle(map, units);
            return score;
        }

        public static int Task2(IEnumerable<string> input)
        {
            var (map, elves, goblins) = ParseInput(input);

            var attackingPower = 4;
            while (true)
            {
                var elvesReadyForBattle = elves.Select(elf => elf.Copy(attackingPower));
                var goblinsReadyForBattle = goblins.Select(goblin => goblin.Copy());

                var units = new List<Unit>(elvesReadyForBattle);
                units.AddRange(goblinsReadyForBattle);

                var (score, winner, numberOfSurvivors) = Battle(map, units);

                if (winner == 'E' && numberOfSurvivors == elves.Count())
                {
                    return score;
                }

                attackingPower++;
            }
        }

        private static (int score, char winner, int numberOfSurvivors) Battle(Map map, List<Unit> units)
        {
            var round = 0;
            while (true)
            {
                var unitsOrdered = units
                    .OrderBy(unit => unit.Position.Y)
                    .ThenBy(unit => unit.Position.X)
                    .ToList();

                foreach (var unit in unitsOrdered)
                {
                    if (!unit.IsAlive)
                    {
                        continue;
                    }

                    List<Position> targets = new List<Position>();
                    switch (unit)
                    {
                        case Elf _:
                            targets.AddRange(units.OfType<Goblin>().Select(goblin => goblin.Position));
                            break;
                        case Goblin _:
                            targets.AddRange(units.OfType<Elf>().Select(elf => elf.Position));
                            break;
                    }

                    if (!targets.Any())
                    {
                        var score = units.Sum(u => u.HitPoints) * round;
                        var winner = unit is Elf ? 'E' : 'G';
                        var numberOfSurvivors = units.Count();
                        return (score, winner, numberOfSurvivors);
                    }

                    Move(unit, targets, units.Select(u => u.Position).ToList(), map);

                    var canAttack = new List<Position>
                        {
                            unit.Position.Up,
                            unit.Position.Left,
                            unit.Position.Right,
                            unit.Position.Down,
                        };

                    var targetPositionsInRange = targets.Where(t => canAttack.Contains(t));
                    var targetsInRange = units
                        .Where(u => targetPositionsInRange.Contains(u.Position))
                        .GroupBy(u => u.HitPoints)
                        .OrderBy(u => u.Key)
                        .FirstOrDefault();

                    if (targetsInRange == null)
                    {
                        continue;
                    }

                    var target = targetsInRange.SingleOrDefault(t => t.Position == unit.Position.Up)
                        ?? targetsInRange.SingleOrDefault(t => t.Position == unit.Position.Left)
                        ?? targetsInRange.SingleOrDefault(t => t.Position == unit.Position.Right)
                        ?? targetsInRange.Single(t => t.Position == unit.Position.Down);

                    unit.Attack(target);
                    if (!target.IsAlive)
                    {
                        units.Remove(target);
                    }
                }

                round++;
            }
        }

        private static (Map map, IEnumerable<Elf> elves, IEnumerable<Goblin> goblins) ParseInput(IEnumerable<string> input)
        {
            var map = new Dictionary<Position, char>();
            var elves = new List<Elf>();
            var goblins = new List<Goblin>();

            var y = 0;
            foreach (var row in input)
            {
                var x = 0;
                foreach (var tile in row)
                {
                    var position = new Position(x, y);
                    switch (tile)
                    {
                        case '.':
                        case '#':
                            map.Add(position, tile);
                            break;
                        case 'E':
                            elves.Add(new Elf(position));
                            map.Add(position, '.');
                            break;
                        case 'G':
                            goblins.Add(new Goblin(position));
                            map.Add(position, '.');
                            break;
                    }

                    x++;
                }

                y++;
            }

            return (new Map(map), elves, goblins);
        }

        private static void Move(Unit unit, List<Position> enemies, List<Position> units, Map map)
        {
            var attackingPositions = enemies
                .SelectMany(enemy => enemy.Adjacents)
                .Where(tile => map.IsReachable(tile))
                .Except(units.Except(new List<Position> { unit.Position }))
                .ToList();

            if (attackingPositions.Contains(unit.Position))
            {
                return;
            }

            var bestPath = attackingPositions
                .Select(targetPosition => ShortestPath(unit.Position, targetPosition, units, map))
                .Where(path => path.Any())
                .OrderBy(path => path.Count())
                .ThenBy(path => path.Last().Y)
                .ThenBy(path => path.Last().X)
                .FirstOrDefault();

            if (bestPath == null)
            {
                return;
            }

            unit.Move(bestPath.First());
        }

        private static IEnumerable<Position> ShortestPath(Position from, Position to, List<Position> units, Map map)
        {
            var tilesToVisit = new Queue<Position>();
            var moves = new Dictionary<Position, Position>();
            tilesToVisit.Enqueue(from);
            moves.Add(from, new Position(-1, -1));
            while (tilesToVisit.Any())
            {
                var currentTile = tilesToVisit.Dequeue();
                if (currentTile == to)
                {
                    var path = new List<Position>
                    {
                        to,
                    };
                    var previousPosition = moves[currentTile];
                    while (previousPosition != from)
                    {
                        path.Add(previousPosition);
                        previousPosition = moves[previousPosition];
                    }

                    path.Reverse();
                    return path;
                }

                foreach (var adjacent in currentTile.Adjacents)
                {
                    if (map.IsReachable(adjacent) && !units.Contains(adjacent) && !moves.ContainsKey(adjacent))
                    {
                        moves.Add(adjacent, currentTile);
                        tilesToVisit.Enqueue(adjacent);
                    }
                }
            }

            return new List<Position>();
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

            public IEnumerable<Position> Adjacents
            {
                get
                {
                    yield return Up;
                    yield return Left;
                    yield return Right;
                    yield return Down;
                }
            }

            public bool IsAdjcentTo(Position other)
                => Adjacents.Contains(other);

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

        private class Map
        {
            private readonly Dictionary<Position, char> tiles;

            public int Width { get; }
            public int Height { get; }

            public Map(Dictionary<Position, char> tiles)
            {
                this.tiles = tiles;
                Width = tiles.Keys.Max(position => position.X) + 1;
                Height = tiles.Keys.Max(position => position.Y) + 1;
            }

            private bool IsInside(Position position)
            {
                return position.X >= 0
                    && position.X < Width
                    && position.Y >= 0
                    && position.Y < Height;
            }

            private bool IsOpenCavern(Position position)
            {
                return tiles[position] == '.';
            }

            public bool IsReachable(Position position)
                => IsInside(position) && IsOpenCavern(position);
        }

        private abstract class Unit
        {
            private readonly int attackingPower = 3;

            public Unit(Position position, int attackingPower)
            {
                HitPoints = 200;
                Position = position;
                this.attackingPower = attackingPower;
            }

            public Position Position { get; private set; }
            public int HitPoints { get; private set; }
            public bool IsAlive
                => HitPoints > 0;

            public void Move(Position position)
            {
                Position = position;
            }

            public void Attack(Unit target)
            {
                target.HitPoints -= attackingPower;
            }

            public abstract override string ToString();
        }

        private class Elf : Unit
        {
            public Elf(Position position, int attackingPower = 3)
                : base(position, attackingPower)
            {
            }

            public Elf Copy(int attackingPower)
            {
                return new Elf(this.Position, attackingPower);
            }

            public override string ToString()
            {
                return $"E: {Position} - {HitPoints} HP";
            }
        }

        private class Goblin : Unit
        {
            public Goblin(Position position)
                : base(position, 3)
            {
            }

            public Goblin Copy()
            {
                return new Goblin(this.Position);
            }

            public override string ToString()
            {
                return $"G: {Position} - {HitPoints} HP";
            }
        }
    }
}
