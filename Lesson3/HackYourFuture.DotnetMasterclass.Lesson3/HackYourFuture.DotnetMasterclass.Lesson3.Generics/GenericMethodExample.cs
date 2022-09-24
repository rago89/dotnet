using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace HackYourFuture.DotnetMasterclass.Lesson3.Generics
{
    public class GenericMethodExample
    {
        // Write a method that prints the type of the gen
        public static void Print<T>(T value)
        {
            Console.WriteLine(value);
        }
    }

    public class GenericMethodExecutor
    {
        public static void Execute()
        {
            GenericMethodExample.Print(777);

            GenericMethodExample.Print("test");

            GenericMethodExample.Print(new GenericMethodExecutor());
        }
    }
}
