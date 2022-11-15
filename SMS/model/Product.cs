
public class Product
{
    // public int Id { get; set; }
    public string BarCode { get; set; }
    public string ProductName { get; set; }
    public decimal Price { get; set; }
    public int ProductQuantity { get; set; }
    public Product(string barCode, string productName, decimal price, int productQuantity)
    {
        // Id = id;
        BarCode = barCode;
        ProductName = productName;
        Price = price;
        ProductQuantity = productQuantity;
    }
}
