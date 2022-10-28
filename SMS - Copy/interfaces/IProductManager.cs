using SMS.model;

namespace SMS.interfaces
{
    public interface IProductManager
    {
        public void CreateProduct(string barCode, string productName, double price, int productQuantity);
        public Product GetProduct(string barCode);
        public void UpdateProduct(string barCode, string productName, double price);
        public void DeleteProduct(string barCode);
         public void ViewAllProduct();
    }
}