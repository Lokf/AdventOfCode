using Ardalis.SmartEnum;

namespace Lokf.AdventOfCode2022;

public static class Day02
{
    public static int Task1(IEnumerable<string> lines)
    {
        return Parse1(lines)
            .Sum(instruction => instruction.Score());
    }

    public static int Task2(IEnumerable<string> lines)
    {
        return Parse2(lines)
            .Sum(instruction => instruction.Score());
    }

    private static IEnumerable<Instruction1> Parse1(IEnumerable<string> lines)
    {
        foreach (var line in lines)
        {
            Shape opponent = ParseOpponent(line[0]);

            var suggestion = line[2] switch
            {
                'X' => Shape.Rock,
                'Y' => Shape.Paper,
                'Z' => Shape.Scissors,
            };

            yield return new Instruction1(opponent, suggestion);
        }
    }

    private static IEnumerable<Instruction2> Parse2(IEnumerable<string> lines)
    {
        foreach (var line in lines)
        {
            var opponent = ParseOpponent(line[0]);

            var requiredOutome = line[2] switch
            {
                'X' => Outcome.Loss,
                'Y' => Outcome.Draw,
                'Z' => Outcome.Win,
            };

            yield return new Instruction2(opponent, requiredOutome);
        }
    }

    private static Shape ParseOpponent(char value)
    {
        return value switch
        {
            'A' => Shape.Rock,
            'B' => Shape.Paper,
            'C' => Shape.Scissors,
        };
    }

    private abstract class Shape : SmartEnum<Shape>
    {
        public static readonly Shape Rock = new RockType();
        public static readonly Shape Paper = new PaperType();
        public static readonly Shape Scissors = new ScissorsType();

        protected Shape(string name, int value)
            : base(name, value)
        {
        }

        public abstract Outcome CalculateOutcome(Shape opponent);

        public abstract Shape CalculateRequiredCounterplay(Outcome desiredOutcome);

        public abstract int BaseScore { get; }

        private sealed class RockType : Shape
        {
            public RockType()
                : base("Rock", 1)
            {
            }

            public override Outcome CalculateOutcome(Shape opponent)
            {
                var outcome = Outcome.Draw;

                opponent
                    .When(Shape.Rock).Then(() => outcome = Outcome.Draw)
                    .When(Shape.Paper).Then(() => outcome = Outcome.Loss)
                    .When(Shape.Scissors).Then(() => outcome = Outcome.Win);

                return outcome;
            }

            public override Shape CalculateRequiredCounterplay(Outcome desiredOutcome)
            {
                var counterplay = Shape.Rock;

                desiredOutcome
                    .When(Outcome.Win).Then(() => counterplay = Shape.Paper)
                    .When(Outcome.Draw).Then(() => counterplay = Shape.Rock)
                    .When(Outcome.Loss).Then(() => counterplay = Shape.Scissors);

                return counterplay;
            }

            public override int BaseScore => 1;
        }

        private sealed class PaperType : Shape
        {
            public PaperType()
                : base("Paper", 2)
            {
            }

            public override Outcome CalculateOutcome(Shape opponent)
            {
                var outcome = Outcome.Draw;

                opponent
                    .When(Shape.Rock).Then(() => outcome = Outcome.Win)
                    .When(Shape.Paper).Then(() => outcome = Outcome.Draw)
                    .When(Shape.Scissors).Then(() => outcome = Outcome.Loss);

                return outcome;
            }

            public override Shape CalculateRequiredCounterplay(Outcome desiredOutcome)
            {
                var counterplay = Shape.Rock;

                desiredOutcome
                    .When(Outcome.Win).Then(() => counterplay = Shape.Scissors)
                    .When(Outcome.Draw).Then(() => counterplay = Shape.Paper)
                    .When(Outcome.Loss).Then(() => counterplay = Shape.Rock);

                return counterplay;
            }

            public override int BaseScore => 2;
        }

        private sealed class ScissorsType : Shape
        {
            public ScissorsType()
                : base("Scissors", 3)
            {
            }

            public override Outcome CalculateOutcome(Shape opponent)
            {
                var outcome = Outcome.Draw;

                opponent
                    .When(Shape.Rock).Then(() => outcome = Outcome.Loss)
                    .When(Shape.Paper).Then(() => outcome = Outcome.Win)
                    .When(Shape.Scissors).Then(() => outcome = Outcome.Draw);

                return outcome;
            }

            public override Shape CalculateRequiredCounterplay(Outcome desiredOutcome)
            {
                var counterplay = Shape.Rock;

                desiredOutcome
                    .When(Outcome.Win).Then(() => counterplay = Shape.Rock)
                    .When(Outcome.Draw).Then(() => counterplay = Shape.Scissors)
                    .When(Outcome.Loss).Then(() => counterplay = Shape.Paper);

                return counterplay;
            }

            public override int BaseScore => 3;
        }
    }

    private abstract class Outcome : SmartEnum<Outcome>
    {
        public static readonly Outcome Win = new WinType();
        public static readonly Outcome Draw = new DrawType();
        public static readonly Outcome Loss = new LossType();

        protected Outcome(string name, int value)
            : base(name, value)
        {
        }

        public abstract int Score { get; }

        private sealed class WinType : Outcome
        {
            public WinType()
                : base("Win", 1)
            {
            }

            public override int Score => 6;
        }


        private sealed class DrawType : Outcome
        {
            public DrawType()
                : base("Draw", 2)
            {
            }

            public override int Score => 3;
        }


        private sealed class LossType : Outcome
        {
            public LossType()
                : base("Loss", 3)
            {
            }

            public override int Score => 0;
        }
    }

    private sealed record Instruction1(Shape Opponent, Shape Suggestion)
    {
        public int Score()
        {
            var outcome = Suggestion.CalculateOutcome(Opponent);

            return outcome.Score + Suggestion.BaseScore;
        }
    };

    private sealed record Instruction2(Shape Opponent, Outcome RequiredOutcome)
    {
        public int Score()
        {
            var counterplay = Opponent.CalculateRequiredCounterplay(RequiredOutcome);

            return RequiredOutcome.Score + counterplay.BaseScore;
        }
    }; 
}
