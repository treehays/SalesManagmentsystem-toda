using MySql.Data.MySqlClient;
using SMS.interfaces;
using SMS.model;

namespace SMS.implementation
{
    public class ProductManager : IProductManager
    {
        static String connString = "SERVER=localhost; User Id=root; Password=1234; DATABASE=sms";
        public void CreateProduct(string barCode, string productName, double price, int productQuantity)
        {
            var product = new Product(barCode, productName, price, productQuantity);
            try
            {
                using (var connection = new MySqlConnection(connString))
                {
                    connection.Open();
                    var queryCreateProduction = $"Insert into attendant (barCode,productName,price,productQuantity) values ('{barCode}','{productName}','{price}','{productQuantity}')";
                    using (var command = new MySqlCommand(queryCreateProduction, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
        public void DeleteProduct(string barCode)
        {
            var product = GetProduct(barCode);
            if (product != null)
            {
                try
                {
                    var deleteSuccessMsg = $"{product.BarCode} {product.ProductName} Successfully deleted. ";
                    using (var connection = new MySqlConnection(connString))
                    {
                        connection.Open();
                        using (var command = new MySqlCommand($"DELETE From product WHERE barCode = '{barCode}'", connection))
                        {
                            var reader = command.ExecuteNonQuery();
                            System.Console.WriteLine(deleteSuccessMsg);
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }

        public Product GetProduct(string barCode)
        {
            Product product = null;
            try
            {
                using (var connection = new MySqlConnection(connString))
                {
                    connection.Open();
                    using (var command = new MySqlCommand($"select * From product WHERE baCOde = '{barCode}'", connection))
                    {
                        // connection.Close();
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            product = new Product(reader["barCode"].ToString().ToUpper(), reader["productName"].ToString(), (double)(reader["price"]), Convert.ToInt32((reader["productQuantity"])));
                            // Console.WriteLine($"{reader["id"]}  {reader["name"]}\t\t{reader["email"]}\t\t{reader["age"]}");
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                // return null;
            }
            return product is not null && product.BarCode.ToUpper() == barCode.ToUpper() ? product : null;
        }
        public void UpdateProduct(string barCode, string productName, double price)
        {
            var product = GetProduct(barCode);
            if (product != null)
            {
                try
                {
                    using (var connection = new MySqlConnection(connString))
                    {
                        var SuccessMsg = $"{product.BarCode} Updated Successfully. ";
                        connection.Open();
                        var queryUpdateA = $"Update product SET productname = '{productName}', price = '{price}'";
                        using (var command = new MySqlCommand(queryUpdateA, connection))
                        {
                            command.ExecuteNonQuery();
                            System.Console.WriteLine(SuccessMsg);
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }
        public void ViewAllProduct()
        {
            try
            {
                using (var connection = new MySqlConnection(connString))
                {
                    connection.Open();
                    using (var command = new MySqlCommand("select * From product", connection))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader["barCode"].ToString()}\t{reader["productName"].ToString()}\t{(double)(reader["price"])}\t{Convert.ToInt32((reader["productQuantity"]))}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}