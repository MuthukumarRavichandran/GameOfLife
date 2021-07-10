using System;
using System.Collections.Generic;

namespace GameOfLife
{
    /// <summary>
    /// Helper
    /// </summary>
    public static class Helper
    {
        /// <summary>
        /// Print the Grid Data
        /// </summary>
        /// <param name="populationSet"></param>
        /// <param name="gridSize"></param>
        public static void PrintGridData(this int[,] populationSet, int gridSize)
        {
            for (int row = 0; row < gridSize; row++)
            {
                for (int col = 0; col < gridSize; col++)
                {
                    if (populationSet[row, col] == 0)
                        Console.Write("Dead, ");
                    else
                        Console.Write("Alive, ");
                }
                Console.WriteLine();
            }

        }

        /// <summary>
        /// Get the population pattern data
        /// </summary>
        /// <param name="futurePopulationGrid"></param>
        /// <param name="gridSize"></param>
        /// <returns></returns>
        public static List<PopulationPattern> GetPopulationPatterns(this int[,] futurePopulationGrid, int gridSize)
        {
            var populationPattern = new List<PopulationPattern>();

            for (int row = 0; row < gridSize; row++)
            {
                for (int col = 0; col < gridSize; col++)
                {
                    if (futurePopulationGrid[row, col] != 0)
                    {
                        populationPattern.Add(new PopulationPattern
                        {
                            Row = row + 1,
                            Column = col + 1
                        });
                    }

                }
            }

            return populationPattern;
        }

        /// <summary>
        /// NextGeneration
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="gridSize"></param>
        /// <returns>Returns the next Generation sets</returns>
        public static int[,] NextGenerationResultSet(this int[,] grid, int gridSize)
        {
            var populationSet = new int[gridSize, gridSize];

            for (int row = 1; row < gridSize - 1; row++)
            {
                for (int col = 1; col < gridSize - 1; col++)
                {

                    var aliveNeighborsCount = GetAliveNeighborsCount(grid, row, col);
                    aliveNeighborsCount -= grid[row, col];

                    // Implementing the Rules of Life
                    // Cell is lonely and dies
                    if ((grid[row, col] == 1) &&
                        (aliveNeighborsCount < 2))
                        populationSet[row, col] = 0;

                    // Cell dies due to over population
                    else if ((grid[row, col] == 1) &&
                             (aliveNeighborsCount > 3))
                        populationSet[row, col] = 0;

                    // A new cell is born
                    else if ((grid[row, col] == 0) &&
                             (aliveNeighborsCount == 3))
                        populationSet[row, col] = 1;

                    // Remains the same
                    else
                        populationSet[row, col] = grid[row, col];
                }
            }

            return populationSet;
        }

        /// <summary>
        /// GetAliveNeighborsCount
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        private static int GetAliveNeighborsCount(int[,] grid, int row, int column)
        {
            var aliveNeighbors = 0;
            for (int i = -1; i <= 1; i++)
            for (int j = -1; j <= 1; j++)
                aliveNeighbors +=
                    grid[row + i, column + j];

            return aliveNeighbors;

        }
    }
}
