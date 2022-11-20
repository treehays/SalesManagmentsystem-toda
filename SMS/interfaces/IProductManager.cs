
    public interface IProductManager
    {
        void CreateProduct(string barCode, string productName, decimal price, int quantity);
        Product GetProduct(string barCode);
        void UpdateProduct(string barCode, string productName, decimal price);
        void RestockProduct(string barCode, int quantity);
        void DeleteProduct(string barCode);
        void SortedProductByQuantity(int quantity);
        void ViewAllProduct();
        
        // void ReadFromFile();
        // void ReWriteToFile();
    }