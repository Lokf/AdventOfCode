using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode._2017
{
    public class Day20
    {        
        private static readonly Regex regex = new Regex(@"p=\<(?<p>[^;]+?)\>.+v=\<(?<v>[^;]+?)\>.+a=\<(?<a>[^;]+?)\>");

        public static int Task1(string[] particles)
        {
            var manhattanAccelerations = new List<int>(particles.Length);

            foreach (var particle in particles)
            {
                var a = particle.IndexOf('a');
                var values = particle.Substring(a + 3, particle.Length - a - 4).Split(',');
                manhattanAccelerations.Add(values.Sum(x => Math.Abs(int.Parse(x))));
            }

            var min = manhattanAccelerations.Min(x => x);
            return manhattanAccelerations.IndexOf(min);
        }

        public static int Task2(string[] particles)
        {
            var parsedParticles = particles
                .Select(ParseParticle)
                .ToArray();

            var collisions = new List<Collision>();

            for (var i = 0; i < parsedParticles.Length; i++)
            {
                var particleA = parsedParticles[i];
                for (var j = i + 1; j < parsedParticles.Length; j++)
                {                    
                    var particleB = parsedParticles[j];
                    var tick = particleA.IsCollidingAt(particleB);
                    if (tick.HasValue)
                    {
                        collisions.Add(new Collision(i, j, tick.Value));
                    }
                }
            }

            var dead = new HashSet<int>();

            foreach (var tick in collisions.ToLookup(x => x.Tick, x => x).OrderBy(x => x.Key))
            {
                var deadAtTick = new List<int>();

                foreach (var collision in tick)
                {
                    if (dead.Contains(collision.ParticleA) || dead.Contains(collision.ParticleB))
                    {
                        continue;
                    }

                    deadAtTick.Add(collision.ParticleA);
                    deadAtTick.Add(collision.ParticleB);
                }
                
                foreach (var a in deadAtTick)
                {
                    dead.Add(a);
                }
            } 

            return parsedParticles.Length - dead.Count;                
        }
        
        private static Particle ParseParticle(string particle)
        {
            var matches = regex.Match(particle);

            var position = matches
                .Groups["p"]
                .Value
                .Split(',')
                .Select(int.Parse)
                .ToArray();

            var velocity = matches
                .Groups["v"]
                .Value
                .Split(',')
                .Select(int.Parse)
                .ToArray();

            var acceleration = matches
                .Groups["a"]
                .Value
                .Split(',')
                .Select(int.Parse)
                .ToArray();

            return new Particle(
                new Vector(position[0], position[1], position[2]),
                new Vector(velocity[0], velocity[1], velocity[2]),
                new Vector(acceleration[0], acceleration[1], acceleration[2]));
        }

        private static IEnumerable<int> PositiveRoots(int a, int b, int c)
        {
            if (a == 0)
            {
                if (b == 0)
                {
                    if (c == 0)
                    {
                        yield return -1;
                    }

                    yield break;
                }

                if (c % b == 0)
                {
                    yield return (-c / b);
                }

                yield break;
            }

            var squareRoot = IsPerfectSquare(b * b - 4 * a * c);
            if (!squareRoot.HasValue)
            {
                yield break;
            }

            var root = (-b + squareRoot.Value) / (decimal)(2 * a);
            if (root % 1 == 0 && root >= 0)
            {
                yield return (int)root;
            }

            root = (-b - squareRoot.Value) / (decimal)(2 * a);
            if (root % 1 == 0 && root >= 0)
            {
                yield return (int)root;
            }
        }

        private static bool IsRoot(int a, int b, int c, int root)
        {
            return a * root * root + b * root + c == 0;
        }

        private static int? IsPerfectSquare(int value)
        {
            var squareRoot = (int)Math.Sqrt(value);

            return squareRoot * squareRoot == value ? (int?)squareRoot : null;
        }

        private class Vector
        {
            public int X { get; }
            public int Y { get; }
            public int Z { get; }

            public Vector(int x, int y, int z)
            {
                X = x;
                Y = y;
                Z = z;
            }
        }

        private class Collision
        {
            public int ParticleA { get; }
            public int ParticleB { get; }
            public int Tick { get; }

            public Collision(int particleA, int particleB, int tick)
            {
                ParticleA = particleA;
                ParticleB = particleB;
                Tick = tick;
            }
        }

        private class Particle
        {
            public Vector Position { get; }
            public Vector Velocity { get; }
            public Vector Acceleration { get; }

            public Particle(Vector position, Vector velocity, Vector acceleration)
            {
                Position = position;
                Velocity = velocity;
                Acceleration = acceleration;
            }

            public int? IsCollidingAt(Particle other)
            {
                var roots = PositiveRoots(Acceleration.X - other.Acceleration.X, Acceleration.X - other.Acceleration.X + 2 * (Velocity.X - other.Velocity.X), 2 * (Position.X - other.Position.X))
                    .OrderBy(x => x)
                    .ToList();
                
                if (!roots.Any())
                {
                    return null;
                }
                if (roots.First() == -0)
                {
                    roots = PositiveRoots(Acceleration.Y - other.Acceleration.Y, Acceleration.Y - other.Acceleration.Y + 2 * (Velocity.Y - other.Velocity.Y), 2 * (Position.Y - other.Position.Y))
                        .OrderBy(x => x)
                        .ToList();

                    if (!roots.Any())
                    {
                        return null;
                    }

                    if (roots.First() == -0)
                    {
                        return PositiveRoots(Acceleration.Z - other.Acceleration.Z, Acceleration.Z - other.Acceleration.Z + 2 * (Velocity.Z - other.Velocity.Z), 2 * (Position.Z - other.Position.Z)).FirstOrDefault();
                    }

                    foreach (var root in roots)
                    {
                        if (IsRoot(Acceleration.Z - other.Acceleration.Z, Acceleration.Z - other.Acceleration.Z + 2 * (Velocity.Z - other.Velocity.Z), 2 * (Position.Z - other.Position.Z), root))
                        {
                            return root;
                        }
                    }
                }

                foreach (var root in roots)
                {
                    if (IsRoot(Acceleration.Y - other.Acceleration.Y, Acceleration.Y - other.Acceleration.Y + 2 * (Velocity.Y - other.Velocity.Y), 2 * (Position.Y - other.Position.Y), root) &&
                    IsRoot(Acceleration.Z - other.Acceleration.Z, Acceleration.Z - other.Acceleration.Z + 2 * (Velocity.Z - other.Velocity.Z), 2 * (Position.Z - other.Position.Z), root))
                    {
                        return root;
                    }
                }

                return null;
            }

            private Vector[] Differences(Particle other)
            {
                return new Vector[]
                {
                    new Vector(Acceleration.X - other.Acceleration.X, Velocity.X - other.Velocity.X, Position.X - other.Position.X),
                    new Vector(Acceleration.Y - other.Acceleration.Y, Velocity.Y - other.Velocity.Y, Position.Y - other.Position.Y),
                    new Vector(Acceleration.Z - other.Acceleration.Z, Velocity.Z - other.Velocity.Z, Position.Z - other.Position.Z),
                };
            }
        }
    }
}
