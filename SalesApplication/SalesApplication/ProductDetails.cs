using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApplication
{
    class ProductDetails
    {
        public void CreateItem()
        {
            //Console.WriteLine(" What is the Sale ID");
            //string ID= Console.ReadLine();

            Console.WriteLine("Product Name");
            string name = Console.ReadLine();

            Console.WriteLine("Sale Quantity");
            int quantity = Int32.Parse(Console.ReadLine());


            Console.WriteLine("Individual Item Price");
            float price = float.Parse (Console.ReadLine());

            DateTime SaleDate;
            Console.WriteLine("Sale Date format MM/DD/YYYY");
            SaleDate = DateTime.Parse(Console.ReadLine());
            

            
        }

    }
}
