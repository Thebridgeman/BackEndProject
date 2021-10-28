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
            connection.Open();

            MySqlCommand command = connection.CreateCommand();

            string sqlFormattedDate = toCreate.datetime.ToString("yyyy-MM-dd HH:mm:ss.fff");
            command.CommandText = $"INSERT INTO sales(product_name, sale_quantity, item_price, sale_date) " +
                $"VALUES(@Name, @SaleQuantity, @IndividualItemPrice, @sqlFormattedDate)";

            MySqlParameter nameParam = new MySqlParameter("@Name", MySqlDbType.String);
            MySqlParameter quantityParam = new MySqlParameter("@SaleQuantity", MySqlDbType.Int32);
            MySqlParameter priceParam = new MySqlParameter("@IndividualItemPrice", MySqlDbType.Float);
            MySqlParameter dateParam = new MySqlParameter("@sqlFormattedDate", MySqlDbType.DateTime);

            nameParam.Value = toCreate.Name;
            quantityParam.Value = toCreate.SaleQuantity;
            priceParam.Value = toCreate.IndividualItemPrice;
            dateParam.Value = toCreate.datetime;

            command.Parameters.Add(nameParam);
            command.Parameters.Add(quantityParam);
            command.Parameters.Add(priceParam);
            command.Parameters.Add(dateParam);

            command.Prepare();

            command.ExecuteNonQuery(); 
            
           connection.Close();

            ProductDetails product = new ProductDetails();

            product.ID = (int)command.LastInsertedId;
            product.Name = toCreate.Name;
            product.SaleQuantity = toCreate.SaleQuantity;
            product.IndividualItemPrice = toCreate.IndividualItemPrice;
            product.datetime = toCreate.datetime;

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

                int quantity = reader.GetFieldValue<int>("sale_quantity");

                decimal price = reader.GetFieldValue<decimal>("item_price");

                DateTime saledate = reader.GetFieldValue<DateTime>("sale_date");


                

               ProductDetails product = new ProductDetails() { ID = id, Name = name, SaleQuantity = quantity, IndividualItemPrice = price, datetime = saledate };

                products.Add(product);
            }
            return products;
        }

        public void Update(long id, string fieldToUpdate, string valueToUpdate)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $"UPDATE sales SET {fieldToUpdate} = {valueToUpdate} WHERE sale_id={id}";

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

    }
}

