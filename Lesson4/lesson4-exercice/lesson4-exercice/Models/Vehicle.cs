namespace lesson4_exercice.Models
{
    public class Vehicle
    {
        private string _id = String.Empty;
        private int _licence;
        private string _model = String.Empty;
        private User? _owner;

        public Vehicle() { }

        public Vehicle(int licence, string model, User owner)
        {
            _id = Guid.NewGuid().ToString();
            Model = model;
            Owner = owner;
            Licence = licence;
        }

        public string Id { get => _id; }
        public int Licence { get => _licence; set => _licence = value; }
        public string Model { get => _model; set => _model = value; }
        public User? Owner { get => _owner; set => _owner = value; }
    }
}
