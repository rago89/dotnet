namespace SolutionsLesson4.Model
{
    public class Vehicle
    {
        public Vehicle(string licensePlate, string model, User? user = null)
        {
            LicensePlate = licensePlate;
            Model = model;
            Owner = user;
        }

        public string LicensePlate { get; set; }
        public string Model { get; set; }
        public User? Owner { get; set; }
    }
}
