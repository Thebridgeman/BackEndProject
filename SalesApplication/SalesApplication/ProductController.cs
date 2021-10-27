using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApplication
{
    class productController
    {
        private readonly ProductServices productServices;

        public productController(ProductServices productServices)
        {

            this.productServices = productServices;
        }

        internal static void Create(MySqlConnection connection)
        {
            Console.WriteLine("Product Name");
            string name = Console.ReadLine();

            Console.WriteLine("Sale Quantity");
            int quantity = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Individual Item Price");
            float price = float.Parse(Console.ReadLine());

            DateTime dateTime = DateTime.Now;

            ProductDetails toCreate = new ProductDetails() { Name = name, SaleQuantity = quantity, IndividualItemPrice = price, datetime = dateTime };

            SalesRepository SR = new SalesRepository(connection);

            ProductDetails newProductDetails = SR.Create(toCreate);
            Console.WriteLine($"Created new Product: {newProductDetails}");
        }
        internal static void Read(MySqlConnection connection)
        {
            SalesRepository SR = new SalesRepository(connection);
            IEnumerable<ProductDetails> productDetailsInDb = SR.Read();

            foreach (var productDetails in productDetailsInDb)
            {
                Console.WriteLine(productDetails);
            }
        }

        internal static void Delete(MySqlConnection connection)
        {
            Console.WriteLine("Enter product id");
            Console.Write("> ");
            string input = Console.ReadLine();
            bool b = long.TryParse(input, out long id);

            if (b)
            {
                
                    SalesRepository SR = new SalesRepository(connection);
                    SR.Delete(id);
            }
        }
        internal static void Update(MySqlConnection connection)
        {
            throw new NotImplementedException();
        }
    }
}
