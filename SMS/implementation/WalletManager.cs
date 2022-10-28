using SMS.interfaces;

namespace SMS.implementation
{
    public class WalletManager : IWalletManager
    {
        ITransactionManager transactionManager = new TransactionManager();
        public double CalculateRemainingBalance()
        {
            throw new NotImplementedException();
        }

        public void CreateWallet()
        {
            throw new NotImplementedException();
        }

        public void GetTotalWalletTransaction()
        {
            foreach (var item in TransactionManager.listOfTransaction)
            {
                Console.WriteLine($"Staff Id: {item.Id} {item.CustomerId} {item.BarCode} {item.ReceiptNo} ");
            }
        }
    }
}