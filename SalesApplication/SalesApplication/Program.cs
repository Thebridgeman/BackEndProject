﻿using MySql.Data.MySqlClient;
using System;
using static SalesApplication.ProductDetails;

namespace SalesApplication
{
    class ProductMenu
    {

        //private readonly ProductController productControllor;
        //public ProductMenu(ProductController productControllor)
        //{
        //    this.productControllor p productControllor;
        //}

        public enum MenuOptions

        {
            CREATE,
            READ,
            UPDATE,
            DELETE,
            QUIT
        }
        public static void PrintMenu()
        {
            Array values = Enum.GetValues(typeof(MenuOptions));

            Console.WriteLine("==== Menu ====");
            foreach (var value in values)
            {
                Console.WriteLine(value);
            }

            Console.WriteLine("=== ====== ===");

        }
        public static void InteractiveLoop(MySqlConnection connection)
        {
            bool inMenu = true;

            while (inMenu)
            {
                Console.Clear();
                PrintMenu();
                string input = Console.ReadLine();
                bool b = Enum.TryParse(input, true, out MenuOptions menuOptions);

                if (b == false)
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }

                switch (menuOptions)
                {
                    case MenuOptions.CREATE:
                        productController.Create(connection);
                        break;

                    case MenuOptions.READ:
                        productController.Read(connection);
                        break;
                    
                    case MenuOptions.UPDATE:
                        productController.Update(connection);
                        break;

                    case MenuOptions.DELETE:
                        productController.Delete(connection);
                        break;

                    case MenuOptions.QUIT:
                        inMenu = false;
                        
                        break;
                }
                if (inMenu != false)
                {
                    Console.WriteLine("Press any key to continue");
                }
                else
                {
                    Console.WriteLine("Press any key to exit");
                }
                
                Console.ReadKey();
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            MySqlConnection connection = MySqlUtils.GetConnection();

            connection.Open();
            bool connectionOpen = connection.Ping();

            Console.WriteLine($@"\nConnection status: {connection.State}
                Ping successfull: {connectionOpen}
                DB Version: {connection.ServerVersion}
                Connection String: {connection.ConnectionString}");

            MySqlUtils.RunSchema(Environment.CurrentDirectory + @"\static\Schema.sql", connection);

            connection.Close();

            string s = " Sales ";
            Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
            Console.WriteLine(s);
            ProductMenu.InteractiveLoop(connection);
        }
    }
}



     
