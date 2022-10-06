using HackYourFuture.DotnetMasterclass.Lesson3.Logic.Models;

namespace HackYourFuture.DotnetMasterclass.Lesson3.Logic.DataAccess.Interfaces
{
    public interface ICarDatabase
    {
        List<Car> GetCars();
        void AddNewCar(Car car);
        void DeleteCar(Car car);
    }
}