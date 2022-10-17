// See https://aka.ms/new-console-template for more information

using System.Diagnostics;

try
{
    ICalculator calculator;
    List<IShape> shapes = new List<IShape>();

    Console.WriteLine("How many triangles?");
    if (int.TryParse(Console.ReadLine(), out int amountTriangles))
    {
        for (int i = 0; i < amountTriangles; i++)
        {
            shapes.Add(new Triangle($"Triangle_{i + 1}"));
        }
    }

    Console.WriteLine("How many squares?");
    if (int.TryParse(Console.ReadLine(), out int amountSquares))
    {
        for (int i = 0; i < amountSquares; i++)
        {
            shapes.Add(new Square($"Square_{i + 1}"));
        }
    }

    Console.WriteLine("How many circles?");
    if (int.TryParse(Console.ReadLine(), out int amountCircles))
    {
        for (int i = 0; i < amountCircles; i++)
        {
            shapes.Add(new Circle($"Circle_{i + 1}"));
        }
    }

    foreach (var shape in shapes)
    {
        shape.AskParameters();
    }

    Console.WriteLine("Which calculator do you want to use?");
    Console.WriteLine("1: Calculator using Square Meter");
    Console.WriteLine("2: Calculator using Square Feet");
    var choice = Int32.Parse(Console.ReadLine());
    switch (choice)
    {
        case 1:
            calculator = new CalcSqMeter();
            break;
        case 2:
            calculator = new CalculatorSqFeet();
            break;
        default:
            throw new Exception("Invalid choice of calculator");
    }

    CalculatorPrinter calcPrinter = new CalculatorPrinter(calculator, shapes);
    calcPrinter.PrintResult();
}
catch (Exception e)
{
    Console.WriteLine($"Something went wrong: {e.Message}");
}





interface IShape
{
    string Name { get; }
    void AskParameters();
    double CalculateSurfaceArea();
}

class Triangle: IShape
{
    private double _height;
    private double _width;
    public double CalculateSurfaceArea()
    {
        return _height * _width / 2;
    }

    public Triangle(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public void AskParameters()
    {
        Console.WriteLine($"Parameters of {Name} in cm");
        Console.Write("Height: ");
        double.TryParse(Console.ReadLine(), out _height);
        Console.Write("Width: ");
        double.TryParse(Console.ReadLine(), out _width);
    }
}

class Circle : IShape
{
    private double _radius;
    public double CalculateSurfaceArea()
    {
        return Math.Pow(_radius, 2) * Math.PI;
    }

    public Circle(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public void AskParameters()
    {
        Console.WriteLine($"Parameters of {Name} in cm");
        Console.Write("Radius: ");
        double.TryParse(Console.ReadLine(), out _radius);
    }
}

class Square: IShape
{
    private double _height;
    public double CalculateSurfaceArea()
    {
        return Math.Pow(_height, 2);
    }

    public Square(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public void AskParameters()
    {
        Console.WriteLine($"Parameters of {Name} in cm");
        Console.Write("Height: ");
        double.TryParse(Console.ReadLine(), out _height);
    }
}

interface ICalculator
{
    string Unit { get; }
    double CalculateSurfaceArea(List<IShape> shapes);
}

class CalculatorSqFeet: ICalculator
{
    public string Unit { get; } = "square feet";

    public double CalculateSurfaceArea(List<IShape> shapes)
    {
        double result = 0;
        ;
        foreach (var shape in shapes)
        {
            result += shape.CalculateSurfaceArea();
        }
        return result * 0.00107639;
    }
}

class CalcSqMeter: ICalculator
{
    public string Unit { get; } = "square meter";

    public double CalculateSurfaceArea(List<IShape> shapes)
    {
        double result = 0;
        ;
        foreach (var shape in shapes)
        {
            result += shape.CalculateSurfaceArea();
        }

        return result / 10000;
    }
}

class CalculatorPrinter
{
    private readonly ICalculator _calculator;
    private readonly List<IShape> _shapes;
    public CalculatorPrinter(ICalculator calculator, List<IShape> shapes)
    {
        _shapes = shapes;
        _calculator = calculator;
    }
    public void PrintResult()
    {
        Console.WriteLine($"The total result is {_calculator.CalculateSurfaceArea(_shapes)} {_calculator.Unit}");
    }
}
