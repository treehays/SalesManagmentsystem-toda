    public interface ITransactionManager
    {
        void CreateTransaction(string staffId, string barCode, int quantity, string customerId, decimal cashTender);
        void GetAllTransactions();
        decimal CalculateTotalSales();
        void ViewTransactionAsExcel(string datedNow);
        void ViewTransactionAsHtml(string datedNow);
    }