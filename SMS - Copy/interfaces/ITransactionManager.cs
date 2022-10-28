using System.Transactions;

namespace SMS.interfaces
{
    public interface ITransactionManager
    {
        public void CreateTransaction(string barCode, int quantity, string customerId, double cashTender);
        // public void GetTransaction(string receiptNo);
        // public Transaction UpdateTransaction();
        // public void DeleteTransaction(string receiptNo);
        public void GetAllTransactions();
        public double CalculateTotalSales();
    }
}