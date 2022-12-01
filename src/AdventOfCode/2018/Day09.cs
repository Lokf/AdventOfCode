using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode._2018
{
    public class Day09
    {
        private const string pattern = @"(?'numberOfPlayers'\d+) players; last marble is worth (?'numberOfMarbles'\d+) points";
        private static readonly Regex regex = new Regex(pattern);

        public static long Task1(string gameInput)
        {
            var matches = regex.Match(gameInput);
            var numberOfPlayers = int.Parse(matches.Groups["numberOfPlayers"].Value);
            var numberOfMarbles = int.Parse(matches.Groups["numberOfMarbles"].Value);
            return PlayMarble(numberOfPlayers, numberOfMarbles);
        }

        public static long Task2(string gameInput)
        {
            var matches = regex.Match(gameInput);
            var numberOfPlayers = int.Parse(matches.Groups["numberOfPlayers"].Value);
            var numberOfMarbles = int.Parse(matches.Groups["numberOfMarbles"].Value);
            return PlayMarble(numberOfPlayers, 100 * numberOfMarbles);
        }

        private static long PlayMarble(int numberOfPlayers, int numberOfMarbles)
        {
            var playerScores = Enumerable
                .Range(0, numberOfPlayers)
                .ToDictionary(i => i, _ => 0L);

            var currentMarble = new Marble(0);
            var currentPlayer = 0;
            foreach (var marbleValue in Enumerable.Range(1, numberOfMarbles))
            {
                var marble = new Marble(marbleValue);
                if (marbleValue % 23 == 0)
                {
                    playerScores[currentPlayer] += marbleValue;
                    var marbleToRemove = currentMarble.GetCounterclockwise(7);
                    playerScores[currentPlayer] += marbleToRemove.Value;
                    currentMarble = marbleToRemove.Remove();
                }
                else
                {
                    currentMarble = currentMarble.Clockwise.InsertClockwise(marble);
                }

                currentPlayer++;
                if (currentPlayer == numberOfPlayers)
                {
                    currentPlayer = 0;
                }
            }

            return playerScores
                .Values
                .Max();
        }

        private class Marble
        {
            public Marble(int value)
            {
                if (value == 0)
                {
                    Clockwise = this;
                    Counterclockwise = this;
                }
                Value = value;
            }

            public int Value { get; }
            public Marble Clockwise { get; private set; }
            public Marble Counterclockwise { get; private set; }

            public Marble InsertClockwise(Marble marble)
            {
                marble.Counterclockwise = this;
                marble.Clockwise = Clockwise;

                Clockwise.Counterclockwise = marble;
                Clockwise = marble;

                return marble;
            }

            public Marble Remove()
            {
                Counterclockwise.Clockwise = Clockwise;
                Clockwise.Counterclockwise = Counterclockwise;
                return Clockwise;
            }

            public Marble GetCounterclockwise(int numberOfSteps)
            {
                if (numberOfSteps == 0)
                {
                    return this;
                }
                return Counterclockwise.GetCounterclockwise(numberOfSteps - 1);
            }
        }
    }
}
