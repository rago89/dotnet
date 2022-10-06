using HackYourFuture.DotnetMasterclass.Lesson3.Logic.Services.Interfaces;
using HackYourFuture.DotnetMasterclass.Lesson3.Logic.Models;
using HackYourFuture.DotnetMasterclass.Lesson3.Logic.DataAccess.Interfaces;

namespace HackYourFuture.DotnetMasterclass.Lesson3.Logic.Services
{
    public class CarService : ICarService
    {
        private readonly ICarDatabase _carDatabase;

        public CarService(ICarDatabase carDatabase)
        {
            _carDatabase = carDatabase;
        }

        public List<Car> SearchCars(Brand brand, int customerBudget, DateTime arrivingBefore)
        {
            var allCars = _carDatabase.GetCars();

            var filteredCars = allCars.Where(x => x.Brand == brand && x.PriceInEuro < customerBudget && x.PlannedArrivalDateInGarage < arrivingBefore);

            return filteredCars.ToList();
        }

        public int CalculateTotalPriceOfAllCarsInStock()
        {
            var allCars = _carDatabase.GetCars();

            if (allCars == null || allCars.Count == 0)
                return 0;

            return allCars.Select(x => x.PriceInEuro).Sum();
        }

        public List<Car> UpdateStock(List<Car> carsToDelete, List<Car> carsToAdd)
        {
            foreach (var carToDelete in carsToDelete)
            {
                _carDatabase.DeleteCar(carToDelete);
            }

            foreach (var carToAdd in carsToAdd)
            {
                _carDatabase.AddNewCar(carToAdd);
            }

            return _carDatabase.GetCars();
        }
    }
}
