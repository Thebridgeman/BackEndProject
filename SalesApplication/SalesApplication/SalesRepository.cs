using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApplication
{
    internal class SalesRepository
    {
        private readonly MySqlConnection connection;

        public SalesRepository(MySqlConnection mySqlConnection)
        {
            connection = mySqlConnection;
        }

        public IEnumerable<ProductDetails> Read()
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "Select * FROM sales";

            connection.Open();

            MySqlDataReader reader = command.ExecuteReader();

            IEnumerable<ProductDetails> productDetails = ProductDetailsFromReader(reader);
            connection.Close();

            return productDetails;
        }

        public ProductDetails Create(ProductDetails toCreate)
        {
            MySqlCommand command = connection.CreateCommand();

            string sqlFormattedDate = toCreate.datetime.ToString("yyyy-MM-dd HH:mm:ss.fff");
            command.CommandText = $"INSERT INTO sales(product_name, sale_quantity, item_price, sale_date) VALUES('{toCreate.Name}', '{toCreate.SaleQuantity}', '{toCreate.IndividualItemPrice}', '{sqlFormattedDate}')";

            connection.Open();

            command.ExecuteNonQuery(); 
            
            //ExecuteNonQuery() - use it for CREATE, INSERT, DELETE or any modification


           connection.Close();

            ProductDetails product = new ProductDetails();

            product.ID = (int)command.LastInsertedId;

            product.Name = toCreate.Name;

            return product;
        }

        public void Delete(long id)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $"DELETE FROM sales WHERE sale_id={id}";

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

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

