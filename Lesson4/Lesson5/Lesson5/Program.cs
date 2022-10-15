namespace Lesson5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");




        }
    }

    class Car : IVehicle
    {
        public int MaxSpeed { get; set; }

        public int GerMaxSpeed()
        {
            throw new NotImplementedException();
        }
    }

    class Airplane { }

    class Bike { }

    interface IVehicle
    {
        int MaxSpeed { get; set; }
        int GerMaxSpeed();
    }
}