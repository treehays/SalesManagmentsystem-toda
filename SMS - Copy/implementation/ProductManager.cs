using SMS.interfaces;
using SMS.model;
namespace SMS.implementation
{
    public class ProductManager : IProductManager
    {
        public void CreateProduct(string barCode, string productName, double price, int productQuantity)
        {
            int id = Product.listOfProduct.Count() + 1;
            Product product = new Product(id, barCode, productName, price, productQuantity);
            if (GetProduct(barCode) == null)
            {
                Product.listOfProduct.Add(product);
                Console.WriteLine($"Product Added Successfully. \nThere are total of {id} product's in the store.");
            }
            else
            {
                Console.WriteLine("Product already exist. \nKindly Go to Update to Update Available Quantity");
            }
        }
        public void DeleteProduct(string barCode)
        {
            Product product = GetProduct(barCode);
            if (product != null)
            {
                Console.WriteLine($"{product.ProductName} Successfully deleted. ");
                Product.listOfProduct.Remove(product);
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }

        public Product GetProduct(string barCode)
        {
            foreach (var item in Product.listOfProduct)
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
            Product product = GetProduct(barCode);
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
            
            foreach (var item in Product.listOfProduct)
            {
                Console.WriteLine($"{item.Id} \t{item.ProductName} \t{item.BarCode} \t{item.ProductQuantity} \t{item.Price}");
            }
        }
    }
}