using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2018
{
    public class Day14
    {
        public static string Task1(int numberOfRecipes)
        {
            var recipes = new List<int>(numberOfRecipes + 11)
            {
                3,
                7,
            };

            var elf1Index = 0;
            var elf2Index = 1;

            while (recipes.Count() < numberOfRecipes + 10)
            {
                var recipe1 = recipes[elf1Index];
                var recipe2 = recipes[elf2Index];
                var newRecipe = recipe1 + recipe2;

                if (newRecipe > 9)
                {
                    recipes.Add(1);
                    recipes.Add(newRecipe - 10);
                }
                else
                {
                    recipes.Add(newRecipe);
                }

                elf1Index = (elf1Index + recipe1 + 1) % recipes.Count();
                elf2Index = (elf2Index + recipe2 + 1) % recipes.Count();
            }

            return string.Join("", recipes.Skip(numberOfRecipes).Take(10));
        }

        public static int Task2(string pattern)
        {
            var recipes = new List<int>
            {
                3,
                7,
            };

            var elf1Index = 0;
            var elf2Index = 1;

            while (true)
            {
                var recipe1 = recipes[elf1Index];
                var recipe2 = recipes[elf2Index];
                var newRecipe = recipe1 + recipe2;

                if (newRecipe > 9)
                {
                    recipes.Add(1);
                    if (IsMatch(recipes.Skip(recipes.Count - pattern.Length), pattern))
                    {
                        return recipes.Count - pattern.Length;
                    }
                    recipes.Add(newRecipe - 10);
                    if (IsMatch(recipes.Skip(recipes.Count - pattern.Length), pattern))
                    {
                        return recipes.Count - pattern.Length;
                    }
                }
                else
                {
                    recipes.Add(newRecipe);
                    if (IsMatch(recipes.Skip(recipes.Count - pattern.Length), pattern))
                    {
                        return recipes.Count - pattern.Length;
                    }
                }

                elf1Index = (elf1Index + recipe1 + 1) % recipes.Count();
                elf2Index = (elf2Index + recipe2 + 1) % recipes.Count();
            }
        }

        private static bool IsMatch(IEnumerable<int> recipeScores, string pattern)
        {
            return string.Join("", recipeScores) == pattern;
        }
    }
}
