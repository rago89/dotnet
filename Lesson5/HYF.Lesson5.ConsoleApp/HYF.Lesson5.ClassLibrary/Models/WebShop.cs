using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HYF.Lesson5.ClassLibrary.Services;
using HYF.Lesson5.ClassLibrary.Services.Interfaces;

namespace HYF.Lesson5.ClassLibrary.Models
{
    public class WebShop
    {
        public string Name { get; set; }
        private readonly IShippingCompany _shippingCompany;

        public WebShop(IShippingCompany shippingCompany)
        {
            _shippingCompany = shippingCompany;
        }

        public void OrderItem(Product product, Person person, IPaymentService paymentService)
        {
            paymentService.HandlePayment(product.Price, person.BankAccountNumber);

            _shippingCompany.Ship(person.Address);
        }

        public string GetShippingCompanyName()
        {
            return _shippingCompany.Name;
        }
    }
}
