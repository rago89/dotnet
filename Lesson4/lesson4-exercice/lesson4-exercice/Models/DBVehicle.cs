namespace lesson4_exercice.Models
{
    public class DBVehicle
    {
        public DBVehicle()
        {
            Vehicles = new List<Vehicle>();
        }
        public List<Vehicle> Vehicles { get; set; }
    }
}
