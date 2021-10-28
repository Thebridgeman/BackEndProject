using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApplication
{
    class ReadFunctionsController
    {
        private readonly ReadFunctionServices readFunctionServices;

        public ReadFunctionsController(ReadFunctionServices readFunctionServices)
        {

            this.readFunctionServices = readFunctionServices;
        }

        internal static void SalesInYear(MySqlConnection connection, string year)
        {
            ReadRepository RR = new ReadRepository(connection);
            IEnumerable<ProductDetails> productDetailsInDb = RR.SalesInYear(year);
            foreach (var productDetails in productDetailsInDb)
            {
                Console.WriteLine(productDetails);
            }
        }

        internal static void SalesInMonth(MySqlConnection connection, string month)
        {
            ReadRepository RR = new ReadRepository(connection);
            IEnumerable<ProductDetails> productDetailsInDb = RR.SalesInMonth(month);
            foreach (var productDetails in productDetailsInDb)
            {
                Console.WriteLine(productDetails);
            }

        }

        internal static void SumOfSalesInYear(MySqlConnection connection, string sumofsalesinyear)
        {
            ReadRepository RR = new ReadRepository(connection);
            RR.SumOfSalesInYear(sumofsalesinyear);

        }

        internal static void SalesInMonthOfYear(MySqlConnection connection, string year, string month)
        {
            ReadRepository RR = new ReadRepository(connection);
            RR.SalesInMonthOfYear(year, month);
        }
        }
    }
