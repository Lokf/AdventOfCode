namespace Lokf.AdventOfCode2022;

public static partial class Day08
{
    public static int Task1(IEnumerable<string> lines)
    {
        var grid = Parse(lines.ToArray());

        return CalculateNumberOfVisibleTrees(grid);
    }

    public static int Task2(IEnumerable<string> lines)
    {
        var grid = Parse(lines.ToArray());

        return CalculateMaximimScenicScore(grid);
    }

    private static int[,] Parse(IReadOnlyCollection<string> lines)
    {
        var numberOfRows = lines.Count;
        var numberOfColumns = lines.First().Length;

        var grid = new int[numberOfRows, numberOfColumns];

        var row = 0;
        foreach (var line in lines)
        {
            var column = 0;
            foreach (var tree in line)
            {
                grid[row, column] = tree - '0';
                column++;
            }
            row++;
        }

        return grid;
    }

    private static int CalculateNumberOfVisibleTrees(int[,] grid)
    {
        var count = 0;
        var isVisible = CalculateVisibily(grid);
        foreach (var cell in isVisible)
        {
            if (cell)
            {
                count++;
            }
        }

        return count;
    }

    private static bool[,] CalculateVisibily(int[,] grid)
    {
        int numberOfRows = grid.GetLength(0);
        int numberOfColumns = grid.GetLength(1);

        var isVisible = new bool[numberOfRows, numberOfColumns];

        // Look down.
        foreach (var column in Enumerable.Range(0, numberOfColumns))
        {
            var maxSeen = -1;
            foreach (var row in Enumerable.Range(0, numberOfRows))
            {
                if (grid[row, column] > maxSeen)
                {
                    isVisible[row, column] = true;
                    maxSeen = grid[row, column];
                }
            }
        }

        // Look up.
        foreach (var column in Enumerable.Range(0, numberOfColumns))
        {
            var maxSeen = -1;
            foreach (var row in Enumerable.Range(0, numberOfRows).Reverse())
            {
                if (grid[row, column] > maxSeen)
                {
                    isVisible[row, column] = true;
                    maxSeen = grid[row, column];
                }
            }
        }

        // Look right.
        foreach (var row in Enumerable.Range(0, numberOfRows))
        {
            var maxSeen = -1;
            foreach (var column in Enumerable.Range(0, numberOfColumns))
            {
                if (grid[row, column] > maxSeen)
                {
                    isVisible[row, column] = true;
                    maxSeen = grid[row, column];
                }
            }
        }

        // Look left.
        foreach (var row in Enumerable.Range(0, numberOfRows))
        {
            var maxSeen = -1;
            foreach (var column in Enumerable.Range(0, numberOfColumns).Reverse())
            {
                if (grid[row, column] > maxSeen)
                {
                    isVisible[row, column] = true;
                    maxSeen = grid[row, column];
                }
            }
        }

        return isVisible;
    }

    private static int CalculateMaximimScenicScore(int[,] grid)
    {
        int numberOfRows = grid.GetLength(0);
        int numberOfColumns = grid.GetLength(1);

        var max = 0;
        foreach (var row in Enumerable.Range(0, numberOfRows))
        {
            foreach (var column in Enumerable.Range(0, numberOfColumns))
            {
                var score = CalculateScenicScrore(grid, row, column, numberOfRows, numberOfColumns);
                if (score > max)
                {
                    max = score;
                }
            }
        }

        return max;
    }

    private static int CalculateScenicScrore(int[,] grid, int row, int column, int numberOfRows, int numberOfColumns)
    {
        var height = grid[row, column];

        // Look down.
        var scoreDown = 0;
        foreach (var r in Enumerable.Range(row + 1, numberOfRows - (row +1)))
        {
            scoreDown++;
            if (grid[r, column] >= height)
            {
                break;
            }
        }

        // Look up.
        var scoreUp = 0;
        foreach (var r in Enumerable.Range(0, row).Reverse())
        {
            scoreUp++;
            if (grid[r, column] >= height)
            {
                break;
            }
        }

        // Look right.
        var scoreRight = 0;
        foreach (var c in Enumerable.Range(column + 1, numberOfColumns - (column + 1)))
        {
            scoreRight++;
            if (grid[row, c] >= height)
            {
                break;
            }
        }

        // Look left.
        var scoreLeft = 0;
        foreach (var c in Enumerable.Range(0, column).Reverse())
        {
            scoreLeft++;
            if (grid[row, c] >= height)
            {
                break;
            }
        }

        return scoreDown * scoreUp * scoreRight * scoreLeft;
    }
}
