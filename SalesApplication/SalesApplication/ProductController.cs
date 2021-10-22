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

        internal static void Create()
        {
            Console.WriteLine("Product Name");
            string name = Console.ReadLine();

            Console.WriteLine("Sale Quantity");
            int quantity = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Individual Item Price");
            float price = float.Parse(Console.ReadLine());

            DateTime dateTime = DateTime.Now;

            ProductDetails toCreate = new ProductDetails() { Name = name };

            ProductDetails newProductDetails = ProductServices.Create(toCreate);
            Console.WriteLine($"Created new Product: {newProductDetails}");
        }
        internal void Read()
        {
            IEnumerable<ProductDetails> productDetailsInDb = productServices.Read();

            foreach (var productDetails in productDetailsInDb)
            {
                Console.WriteLine(productDetails);
            }
        }

        internal static void Delete()
        {
            Console.WriteLine("Enter product id");
            Console.Write("> ");
            string input = Console.ReadLine();
            bool b = int.TryParse(input, out int id);

            //if (b)
            //{
            //    try
            //    {
            //        productServices.Delete(id);
            //    }
            //    catch(ItemNotFoundException e)
            //    {
            //        Console.WriteLine($" Product with ID {id} doesn't exist");
                }

        internal static void Update()
        {
            throw new NotImplementedException();
        }
    }
        }
//    }
//}
