namespace lesson4_exercice.Models
{
    public class Vehicle
    {
        private string _id;
        private int _licence;
        private string _model;
        private User _owner;



        public Vehicle(int licence, string model)
        {
            _id = Guid.NewGuid().ToString();
            Model = model;
            Licence = licence;
        }

        public Vehicle(int licence, string model, User owner)
        {
            _id = Guid.NewGuid().ToString();
            Model = model;
            Owner = owner;
            Licence = licence;
        }

        public string Id { get; set; }
        public int Licence { get; set; }
        public string Model { get; set; }
        public User Owner { get; set; }
    }
}
