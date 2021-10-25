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

            MySqlDataReader reader = command.ExecuteReader();

            IEnumerable<ProductDetails> productDetails = ProductDetailsFromReader(reader);
            connection.Close();

            return productDetails;
        }

        public ProductDetails Create(ProductDetails toCreate)
        {
            MySqlCommand command = connection.CreateCommand();

            command.CommandText = $"INSERT INTO item(name) VALUES('{toCreate.Name}')";

            connection.Open();

            command.ExecuteNonQuery(); // ExecuteNonQuery() - use it for CREATE, INSERT, DELETE or any modification

            connection.Close();

            ProductDetails product = new ProductDetails();

            product.ID = (int)command.LastInsertedId;

            product.Name = toCreate.Name;

            return product;
        }

        public void Delete(int id)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $"DELETE FROM productDetails WHERE id={id}";

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public IList<ProductDetails> ProductDetailsFromReader(MySqlDataReader reader)
        {
            IList<ProductDetails> productDetails = new List<ProductDetails>();
            while (reader.Read())
            {
                int id = reader.GetFieldValue < int>("id");
                string name = reader.GetFieldValue<string>("name");

                ProductDetails productDetils = new ProductDetails() { ID = id, Name = name };
                productDetails.Add(productDetils);
            }
            return productDetails;
        }

    }
}

