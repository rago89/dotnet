using HackYourFuture.DotnetMasterclass.Lesson3.Logic.DataAccess.Interfaces;
using HackYourFuture.DotnetMasterclass.Lesson3.Logic.Models;

namespace HackYourFuture.DotnetMasterclass.Lesson3.Logic
{
    public class CarDatabase : ICarDatabase
    {
        private List<Car> _cars;

        public CarDatabase()
        {
            _cars = new List<Car>
            {
                new Car(1, Brand.Jaguar, 100_000, new DateTime(2023, 6, 5), false),
                new Car(2, Brand.Jaguar, 150_000, new DateTime(2022, 10, 3), true),
                new Car(3, Brand.Lamborghini, 200_000, new DateTime(2023, 10, 1), true),
                new Car(4, Brand.Lamborghini, 300_000, new DateTime(2022, 10, 1), false),
                new Car(5, Brand.Hummer, 200_000, new DateTime(2022, 10, 17), false),
                new Car(6, Brand.Hummer, 300_000, new DateTime(2023, 9, 16), false),
                new Car(7, Brand.Hummer, 150_000, new DateTime(2022, 10, 15), true),
                new Car(8, Brand.Nissan, 60_000, new DateTime(2022, 3, 6), false),
                new Car(9, Brand.Nissan, 100_000, new DateTime(2023, 5, 1), true),
                new Car(10, Brand.Nissan, 140_000, new DateTime(2022, 10, 1), false),
                new Car(11, Brand.Nissan, 102_000, new DateTime(2022, 5, 8), false),
                new Car(12, Brand.Nissan, 100_999, new DateTime(2023, 10, 25), true),
                new Car(13, Brand.Nissan, 500_000, new DateTime(2022, 10, 1), true),
                new Car(14, Brand.Nissan, 10_000, new DateTime(2022, 10, 22), false),
            };
        }

        public List<Car> GetCars()
        {
            return _cars;
        }

        public void AddNewCar(Car car)
        {
            _cars.Add(car);
        }

        public void DeleteCar(Car car)
        {
            _cars.Remove(car);
        }
    }
}