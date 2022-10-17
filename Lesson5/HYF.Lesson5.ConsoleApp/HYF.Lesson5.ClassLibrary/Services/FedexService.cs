using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HYF.Lesson5.ClassLibrary.Services.Interfaces;

namespace HYF.Lesson5.ClassLibrary.Services
{
    public class FedexService : IShippingCompany
    {
        public string Name { get; set; } = "Fedex";

        public void Ship(string address)
        { 
            Console.WriteLine($"Shipping with fedex to {address}");
        }
    }
}
