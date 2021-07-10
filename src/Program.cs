using System;
using System.Linq;
using Newtonsoft.Json;

namespace GameOfLife
{
    /// <summary>
    /// Class for GameOfLife
    /// </summary>
    public class Program : InputFeed
    {
        /// <summary>
        /// Main method
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            // Displaying the grid
            Console.WriteLine("Original population set");
            SampleSet1.PrintGridData(GridSize);

            var future = NthGenerationResultSet(NthGenerationValue, SampleSet1, GridSize);
            Console.WriteLine("Future population set");
            future.PrintGridData(GridSize);

            var result = future.GetPopulationPatterns(GridSize);

           if(result.Any())
               Console.WriteLine(JsonConvert.SerializeObject(result));


            Console.ReadKey();
        }

        /// <summary>
        /// NthGenerationResultSet
        /// </summary>
        /// <param name="generation"></param>
        /// <param name="grid"></param>
        /// <param name="gridSize"></param>
        /// <returns></returns>
        private static int[,] NthGenerationResultSet(int generation, int[,] grid, int gridSize)
        {
            int[,] future = grid;
            for (int i = 0; i <= generation; i++)
            {
                future = future.NextGenerationResultSet(gridSize);
            }

            return future;
        }
    }

}
