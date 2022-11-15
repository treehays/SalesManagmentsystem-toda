    public interface ITransactionManager
    {
        void CreateTransaction(string barCode, int quantity, string customerId, decimal cashTender);
        // void GetTransaction(string receiptNo);
        // Transaction UpdateTransaction();
        // void DeleteTransaction(string receiptNo);
        void GetAllTransactions();
        decimal GetAllTransactionsAdmin();
        decimal CalculateTotalSales();
        // void ReadFromFile();
        // void ReWriteToFile();
    }