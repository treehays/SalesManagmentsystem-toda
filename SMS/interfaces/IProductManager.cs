
    public interface IProductManager
    {
        void CreateProduct(string barCode, string productName, decimal price, int quantity);
        Product GetProduct(string barCode);
        void UpdateProduct(string barCode, string productName, decimal price, int quantity);
        void DeleteProduct(string barCode);
        void ViewAllProduct();
        // void ReadFromFile();
        // void ReWriteToFile();
    }