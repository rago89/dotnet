using HackYourFuture.DotnetMasterclass.Lesson3.Logic.Models;

namespace HackYourFuture.DotnetMasterclass.Lesson3.Logic.Services.Interfaces
{
    public interface ICarService
    {
        List<Car> SearchCars(Brand brand, int priceShouldBeLowerThanAmountInEuro, DateTime arrivingBefore);
        List<Car> UpdateStock(List<Car> carsToDelete, List<Car> carsToAdd);
    }
}