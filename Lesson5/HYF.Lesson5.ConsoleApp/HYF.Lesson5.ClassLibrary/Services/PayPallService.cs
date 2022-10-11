using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HYF.Lesson5.ClassLibrary.Services.Interfaces;

namespace HYF.Lesson5.ClassLibrary.Services
{
    public class PayPallService : IPaymentService
    {
        public string Name { get; set; } = "PayPall";

        public void HandlePayment(double price, string bankAccountNumber)
        {
            if (bankAccountNumber is null)
                    throw new Exception("Bankaccountnumber is invalid");
            // Handle payments ...
            Console.WriteLine($"Handling payments: {price} $ to bankaccount: {bankAccountNumber}");

        }
    }
}
