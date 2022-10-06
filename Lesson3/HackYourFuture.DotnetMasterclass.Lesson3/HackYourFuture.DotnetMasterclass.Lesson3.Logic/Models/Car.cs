namespace HackYourFuture.DotnetMasterclass.Lesson3.Logic.Models
{
    public class Car
    {
        public Car(int id, Brand brand, int priceInEuro, DateTime plannedArrivalDateInGarage, bool isSold)
        {
            Id = id;
            Brand = brand;
            PriceInEuro = priceInEuro;
            PlannedArrivalDateInGarage = plannedArrivalDateInGarage;
            IsSold = isSold;
        }

        public int Id { get; set; }
        public Brand Brand { get; set; }
        public int PriceInEuro { get; set; }
        public DateTime PlannedArrivalDateInGarage { get; set; }
        public bool IsSold { get; set; }
    }

    public enum Brand
    {
        Jaguar,
        Lamborghini,
        Hummer,
        Nissan
    }
}