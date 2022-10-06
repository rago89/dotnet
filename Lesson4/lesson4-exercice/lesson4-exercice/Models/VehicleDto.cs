namespace lesson4_exercice.Models
{
    public class VehicleDto
    {
        public VehicleDto(string id, int license, string model)
        {
            Id = id;
            Licence = license;
            Model = model;
        }
        public string Id { get; set; }
        public int Licence { get; set; }
        public string Model { get; set; }
    }

}
