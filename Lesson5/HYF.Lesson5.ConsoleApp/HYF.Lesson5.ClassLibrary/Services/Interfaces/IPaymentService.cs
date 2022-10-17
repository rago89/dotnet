using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYF.Lesson5.ClassLibrary.Services.Interfaces
{
    public interface IPaymentService
    {
        string Name { get; set; }
        void HandlePayment(double price, string bankAccountNumber);
    }
}
