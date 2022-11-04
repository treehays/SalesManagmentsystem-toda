using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Transactions;
using SMS.interfaces;
using SMS.model;
namespace SMS.implementation
{
    public class TransactionManager : ITransactionManager
    {
        public string transactionFilePath = @"./Files/transaction.txt";
        public static List<Transactiona> listOfTransaction = new List<Transactiona>();
        // public static List<Transactiona> listOfCart = new List<Transactiona>();
        IProductManager iProductManager = new ProductManager();
        public void CreateTransaction(string barCode, int quantity, string customerId, double cashTender)
        {
            var product = iProductManager.GetProduct(barCode);
            var id = listOfTransaction.Count() + 1;
            var receiptNo = "ref" + new Random(id).Next(2323, 1000000).ToString();
            var total = product.Price * quantity;
            var xpectedChange = cashTender - total;
            var dateTime = DateTime.Now;
            if (xpectedChange < 0)
            {
                Console.WriteLine($"You can't pay lower than {total}");
            }
            else
            {
                var transaction = new Transactiona(id, receiptNo, barCode, quantity, total, customerId, dateTime, cashTender);
                listOfTransaction.Add(transaction);
                using (var streamWriter = new StreamWriter(transactionFilePath, append: true))
                {
                    streamWriter.WriteLine(transaction.WriteToFIle());
                }
                Console.WriteLine($"\n__________________________________________________________________________________________\nTransaction Date: {dateTime} \tReceipt No: {receiptNo} \nBarcode: {product.BarCode} \nPrice Per Unit: {product.Price} \nQuantity:{quantity} \nTotal: {product.Price * quantity}\nCustomer ID:{customerId}.\nCustomer Change: {xpectedChange}");
            }

        }
        public double CalculateTotalSales()
        {
            double totalSales = 0;
            foreach (var item in listOfTransaction)
            {
                totalSales = item.Total + totalSales;
            }
            return totalSales;
        }
        public void GetAllTransactions()
        {
            Console.WriteLine("\nID\t\tTRANS. DATE \tCUSTOMER NAME\tTOTAL AMOUNT\tBARCODE\tRECEIPT NO");

            foreach (var item in listOfTransaction)
            {
                Console.WriteLine($"{item.Id}\t{item.Datetime.ToString("d")}\t{item.CustomerId}\t{item.BarCode}\t{item.ReceiptNo}\t{item.Quantity}\t{item.Total}");
            }
        }

        public double GetAllTransactionsAdmin()
        {
            double cumulativeSum = 0;
            foreach (var item in listOfTransaction)
            {
                Console.WriteLine($"{item.Id}\t{item.Datetime.ToString("d")}\t{item.CustomerId}\t{item.BarCode}\t{item.ReceiptNo}\t{item.Quantity}\t{item.Total}\t{cumulativeSum += item.Total}");
            }
            return cumulativeSum;
        }
        public void ReWriteToFile()
        {
            File.WriteAllText(transactionFilePath, string.Empty);
            using (var streamWriter = new StreamWriter(transactionFilePath, append: true))
            {
                foreach (var item in listOfTransaction)
                {
                    streamWriter.WriteLine(item.WriteToFIle());
                }
            }
        }
        public void ReadFromFile()
        {
            if (!File.Exists(transactionFilePath))
            {
                var fileStream = new FileStream(transactionFilePath, FileMode.CreateNew);
                fileStream.Close();
            }
            using (var streamReader = new StreamReader(transactionFilePath))
            {
                while (streamReader.Peek() != -1)
                {
                    var transactionManager = streamReader.ReadLine();
                    listOfTransaction.Add(Transactiona.ConvertToTransaction(transactionManager));
                }
            }
        }
    }
}