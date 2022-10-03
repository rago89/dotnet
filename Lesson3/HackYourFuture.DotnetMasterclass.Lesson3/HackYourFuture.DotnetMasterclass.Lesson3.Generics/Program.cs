using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace HackYourFuture.DotnetMasterclass.Lesson3.Generics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Knowing the data structure type at run time is faster:

            //generic list
            List<int> ListGeneric = new List<int> { 5, 9, 1, 4 };
            //non-generic list
            ArrayList ListNonGeneric = new ArrayList { 5, 9, 1, 4 };
            // timer for generic list sort
            Stopwatch s = Stopwatch.StartNew();
            ListGeneric.Sort();
            s.Stop();
            Console.WriteLine($"Generic Sort: {ListGeneric}  \n Time taken: {s.Elapsed.TotalMilliseconds}ms");

            //timer for non-generic list sort
            Stopwatch s2 = Stopwatch.StartNew();
            ListNonGeneric.Sort();
            s2.Stop();
            Console.WriteLine($"Non-Generic Sort: {ListNonGeneric}  \n Time taken: {s2.Elapsed.TotalMilliseconds}ms");
            Console.ReadLine();




            // Some built in .NET Collections use generics to make the collection flexible to use

            var ints = new List<int>();
            var strings = new List<string>();

            var ints2 = new Dictionary<int, string>();



            // Call Generic Method
            GenericMethodExecutor.Execute();
            Console.ReadLine();

            var myTest = new Exercise1<int, int>();
            myTest.Print(10, 20);
        }
    }

    public class ComparableCollection<TFirst, TSecond>
        where TFirst : struct,
          IComparable,
          IComparable<TFirst>,
          IConvertible,
          IEquatable<TFirst>,
          IFormattable
        where TSecond : struct,
          IComparable,
          IComparable<TSecond>,
          IConvertible,
          IEquatable<TSecond>,
          IFormattable
    {
        public TFirst First { get; set; }
        public TSecond Second { get; set; }

        public ComparableCollection(TFirst first, TSecond second)
        {
            First = first;
            Second = second;
        }
    }
}