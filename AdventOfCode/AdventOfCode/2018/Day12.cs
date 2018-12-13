using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode._2018
{
    public class Day12
    {
        public static int Task1(IEnumerable<string> plantConfiguration)
        {
            var leftmostPot = ParseInitialState(plantConfiguration.First());
            var spreadRules = ParseSpreadRules(plantConfiguration.Skip(2));

            foreach (var i in Enumerable.Range(1, 20))
            {
                leftmostPot = NextGeneration(leftmostPot, spreadRules);
            }

            return leftmostPot.CalculateValue();
        }

        public static long Task2(IEnumerable<string> plantConfiguration)
        {
            var leftmostPot = ParseInitialState(plantConfiguration.First());
            var spreadRules = ParseSpreadRules(plantConfiguration.Skip(2));

            string previousState = null;
            var generation = 0;

            while (true)
            {
                var generationState = leftmostPot.ToString();
                if (generationState == previousState)
                {
                    var value = leftmostPot.CalculateValue();
                    var nextGeneration = NextGeneration(leftmostPot, spreadRules);
                    var nextValue = nextGeneration.CalculateValue();

                    return (50_000_000_000L - generation) * (nextValue - value) + value;
                }

                previousState = generationState;
                leftmostPot = NextGeneration(leftmostPot, spreadRules);
                generation++;
            }
        }
    
        private static Pot ParseInitialState(string initialState)
        {
            var pot0 = Pot.LeftmostPot(0, initialState[15] == '#');
            var rightmostPot = pot0;

            foreach (var pot in initialState.Skip(16))
            {
                rightmostPot = rightmostPot.AddToTheRight(pot == '#');
            }

            return pot0;
        }

        private static Dictionary<byte, bool> ParseSpreadRules(IEnumerable<string> spreadRules)
        {
            return spreadRules.ToDictionary(
                spreadRule => CalculateSpreadKey(spreadRule.Select(c => c == '#').Take(5)), 
                spreadRule => spreadRule[9] == '#');
        }

        private static byte CalculateSpreadKey(IEnumerable<bool> pots)
        {
            return (byte)pots
                .Select((pot, index) => (pot ? 1 << (4 - index) : 0))
                .Sum();
        }

        private static Pot NextGeneration(Pot leftmostPot, Dictionary<byte, bool> spreadRules)
        {
            var runningPattern = new Queue<bool>(new bool[] { false, false, false, false});

            var index = leftmostPot.Index - 2;
            var currentPotPreviousGeneration = leftmostPot;
            Pot currentPotNextGeneration = null;
            Pot leftmostPotNextGeneration = null;
            int? numberOfPotsRemainingToGenerate = null;

            while (true)
            {
                if (numberOfPotsRemainingToGenerate == 0)
                {
                    return leftmostPotNextGeneration.Trim();
                }
                if (currentPotPreviousGeneration == null)
                {
                    // We are at the end.
                    runningPattern.Enqueue(false);
                    if (numberOfPotsRemainingToGenerate.HasValue)
                    {
                        numberOfPotsRemainingToGenerate--;                        
                    }
                    else
                    {
                        numberOfPotsRemainingToGenerate = 3;
                    }                    
                }
                else
                {
                    runningPattern.Enqueue(currentPotPreviousGeneration.HasPlant);
                    currentPotPreviousGeneration = currentPotPreviousGeneration.PotToTheRight;
                }
                
                var spreadKey = CalculateSpreadKey(runningPattern);
                spreadRules.TryGetValue(spreadKey, out var hasPlant);
                if (currentPotNextGeneration == null)
                {  
                    currentPotNextGeneration = Pot.LeftmostPot(index, hasPlant);
                    leftmostPotNextGeneration = currentPotNextGeneration;
                }
                else
                {
                    currentPotNextGeneration = currentPotNextGeneration.AddToTheRight(hasPlant);
                }

                index++;                
                runningPattern.Dequeue();
            }
        }

        private class Pot
        { 
            public int Index { get; }
            public bool HasPlant { get; }
            public Pot PotToTheRight { get; private set; }
            private Pot(int index, bool hasPlant)
            {
                Index = index;
                HasPlant = hasPlant;
            }

            public Pot AddToTheRight(bool hasPlant)
            {
                PotToTheRight = new Pot(Index + 1, hasPlant);
                return PotToTheRight;
            }

            public static Pot LeftmostPot(int index, bool hasPlant)
            {
                return new Pot(index, hasPlant);
            }

            public override string ToString()
            {
                return (HasPlant ? '#' : '.') + PotToTheRight?.ToString();
            }

            public int CalculateValue()
            {
                return (HasPlant ? Index : 0) + (PotToTheRight?.CalculateValue() ?? 0);
            }

            public Pot Trim()
            {
                if (!HasPlant)
                {
                    return PotToTheRight.Trim();
                }

                return TrimRight();
            }

            private Pot TrimRight()
            {
                PotToTheRight = PotToTheRight?.TrimRight();
                if (PotToTheRight == null)
                {
                    return HasPlant ? this : null;
                }
                return this;
            }
        }
    }
}
