using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HYF.Lesson5.ClassLibrary.Services.Interfaces;

namespace HYF.Lesson5.ClassLibrary.Services
{
    public class BPost : IShippingCompany
    {
        public string Name { get; set; } = "Bpost";

        public void Ship(string address)
        {
            // handle shipping ....
            Console.WriteLine($"Shipping to {address}");
            throw new Exception("BPost not available");
        }
    }
}
