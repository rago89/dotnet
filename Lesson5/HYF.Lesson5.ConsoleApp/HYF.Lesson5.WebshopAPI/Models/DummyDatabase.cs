using HYF.Lesson5.ClassLibrary.Models;

namespace HYF.Lesson5.WebshopAPI.Models
{
    public class DummyDatabase
    {
        public DummyDatabase()
        {
            Products = new List<Product>();
            Persons = new List<Person>();
            OrderDetails = new List<OrderDetails>();

            PopulateDatabase();
        }

        public List<Product> Products { get; set; }
        public List<Person> Persons { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }

        private void PopulateDatabase()
        {
            var shampoo = new Product()
            {
                Description = "Nice smelling shampoo",
                Id = 1,
                Name = "Loreal",
                Price = 10,
            };

            Products.Add(shampoo);

            var stijn = new Person()
            {
                Address = "addressstreet 1 2850 Boom",
                BankAccountNumber = "BE11 1111 1111 1111",
                Name = "Stijn Roscam",
                Id = 1,
            };

            Persons.Add(stijn);
        }

    }
}
