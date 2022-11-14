using SMS.model;

namespace SMS.interfaces
{
    public interface IProductManager
    {
        public void CreateProduct(string barCode, string productName, decimal price, int productQuantity);
        public Product GetProduct(string barCode);
        public void UpdateProduct(string barCode, string productName, decimal price);
        public void DeleteProduct(string barCode);
         public void ViewAllProduct();
    }
}