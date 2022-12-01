using System.Linq;

namespace AdventOfCode._2018
{
    public class Day11
    {
        public static (int x, int y) Task1(int gridSerialNumber)
        {
            var fuelCells = CalcualteFuelCells(gridSerialNumber);
            var summedAreaTable = CalculateSummedAreaTable(fuelCells);

            var (x, y, value) = CalculateHighestValue(summedAreaTable, 3);
            return (x, y);
        }

        public static (int x, int y, int size) Task2(int gridSerialNumber)
        {
            var fuelCells = CalcualteFuelCells(gridSerialNumber);
            var summedAreaTable = CalculateSummedAreaTable(fuelCells);

            return CalculateHighestValue(summedAreaTable);
        }

        private static (int x, int y, int size) CalculateHighestValue(int[,] summedAreaTable)
        {
            var highestValue = int.MinValue;
            var topLeftCorner = (x: 0, y: 0);
            var bestSize = 0;
            foreach (var size in Enumerable.Range(1, 300))
            {
                var (x, y, value) = CalculateHighestValue(summedAreaTable, size);

                if (value > highestValue)
                {
                    highestValue = value;
                    topLeftCorner = (x, y);
                    bestSize = size;
                }
            }

            return (topLeftCorner.x, topLeftCorner.y, bestSize);
        }

        private static (int x, int y, int value) CalculateHighestValue(int[,] summedAreaTable, int size)
        {
            var highestValue = int.MinValue;
            var topLeftCorner = (x: 0, y: 0);

            foreach (var x in Enumerable.Range(-1, summedAreaTable.GetLength(1) - size + 1))
            {
                foreach (var y in Enumerable.Range(-1, summedAreaTable.GetLength(0) - size + 1))
                {
                    int value;
                    if (x == -1 && y == -1)
                    {
                        value = summedAreaTable[y + size, x + size];
                    }
                    else if (x == -1)
                    {
                        value = summedAreaTable[y + size, x + size] - summedAreaTable[y, x + size];
                    }
                    else if (y == -1)
                    {
                        value = summedAreaTable[y + size, x + size] - summedAreaTable[y + size, x];
                    }
                    else
                    {
                        value = summedAreaTable[y, x] + summedAreaTable[y + size, x + size] - summedAreaTable[y, x + size] - summedAreaTable[y + size, x];
                    }

                    if (value > highestValue)
                    {
                        highestValue = value;
                        topLeftCorner = (x + 2, y + 2);
                    }
                }
            }

            return (topLeftCorner.x, topLeftCorner.y, highestValue);
        }

        private static int[,] CalcualteFuelCells(int gridSerialNumber)
        {
            var fuelCells = new int[300, 300];
            foreach (var x in Enumerable.Range(0, fuelCells.GetLength(1)))
            {
                foreach (var y in Enumerable.Range(0, fuelCells.GetLength(0)))
                {
                    var rackId = x + 1 + 10;
                    var powerLevel = rackId * (y + 1);
                    powerLevel += gridSerialNumber;
                    powerLevel *= rackId;
                    powerLevel /= 100;
                    powerLevel %= 10;
                    powerLevel -= 5;

                    fuelCells[y, x] = powerLevel;
                }
            }

            return fuelCells;
        }

        private static int[,] CalculateSummedAreaTable(int[,] grid)
        {
            var summedAreaTable = new int[grid.GetLength(0), grid.GetLength(1)];
            foreach (var x in Enumerable.Range(0, grid.GetLength(1)))
            {
                foreach (var y in Enumerable.Range(0, grid.GetLength(0)))
                {
                    if (x == 0 && y == 0)
                    {
                        summedAreaTable[y, x] = grid[y, x];
                    }
                    else if (x == 0)
                    {
                        summedAreaTable[y, x] = grid[y, x] + summedAreaTable[y - 1, x];
                    }                    
                    else if (y == 0)
                    {
                        summedAreaTable[y, x] = grid[y, x] + summedAreaTable[y, x - 1];
                    }
                    else
                    {
                        summedAreaTable[y, x] = grid[y, x] + summedAreaTable[y - 1, x] + summedAreaTable[y, x - 1] - summedAreaTable[y - 1, x - 1];
                    }
                }
            }

            return summedAreaTable;
        }
    }
}
