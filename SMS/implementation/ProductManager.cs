using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SMS.interfaces;
using SMS.model;
namespace SMS.implementation
{
    public class ProductManager : IProductManager
    {
        public static List<Product> listOfProduct = new List<Product>();
        public string productFilePath = @"./Files/product.txt";
        public void CreateProduct(string barCode, string productName, double price, int productQuantity)
        {
            var id = listOfProduct.Count() + 1;
            var product = new Product(id, barCode, productName, price, productQuantity);
            if (GetProduct(barCode) == null)
            {
                listOfProduct.Add(product);
                using (var streamWriter = new StreamWriter(productFilePath, append: true))
                {
                    streamWriter.WriteLine(product.WriteToFIle());
                }

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
                listOfProduct.Remove(product);
                ReWriteToFile();
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }

        public Product GetProduct(string barCode)
        {
            foreach (var item in listOfProduct)
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
            foreach (var item in listOfProduct)
            {
                Console.WriteLine($"{item.Id}\t{item.ProductName}\t{item.BarCode}\t{item.Price}\t{item.ProductQuantity}");
            }
        }
        public void ReWriteToFile()
        {
            File.WriteAllText(productFilePath, string.Empty);
            using (var streamWriter = new StreamWriter(productFilePath, append: true))
            {
                foreach (var item in listOfProduct)
                {
                    streamWriter.WriteLine(item.WriteToFIle());
                }
            }
        }
        public void ReadFromFile()
        {
            if (!File.Exists(productFilePath))
            {
                var fileStream = new FileStream(productFilePath, FileMode.CreateNew);
                fileStream.Close();
            }
            using (var streamReader = new StreamReader(productFilePath))
            {
                while (streamReader.Peek() != -1)
                {
                    var productManager = streamReader.ReadLine();
                    listOfProduct.Add(Product.ConvertToProduct(productManager));
                }
            }
        }
    }
}