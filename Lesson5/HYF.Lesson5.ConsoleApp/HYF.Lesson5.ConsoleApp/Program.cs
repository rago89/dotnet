// See https://aka.ms/new-console-template for more information

using HYF.Lesson5.ClassLibrary.Models;
using HYF.Lesson5.ClassLibrary.Services;

Console.WriteLine("Hello, World!");

var bpost = new BPost();
var fedex = new FedexService();

var webshop = new WebShop(fedex);

var product = new Product();
product.Price = 0.5;

var person = new Person();
person.BankAccountNumber = "BE11 1111 1111 1111";
person.Address = "Kerkhofstraat 1 2850 Boom";

var masterCard = new MasterCardService();
var paypall = new PayPallService();

webshop.OrderItem(product, person, masterCard);
webshop.OrderItem(product, person, paypall);


//List <IFueledVehicle> fueledVehicles = new List<IFueledVehicle>();
//List<IVehicle> vehicles = new List<IVehicle>();

//var bike = new Bike() {MaxSpeed = 5};
//vehicles.Add(bike);

//var airplane = new Airplane() {MaxSpeed = 200};
//vehicles.Add(airplane);

//foreach (var fueledVehicle in fueledVehicles)
//{
//    Console.WriteLine($"This is a fueled vehicle with a carbonFootprint of {fueledVehicle.GetCarbonFootprint()}");
//}

//foreach (var vehicle in vehicles)
//{
//    if (vehicle is IFueledVehicle)
//    {
//        Console.WriteLine($"This is a fueled vehicle with a carbonFootprint of {(vehicle as IFueledVehicle).GetCarbonFootprint()}");
//    }
//}



class Car : IVehicle, IFueledVehicle
{
    public int MaxSpeed { get; set; }
    public int GetMaxSpeed()
    {
        return MaxSpeed;
    }

    public int PassengerSeats { get; set; }
    public int GetCarbonFootprint()
    {
        throw new NotImplementedException();
    }
}

class Airplane: IVehicle, IFueledVehicle
{
    public int MaxSpeed { get; set; }
    public int GetMaxSpeed()
    {
        throw new NotImplementedException();
    }

    public int PassengerSeats { get; set; }
    public int GetCarbonFootprint()
    {
        throw new NotImplementedException();
    }
}

class Bike: IVehicle
{
    public int MaxSpeed { get; set; }
    public int GetMaxSpeed()
    {
        throw new NotImplementedException();
    }
}

interface IVehicle
{
    int MaxSpeed { get; set; }
    int GetMaxSpeed();
}

interface IFueledVehicle
{
    int GetCarbonFootprint();
}
