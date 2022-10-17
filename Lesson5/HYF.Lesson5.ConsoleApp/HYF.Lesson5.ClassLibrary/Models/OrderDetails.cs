using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYF.Lesson5.ClassLibrary.Models
{
    public class OrderDetails
    {
        public string ShippingCompany { get; set; }
        public string PaymentService { get; set; }
        public string ProductName { get; set; }
        public string Price { get; set; }
        public DateTime OrderDateTime { get; set; }

        public OrderDetails()
        {
            OrderDateTime = DateTime.Now;
        }
    }
}
