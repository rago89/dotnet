// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

string importantVariable;
try
{
    // Try to instantiate importantVariable
    importantVariable = "Hannes";

    var number1 = 20;
    var number2 = 0;

    var division = number1 / number2;
}
catch (DivideByZeroException e)
{
    Console.WriteLine("You tried to divide by zero, fool!");
}
catch (ArithmeticException e)
{
    Console.WriteLine($"You made an arithmetic error: {e.Message}");
}
catch (Exception e)
{
    Console.WriteLine($"Something else went wrong: {e.Message}");
}
finally
{
    // This block ALWAYS executes, even after an Exception
    // Cleanup stuff here
    importantVariable = null;
}

// With IDisposable, these 2 things are equivalent:
ImportantThing variable1 = null;
try
{
    variable1 = new ImportantThing(); // this might fail

    // Do other stuff with variable 1
}
finally
{
    // Cleanup
    if (variable1 != null)
    {
        variable1.Dispose();
    }
}

using (var variable2 = new ImportantThing())
{
    // Do other stuff with variable 2
}
// Dispose is automatically called at the end of the using block

class ImportantThing : IDisposable
{
    public void Dispose()
    {
        // Cleans up any resources
    }
}