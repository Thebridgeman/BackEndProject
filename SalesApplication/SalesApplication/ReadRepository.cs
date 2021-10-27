using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApplication
{
    class ReadRepository
    {

        private readonly MySqlConnection connection;

        public  ReadRepository(MySqlConnection mySqlConnection)
        {
            connection = mySqlConnection;
        }

        public IEnumerable<ProductDetails> SalesInYear(string year)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $"Select * FROM sales where year(sale_date) = {year}";

            //MySqlParameter yearParam = new MySqlParameter("@year", MySqlDbType.DateTime);

            //yearParam.Value = year;

            connection.Open();

            MySqlDataReader reader = command.ExecuteReader();

            IEnumerable<ProductDetails> productDetails = ProductDetailsFromReader(reader);
            connection.Close();

            return (productDetails);
        
        }

        public IEnumerable<ProductDetails> SalesInMonth(string month)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $"Select * FROM sales where month(sale_date) = {month}";

            connection.Open();

            MySqlDataReader reader = command.ExecuteReader();

            IEnumerable<ProductDetails> productDetails = ProductDetailsFromReader(reader);
            connection.Close();

            return (productDetails);
        }

        //public IEnumerable<ProductDetails> SumOfSalesInYear(string year)
        //{
        //    MySqlCommand command = connection.CreateCommand();
        //    command.CommandText = $"select sum(item_price * sale_quantity) from sales where year(sale_date) = {year};";

        //    connection.Open();

        //    MySqlDataReader reader = command.ExecuteReader();

            
        //    connection.Close();

        //    return ()
        //}

        //public IEnumerable<ProductDetails> SalesInMonthOfYear(string year, string month)
        //{
        //    MySqlCommand command = connection.CreateCommand();
        //    command.CommandText = $"Select * FROM sales where month(sale_date) = {month}";

        //    connection.Open();

        //    MySqlDataReader reader = command.ExecuteReader();

        //    IEnumerable<ProductDetails> productDetails = ProductDetailsFromReader(reader);
        //    connection.Close();

        //    return (productDetails);
        //}

        public IList<ProductDetails> ProductDetailsFromReader(MySqlDataReader reader)
        {
            IList<ProductDetails> products = new List<ProductDetails>();

            while (reader.Read())

            {
                long id = reader.GetFieldValue<long>("sale_id");

                string name = reader.GetFieldValue<string>("product_name");

                ProductDetails product = new ProductDetails() { ID = id, Name = name };

                products.Add(product);
            }
            return products;
        }
    }

}
