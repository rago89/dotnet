namespace HackYourFuture.DotnetMasterclass.Lesson3.Generics
{
    // Documentation https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/generics
    
    public class Thing
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }

    public class GenericClassExample<T>
    {
        public void ExampleMethod(T value)
        {

        }

        public List<T> ExampleList;
    }

    public class ImplementationExample
    {
        public void ImplementationMethod()
        {
            var genericEampleWithInt = new GenericClassExample<int>();
            genericEampleWithInt.ExampleMethod(123);

            var genericEampleWuthDouble = new GenericClassExample<double>();
            genericEampleWuthDouble.ExampleMethod(123.456);

            var genericEampleWuthString = new GenericClassExample<string>();
            genericEampleWuthString.ExampleMethod("azerty");

            var genericExampleWithClass = new GenericClassExample<Thing>();
            genericExampleWithClass.ExampleMethod(new Thing());
        }
    }
}
