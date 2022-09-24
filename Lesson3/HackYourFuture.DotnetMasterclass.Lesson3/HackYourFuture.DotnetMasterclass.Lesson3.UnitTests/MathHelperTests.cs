using HackYourFuture.DotnetMasterclass.Lesson3.Logic.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackYourFuture.DotnetMasterclass.Lesson3.UnitTests
{
    public class MathHelperTests
    {
        [Fact]
        public void GivenListOfInts_WhenCalculatingAverageAndRounding_ThenReturnsInt()
        {
            // Arrange
            var listOfInts = new List<int> { 4, 8 };

            // Act
            var roundedAverage = MathHelper.CalculateAverageAndRoundDownToNearestInt(listOfInts);

            // Assert
            Assert.Equal(6, roundedAverage);
        }

        [Fact]
        public void GivenListOfIntsThatShouldReturnDouble_WhenCalculatingAverageAndRounding_ThenReturnsRoundedDownInt()
        {
            // Arrange
            var listOfInts = new List<int> { 5, 6, 6 }; // The average is 5.6666666666667 but we always round down so the result should be 5

            // Act
            var roundedAverage = MathHelper.CalculateAverageAndRoundDownToNearestInt(listOfInts);

            // Assert
            Assert.Equal(5, roundedAverage);
        }
    }
}
