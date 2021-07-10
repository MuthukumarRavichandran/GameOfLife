using GameOfLife;
using Xunit;

namespace GameOfLifeTests
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [Trait("Category", "Unit")]
    public class HelperTests
    {
       
        [Fact]
        public void GetPopulationPatterns_Sucess()
        {
            //Act
            int[,] SampleSet1 = {
                {0, 0, 0, 0, 0, 0},
                {0, 0, 0, 1, 1, 0},
                {0, 0, 0, 0, 1, 0},
                {0, 0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 0, 0},
                {0, 0, 0, 1, 1, 0}
            };

            var response = SampleSet1.GetPopulationPatterns(6);

            //Assert
            Assert.NotNull(response);
            Assert.Equal(5,response.Count);
        }

        [Fact]
        public void GetPopulationPatterns_Failure()
        {
            //Act
            int[,] SampleSet1 = {
                {0, 0, 0},
                {0, 0, 0},
                {0, 0, 0}
            };

            var response = SampleSet1.GetPopulationPatterns(3);

            //Assert
            Assert.NotNull(response);
            Assert.Empty(response);
        }

        [Fact]
        public void NextGenerationResultSet_Success()
        {
            //Act
            int[,] SampleSet1 = {
                {0, 0, 0, 0, 0, 0},
                {0, 0, 0, 1, 1, 0},
                {0, 0, 0, 0, 1, 0},
                {0, 0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 0, 0},
                {0, 0, 0, 1, 1, 0}
            };

            int[,] expected =
            {
                {0, 0, 0, 0, 0, 0},
                {0, 0, 0, 1, 1, 0},
                {0, 0, 0, 1, 1, 0},
                {0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0}
            };

            var response = SampleSet1.NextGenerationResultSet(6);

            //Assert
            Assert.NotNull(response);
            Assert.Equal(expected, response);
        }
    }
}
