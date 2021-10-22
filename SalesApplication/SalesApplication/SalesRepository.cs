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

        public ProductDetails Create(ProductDetails toCreate)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "Select * FROM productstable";

            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();

            IList<ProductDetails> productDetails = ProductDetailsFromReader(reader);
            connection.Close();

            return (ProductDetails)productDetails;
        }

        internal IEnumerable<ProductDetails> Read()
        {
            throw new NotImplementedException();
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

