namespace Lokf.AdventOfCode2022;

public static partial class Day12
{
    public static int Task1(IEnumerable<string> lines)
    {
        var (grid, start, end) = Parse(lines.ToArray());
        return CalculateShortestPath(grid, start, end);
    }

    public static int Task2(IEnumerable<string> lines)
    {
        var (grid, _, end) = Parse(lines.ToArray());

        var min = int.MaxValue;

        foreach (var row in Enumerable.Range(0, grid.GetLength(0)))
        {
            foreach (var column in Enumerable.Range(0, grid.GetLength(1)))
            {
                if (grid[row, column] != 'a')
                {
                    continue;
                }

                var shortestPath = CalculateShortestPath(grid, (row, column), end);
                if (shortestPath < min && shortestPath > 0)
                {
                    min = shortestPath;
                }
            }
        }

        return min;
    }

    private static (char[,] Grid, (int, int) Start, (int, int) End) Parse(string[] lines)
    {
        var grid = new char[lines.Length, lines[0].Length];
        var start = (0, 0);
        var end = (0, 0);
        var row = 0;
        foreach (var line in lines)
        {
            var column = 0;
            foreach (var square in line)
            {
                if (square == 'S')
                {
                    start = (row, column);
                    grid[row, column] = 'a';
                }
                else if (square == 'E')
                {
                    end = (row, column);
                    grid[row, column] = 'z';
                }
                else
                {
                    grid[row, column] = square;
                }

                column++;
            }
            row++;
        }

        return (grid, start, end);
    }

    private static int CalculateShortestPath(char[,] grid, (int, int) start, (int, int) end)
    {
        var requiredNumberOfSteps = new int[grid.GetLength(0), grid.GetLength(1)];
        CalculateRequiredNumberOfSteps(grid, start, end, requiredNumberOfSteps, 0);
        return requiredNumberOfSteps[end.Item1, end.Item2];
    }

    private static void CalculateRequiredNumberOfSteps(char[,] grid, (int, int) position, (int, int) end, int[,] requiredNumberOfSteps, int numberOfSteps)
    {
        var value = requiredNumberOfSteps[position.Item1, position.Item2];
        if (numberOfSteps >= value && value > 0)
        {
            return;
        }

        requiredNumberOfSteps[position.Item1, position.Item2] = numberOfSteps;

        // Go up.
        if (position.Item1 > 0)
        {
            var next = (position.Item1 - 1, position.Item2);
            if (grid[position.Item1, position.Item2] + 1 >= grid[next.Item1, next.Item2])
            {
                CalculateRequiredNumberOfSteps(grid, next, end, requiredNumberOfSteps, numberOfSteps + 1);
            }
        }

        // Go down.
        if (position.Item1 < grid.GetLength(0) - 1)
        {
            var next = (position.Item1 + 1, position.Item2);
            if (grid[position.Item1, position.Item2] + 1 >= grid[next.Item1, next.Item2])
            {
                CalculateRequiredNumberOfSteps(grid, next, end, requiredNumberOfSteps, numberOfSteps + 1);
            }
        }

        // Go left.
        if (position.Item2 > 0)
        {
            var next = (position.Item1, position.Item2 - 1);
            if (grid[position.Item1, position.Item2] + 1 >= grid[next.Item1, next.Item2])
            {
                CalculateRequiredNumberOfSteps(grid, next, end, requiredNumberOfSteps, numberOfSteps + 1);
            }
        }

        // Go right.
        if (position.Item2 < grid.GetLength(1) - 1)
        {
            var next = (position.Item1, position.Item2 + 1);
            if (grid[position.Item1, position.Item2] + 1 >= grid[next.Item1, next.Item2])
            {
                CalculateRequiredNumberOfSteps(grid, next, end, requiredNumberOfSteps, numberOfSteps + 1);
            }
        }
    }
}
