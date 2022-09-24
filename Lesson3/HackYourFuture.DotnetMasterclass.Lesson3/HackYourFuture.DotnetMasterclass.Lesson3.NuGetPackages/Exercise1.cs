using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackYourFuture.DotnetMasterclass.Lesson3.NuGetPackages
{
    // Install the package "Humanizer" to make the following print statements human readable
    // By installing the package you can now use several overload methods to make the data more readable
    // Check the pacakge's documentation to find out how
    public class Exercise1
    {
        public void PrintTimestampsInHumanReadableFormat()
        {
            // Print the timestamp as weeks
            var firstTimespan = TimeSpan.FromSeconds(1123453978);
            Console.WriteLine(firstTimespan);

            // Print this time in French words
            var time = TimeSpan.FromDays(7);
            Console.WriteLine(time);

            // Print the number in Romand numerals
            var number = 4;
            Console.WriteLine(number);
        }
    }
}
