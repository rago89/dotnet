namespace HackYourFuture.DotnetMasterclass.Lesson2.SharedClasses;

// public = can be used from other assemblies
// internal (or no access modifier) = can only be used in this assembly
public class Vehicle
{
    public static int NumberOfVehiclesCreated = 0;
    /// <summary>
    /// Creates a new <see cref="Vehicle"/>.
    /// </summary>
    /// <paramref name="vehicleName">The nickname for this vehicle.</paramref>
    public Vehicle(string vehicleName)
    {
        NumberOfVehiclesCreated++;
        SetNewVehicleName(vehicleName);
    }

    public Vehicle() : this(string.Empty)
    {
        
    }

    // Properties can have private setters
    public string Name { get; private set; }

    // Protected members can only be called from this class and inheriting classes
    protected void SetNewVehicleName(string newVehicleName)
    {
        // Run some validations first
        Name = newVehicleName;
    }

    public static string GetName()
    {
        // You can never access object members in a static member
        // return Name;

        return string.Empty;
    }
}

public class Car : Vehicle
{
    private const string VehicleType = "Car"; // This is the same for all cars

    // I can change this from the constructor, but not after
    private readonly int NumberOfWheels = 4; // default = 4

    public string Brand { get; set; }
    public Car(string name, string brand, int numberOfWheels)
    :base(name)
    {
        Brand = brand;
        NumberOfWheels = numberOfWheels;
        // Const is locked by the compiler, so this cannot change
        // VehicleType = "Hannes";
    }

    public void SetNumberOfWheels(int numberOfWheels)
    {
        // This does not work for readonly fields
        // NumberOfWheels = numberOfWheels;
    }
}
