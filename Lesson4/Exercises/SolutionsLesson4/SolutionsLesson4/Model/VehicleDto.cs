namespace SolutionsLesson4.Model
{
    public class VehicleDto
    {
        public string LicensePlate { get; set; }
        public string Model { get; set; }

        public Vehicle FromDto()
        {
            return new Vehicle(LicensePlate, Model);
        }
    }
}
