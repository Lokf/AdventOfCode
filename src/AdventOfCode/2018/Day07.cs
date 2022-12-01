using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode._2018
{
    public class Day07
    {
        public static string Task1(IEnumerable<string> instructions)
        {
            var blockings = instructions
                .Select(instruction => (blocker: instruction[5], blocked: instruction[36]));

            var rootSteps = GenerateBlockingTree(blockings);
            var completedSteps = new StringBuilder();
            var completableSteps = new SortedDictionary<char, Blockings>(rootSteps);
            do
            {
                var stepToComplete = completableSteps.First();
                completedSteps.Append(stepToComplete.Key);
                completableSteps.Remove(stepToComplete.Key);
                foreach (var blockedStep in stepToComplete.Value.Blocked)
                {
                    blockedStep.Blockers.Remove(stepToComplete.Key);
                    if (!blockedStep.Blockers.Any())
                    {
                        completableSteps.Add(blockedStep.Blocker, blockedStep);
                    }
                }
            }
            while (completableSteps.Any());

            return completedSteps.ToString();
        }

        public static int Task2(IEnumerable<string> instructions, int numberOfWorkers, int addedSecondsPerInstruction)
        {
            var blockings = instructions
                .Select(instruction => (blocker: instruction[5], blocked: instruction[36]));

            var rootSteps = GenerateBlockingTree(blockings);
            var completableSteps = new SortedDictionary<char, Blockings>(rootSteps);

            var second = 0;
            var instructionsWorkedOn = new Dictionary<int, SortedDictionary<char, Blockings>>();
            while (true)
            {
                if (!completableSteps.Any() && !instructionsWorkedOn.Any())
                {
                    break;
                }

                if (instructionsWorkedOn.TryGetValue(second, out var completedSteps))
                {
                    instructionsWorkedOn.Remove(second);

                    foreach (var completedStep in completedSteps)
                    {
                        foreach (var blockedStep in completedStep.Value.Blocked)
                        {
                            blockedStep.Blockers.Remove(completedStep.Key);
                            if (!blockedStep.Blockers.Any())
                            {
                                completableSteps.Add(blockedStep.Blocker, blockedStep);
                            }
                        }
                    }
                }

                foreach (var stepToComplete in completableSteps.Take(1 + numberOfWorkers - instructionsWorkedOn.Count).ToList())
                {
                    var completedAtSecond = second + NumberOFSecondsToComplete(stepToComplete.Key, addedSecondsPerInstruction);
                    if (!instructionsWorkedOn.TryGetValue(completedAtSecond, out var completionsAtSecond))
                    {                        
                        completionsAtSecond = new SortedDictionary<char, Blockings>();
                        instructionsWorkedOn.Add(completedAtSecond, completionsAtSecond);
                    }
                    completionsAtSecond.Add(stepToComplete.Key, stepToComplete.Value);
                    completableSteps.Remove(stepToComplete.Key);
                }

                second++;                
            }

            return second - 1;
        }

        private static Dictionary<char, Blockings> GenerateBlockingTree(IEnumerable<(char blocker, char blocked)> blockings)
        {
            var steps = blockings
                .Select(blocking => blocking.blocker)
                .Union(blockings.Select(blocking => blocking.blocked))
                .Distinct()
                .ToDictionary(step => step, step => new Blockings(step));

            var rootSteps = new Dictionary<char, Blockings>(steps);

            foreach (var blocking in blockings)
            {
                var blockingStep = steps[blocking.blocker];
                var blockedStep = steps[blocking.blocked];
                blockingStep.Blocked.Add(blockedStep);
                blockedStep.Blockers.Add(blockingStep.Blocker);
                rootSteps.Remove(blockedStep.Blocker);
            }

            return rootSteps;
        }

        private static int NumberOFSecondsToComplete(char step, int secondsToAdd)
        {
            return step - 64 + secondsToAdd;
        }

        private class Blockings
        {
            public Blockings(char blocker)
            {
                Blocker = blocker;
            }

            public char Blocker { get; }

            public List<Blockings> Blocked { get; } = new List<Blockings>();

            public HashSet<char> Blockers { get; } = new HashSet<char>();
        }
    }
}
