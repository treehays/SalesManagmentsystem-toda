using MySql.Data.MySqlClient;
using SMS.interfaces;
using SMS.model;

namespace SMS.implementation
{
    public class ProductManager : IProductManager
    {
        static String connString = "SERVER=localhost; User Id=root; Password=1234; DATABASE=sms";
        MySqlConnection connection = new MySqlConnection(connString);
        public static List<Product> ListOfProduct = new List<Product>();
        // public string ProductFilePath = @"./Files/product.txt";
        public void CreateProduct(string barCode, string productName, double price, int productQuantity)
        {
            var id = ListOfProduct.Count() + 1;
            var product = new Product(barCode, productName, price, productQuantity);
            if (GetProduct(barCode) == null)
            {
                ListOfProduct.Add(product);
                // using (var streamWriter = new StreamWriter(ProductFilePath, append: true))
                // {
                //     streamWriter.WriteLine(product.WriteToFIle());
                // }
                try
                {
                    using (var connection = new MySqlConnection(connString))
                    {
                        connection.Open();
                        string queryCreateProduction = $"Insert into attendant (barCode,productName,price,productQuantity) values ('{barCode}','{productName}','{price}','{productQuantity}')";
                        var command = new MySqlCommand(queryCreateProduction, connection);
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex) { }

                Console.WriteLine($"Product Added Successfully. \nThere are total of {id} product's in the store.");
            }
            else
            {
                Console.WriteLine("Product already exist. \nKindly Go to Update to Update Available Quantity");
            }
        }
        public void DeleteProduct(string barCode)
        {
            var product = GetProduct(barCode);
            if (product != null)
            {
                Console.WriteLine($"{product.ProductName} Successfully deleted. ");
                ListOfProduct.Remove(product);
                // ReWriteToFile();
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }

        public Product GetProduct(string barCode)
        {
            foreach (var item in ListOfProduct)
            {
                if (item.BarCode == barCode)
                {
                    return item;
                }
            }
            return null;
        }
        public void UpdateProduct(string barCode, string productName, double price)
        {
            var product = GetProduct(barCode);
            if (product != null)
            {
                product.BarCode = barCode;
                product.ProductName = productName;
                product.Price = price;
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }
        public void ViewAllProduct()
        {
            try
            {
                using (MySqlCommand command = new MySqlCommand("select * From product", connection))
                {
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["id"]}  {reader["name"]}\t\t{reader["email"]}\t\t{reader["age"]}");
                    }
                }
            }
            catch (System.Exception)
            { }


            // int i = 0;
            // foreach (var item in ListOfProduct)
            // {
            //     Console.WriteLine($"{i++}\t{item.ProductName}\t{item.BarCode}\t{item.Price}\t{item.ProductQuantity}");
            // }
        }
        // public void ReWriteToFile()
        // {
        //     File.WriteAllText(ProductFilePath, string.Empty);
        //     using (var streamWriter = new StreamWriter(ProductFilePath, append: true))
        //     {
        //         foreach (var item in ListOfProduct)
        //         {
        //             streamWriter.WriteLine(item.WriteToFIle());
        //         }
        //     }
        // }
        // public void ReadFromFile()
        // {
        //     if (!File.Exists(ProductFilePath))
        //     {
        //         var fileStream = new FileStream(ProductFilePath, FileMode.CreateNew);
        //         fileStream.Close();
        //     }
        //     using (var streamReader = new StreamReader(ProductFilePath))
        //     {
        //         while (streamReader.Peek() != -1)
        //         {
        //             var productManager = streamReader.ReadLine();
        //             ListOfProduct.Add(Product.ConvertToProduct(productManager));
        //         }
        //     }
        // }
    }
}