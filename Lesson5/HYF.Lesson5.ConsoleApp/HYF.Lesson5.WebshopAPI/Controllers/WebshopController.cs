using System.Net;
using System.Text.Json.Serialization;
using HYF.Lesson5.ClassLibrary.Models;
using HYF.Lesson5.ClassLibrary.Services.Interfaces;
using HYF.Lesson5.WebshopAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HYF.Lesson5.WebshopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebshopController : ControllerBase
    {
        private readonly DummyDatabase _db;
        private readonly WebShop _webShop;
        private readonly IPaymentService _paymentService;
        public WebshopController(DummyDatabase database, WebShop webShop, IPaymentService paymentService)
        {
            _db = database;
            _webShop = webShop;
            _paymentService = paymentService;
        }

        [HttpGet]
        [Route("products")]
        public IActionResult GetProducts()
        {
            var products = _db.Products;
            return StatusCode((int) HttpStatusCode.OK, products);
        }

        [HttpPost]
        [Route("order/{productId}/{personId}")]
        public IActionResult OrderProduct(int productId, int personId)
        {
            try
            {
                Product productToOrder = null;
                foreach (var product in _db.Products)
                {
                    if (product.Id == productId)
                    {
                        productToOrder = product;
                    }
                }

                Person personThatOrders = null;
                foreach (var person in _db.Persons)
                {
                    if (person.Id == personId)
                    {
                        personThatOrders = person;
                    }
                }

                if (productToOrder != null && personThatOrders != null)
                {
                    _webShop.OrderItem(productToOrder, personThatOrders, _paymentService);
                    var orderDetail = new OrderDetails();
                    orderDetail.Price = productToOrder.Price.ToString();
                    orderDetail.ProductName = productToOrder.Name;
                    orderDetail.PaymentService = _paymentService.Name;
                    orderDetail.ShippingCompany = _webShop.GetShippingCompanyName();

                    _db.OrderDetails.Add(orderDetail);
                    return StatusCode((int)HttpStatusCode.OK, orderDetail);
                }

                throw new Exception("Product or person does not exist");
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, e.Message);
            }
        }

        [HttpGet]
        [Route("orderdetails")]
        public IActionResult GetOrderDetails()
        {
            var orders = _db.OrderDetails;
            return StatusCode((int)HttpStatusCode.OK, orders);
        }
    }
}
