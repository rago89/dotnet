using HackYourFuture.DotnetMasterclass.Lesson3.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace HackYourFuture.DotnetMasterclass.Lesson3.Generics
{
    // Create a class that can print the concatenated ToString() value of two generic variables
    public class Exercise1<TFirst, TSecond>
    {
        public string Print(TFirst first, TSecond second)
        {
            var firstAndSecond = $"{first}{second}";
            System.Console.WriteLine(firstAndSecond);
            return firstAndSecond;
        }
    }
}
