using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApplication
{
    class ReadMenu
    {
       public static void ReadOptions()
        {
            Console.WriteLine("1. Sales By Year");
            Console.WriteLine("2. Sales By Month");
            Console.WriteLine("3. Sales Total by Year");
            Console.WriteLine("4. Sales Total by Month and Year");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.WriteLine("Enter a year");
                    string year = Console.ReadLine();
                    //call sales by year function
                    break;
                case "2":
                    Console.WriteLine("Enter a month");
                    string month = Console.ReadLine();
                    //call sales by month function
                    break; 

                case "3":
                    Console.WriteLine("Enter a year");
                    string sumofyear = Console.ReadLine();
                    //call sales total by year function
                    break;

                case "4":
                    Console.WriteLine("Enter a year");
                    string Monthofyear = Console.ReadLine();
                    Console.WriteLine("Enter a month");
                    string sumofmonth = Console.ReadLine();
                    // call sales by month in a year function

                    break;
            }
        }





    }
}
