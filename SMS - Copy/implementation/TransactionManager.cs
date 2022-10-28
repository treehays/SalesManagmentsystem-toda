using System.Transactions;
using SMS.interfaces;
using SMS.model;
namespace SMS.implementation
{
    public class TransactionManager : ITransactionManager
    {
        // public static List<Transactiona> listOfCart = new List<Transactiona>();
        IProductManager iProductManager = new ProductManager();
        public void CreateTransaction(string barCode, int quantity, string customerId, double cashTender)
        {
            Product product = iProductManager.GetProduct(barCode);
            int id = Transactiona.listOfTransaction.Count() + 1;
            string receiptNo = "ref" + new Random(id).Next(2323, 1000000).ToString();
            double total = product.Price * quantity;
            double xpectedChange = cashTender - total;
            DateTime dateTime = DateTime.Now;
            if (xpectedChange < 0)
            {
                Console.WriteLine($"You can't pay lower than {total}");
            }
            else
            {
                Transactiona transaction = new Transactiona(id, receiptNo, barCode, quantity, total, customerId, dateTime, cashTender);
                Transactiona.listOfTransaction.Add(transaction);
                Console.WriteLine($"Transaction Date: {dateTime} \tReceipt No: {receiptNo} \nBarcode: {product.BarCode} \nPrice Per Unit: {product.Price} \nQuantity:{quantity} \nTotal: {product.Price * quantity}\nCustomer ID:{customerId}.\nCustomer Change: {xpectedChange}");
            }

        }
        public double CalculateTotalSales()
        {
            double totalSales = 0;
            foreach (var item in Transactiona.listOfTransaction)
            {
                totalSales = item.Total + totalSales;
            }
            return totalSales;
        }
        public void GetAllTransactions()
        {
            foreach (var item in Transactiona.listOfTransaction)
            {
                Console.WriteLine($"Staff Id: {item.Id} {item.CustomerId} {item.BarCode} {item.ReceiptNo} ");
            }
        }
        // public void GetTransaction(String barCode)
        // {
        // }
    }
}