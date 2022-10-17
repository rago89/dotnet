using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HYF.Lesson5.ClassLibrary.Services.Interfaces;

namespace HYF.Lesson5.ClassLibrary.Services
{
    public class MasterCardService : IPaymentService
    {
        public string Name { get; set; } = "MasterCard";

        public void HandlePayment(double price, string bankAccountNumber)
        {
            //  handle payment
            Console.WriteLine("Payment handled by Mastercard");
        }
    }
}
