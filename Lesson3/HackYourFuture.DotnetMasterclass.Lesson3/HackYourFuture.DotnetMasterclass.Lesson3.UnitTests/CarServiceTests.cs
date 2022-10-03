using HackYourFuture.DotnetMasterclass.Lesson3.Logic.DataAccess.Interfaces;
using HackYourFuture.DotnetMasterclass.Lesson3.Logic.Models;
using HackYourFuture.DotnetMasterclass.Lesson3.Logic.Services;
using Moq;

namespace HackYourFuture.DotnetMasterclass.Lesson3.UnitTests
{
    public class CarServiceTests
    {


        [Fact]
        public void GivenSearchTerms_WhenSearchingForACar_ThenReturnApplicableCars()
        {
            // Arrange
            var carDatabaseMock = new Mock<ICarDatabase>();
            var carService = new CarService(carDatabaseMock.Object);

            carDatabaseMock.Setup(x => x.GetCars()).Returns(new List<Car>
            {
                new Car(3, Brand.Lamborghini, 200_000, new DateTime(2023, 10, 1), true),
                new Car(4, Brand.Lamborghini, 300_000, new DateTime(2022, 10, 1), false),
            });

            // Act
            var foundCars = carService.SearchCars(Brand.Lamborghini, 500_000, new DateTime(2023, 10, 17));

            // Assert
            Assert.True(foundCars.Any());
        }

        [Fact]
        public void GivenSearchTerms_WhenSearchingForACar_ThenReturnNoCars()
        {
            // Arrange
            var carDatabaseMock = new Mock<ICarDatabase>();
            var carService = new CarService(carDatabaseMock.Object);

            carDatabaseMock.Setup(x => x.GetCars()).Returns(new List<Car>
            {
                new Car(3, Brand.Lamborghini, 200_000, new DateTime(2023, 10, 1), true),
                new Car(4, Brand.Lamborghini, 300_000, new DateTime(2022, 10, 1), false),
            });

            // Act
            var foundCars = carService.SearchCars(Brand.Lamborghini, 20_000, new DateTime(2023, 10, 17));

            // Assert
            Assert.False(foundCars.Any());

        }


        // Exercise 1: Write a unit test that tests the method CarService.CalculateTotalPriceOfAllCarsInStock
        [Fact]
        public void GivenStockOfCars_WhenCalculatingTotalPrice_ReturnTotalPrice()
        {
            // Arrange

            // Act

            // Assert
        }




        // Exercise 2: Write a unit test for the method CarService.UpdateStock



    }
}