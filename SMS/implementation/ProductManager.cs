using MySql.Data.MySqlClient;
public class ProductManager : IProductManager
{
    private readonly static String ConnString = "SERVER=localhost; User Id=root; Password=1234; DATABASE=sms";
    public void CreateProduct(string barCode, string productName, decimal price, int quantity)
    {
        new Product(barCode, productName, price, quantity);
        try
        {
            using (var connection = new MySqlConnection(ConnString))
            {
                connection.Open();
                var queryCreateProduction = $"Insert into product (barCode,productName,price,productQuantity) values ('{barCode}','{productName}','{price}','{quantity}')";
                using (var command = new MySqlCommand(queryCreateProduction, connection))
                {
                    command.ExecuteNonQuery();
                    var successMsg = $"{productName} Added Successfully.";
                    Console.WriteLine(successMsg);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    public void DeleteProduct(string barCode)
    {
        var product = GetProduct(barCode.Trim());
        if (product != null)
        {
            try
            {
                var deleteSuccessMsg = $"{product.BarCode} {product.ProductName} Successfully deleted. ";
                using (var connection = new MySqlConnection(ConnString))
                {
                    connection.Open();
                    using (var command = new MySqlCommand($"DELETE From product WHERE barCode = '{barCode}'", connection))
                    {
                        command.ExecuteNonQuery();
                        Console.WriteLine(deleteSuccessMsg);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
            using (var connection = new MySqlConnection(ConnString))
            {
                connection.Open();
                using (var command = new MySqlCommand($"select * From product WHERE barCode = '{barCode.Trim()}'", connection))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        product = new Product(reader["barCode"].ToString().ToUpper(), reader["productName"].ToString(), (decimal)(reader["price"]), Convert.ToInt32((reader["productQuantity"])));
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return product is not null && product.BarCode.ToUpper() == barCode.ToUpper() ? product : null;
    }
    public void RestockProduct(string barCode, int quantity)
    {
        quantity = quantity < 0 ? 0 : quantity;
        var product = GetProduct(barCode);
        if (product != null)
        {
            try
            {
                using (var connection = new MySqlConnection(ConnString))
                {
                    var successMsg = $"{product.BarCode} Successfully Restocked.";
                    connection.Open();
                    var queryUpdateA = $"Update product SET productQuantity = ({quantity} + product.productQuantity) where barcode = '{barCode.Trim()}'";
                    using (var command = new MySqlCommand(queryUpdateA, connection))
                    {
                        command.ExecuteNonQuery();
                        Console.WriteLine(successMsg);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        else
        {
            Console.WriteLine("Product not found.");
        }
    }
    public void UpdateProduct(string barCode, string productName, decimal price)
    {
        var product = GetProduct(barCode);
        if (product != null)
        {
            try
            {
                using (var connection = new MySqlConnection(ConnString))
                {
                    var successMsg = $"{product.BarCode} Updated Successfully. ";
                    connection.Open();
                    var queryUpdateA = $"Update product SET productname = '{productName}', price = '{price}' where barcode = '{barCode.Trim()}'";
                    using (var command = new MySqlCommand(queryUpdateA, connection))
                    {
                        command.ExecuteNonQuery();
                        Console.WriteLine(successMsg);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        else
        {
            Console.WriteLine("User not found.");
        }
    }
    public void SortedProductByQuantity(int quantity)
    {
        try
        {
            using (var connection = new MySqlConnection(ConnString))
            {
                connection.Open();
                using (var command = new MySqlCommand($"select * From product where productQuantity < {quantity}", connection))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["id"].ToString()}\t{reader["barCode"].ToString()}\t{reader["productName"].ToString()}\t{(decimal)(reader["price"])}\t{Convert.ToInt32((reader["productQuantity"]))}");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    public void ViewAllProduct()
    {
        try
        {
            using (var connection = new MySqlConnection(ConnString))
            {
                connection.Open();
                using (var command = new MySqlCommand("select * From product", connection))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["id"].ToString()}\t{reader["barCode"].ToString()}\t{reader["productName"].ToString()}\t{(decimal)(reader["price"])}\t{Convert.ToInt32((reader["productQuantity"]))}");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    
    public void InventoryQuantityAlert()
    {
        // quantity = 100;
        string numbersOfOutOfStockProduct=null;
        try
        {
            using (var connection = new MySqlConnection(ConnString))
            {
                connection.Open();
                using (var command = new MySqlCommand($"select count(barcode) from product where productquantity < 100 ", connection))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        // Console.WriteLine($"{reader["id"].ToString()}\t{reader["barCode"].ToString()}\t{reader["productName"].ToString()}\t{(decimal)(reader["price"])}\t{Convert.ToInt32((reader["productQuantity"]))}");
                        numbersOfOutOfStockProduct = (reader[0]).ToString();
                    }
                    Console.WriteLine($"‼‼❗⚠RESTOCK ALERT {numbersOfOutOfStockProduct} PRODUCTS ARE GOING OUT OF STOCK.");

                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
