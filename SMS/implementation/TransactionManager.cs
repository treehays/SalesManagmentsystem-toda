using MySql.Data.MySqlClient;
using SMS.interfaces;
using SMS.model;

namespace SMS.implementation
{
    public class TransactionManager : ITransactionManager
    {
        // public string TransactionFilePath = @"./Files/transaction.txt";
        public int i = 0;
        public static List<Transactiona> ListOfTransaction = new List<Transactiona>();
        // public static List<Transactiona> listOfCart = new List<Transactiona>();
        static String connString = "SERVER=localhost; User Id=root; Password=1234; DATABASE=sms";
        MySqlConnection connection = new MySqlConnection(connString);
        IProductManager _iProductManager = new ProductManager();
        public void CreateTransaction(string barCode, int quantity, string customerId, double cashTender)
        {
            var product = _iProductManager.GetProduct(barCode);
            var id = ListOfTransaction.Count() + 1;
            var receiptNo = "ref" + new Random(id).Next(2323, 1000000);
            var total = product.Price * quantity;
            var xpectedChange = cashTender - total;
            var dateTime = DateTime.Now;
            if (xpectedChange < 0)
            {
                Console.WriteLine($"You can't pay lower than {total}");
            }
            else
            {
                var transaction = new Transactiona(receiptNo, barCode, quantity, total, customerId, dateTime, cashTender);
                ListOfTransaction.Add(transaction);
                // using (var streamWriter = new StreamWriter(TransactionFilePath, append: true))
                // {
                //     streamWriter.WriteLine(transaction.WriteToFIle());
                // }
                try
                {
                    using (var connection = new MySqlConnection(connString))
                    {
                        connection.Open();
                        string queryCreateTransaction = $"Insert into transaction (receiptNo,barCode,quantity,total,customerId,dateTime,cashTender) values ('{receiptNo}','{barCode}','{quantity}','{total}','{customerId}','{dateTime}','{cashTender}')";
                        var command = new MySqlCommand(queryCreateTransaction, connection);
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex) { }
                Console.WriteLine($"\n__________________________________________________________________________________________\nTransaction Date: {dateTime} \tReceipt No: {receiptNo} \nBarcode: {product.BarCode} \nPrice Per Unit: {product.Price} \nQuantity:{quantity} \nTotal: {product.Price * quantity}\nCustomer ID:{customerId}.\nCustomer Change: {xpectedChange}");
            }

        }
        public double CalculateTotalSales()
        {
            double totalSales = 0;
            foreach (var item in ListOfTransaction)
            {
                totalSales = item.Total + totalSales;
            }
            return totalSales;
        }
        public void GetAllTransactions()
        {
            Console.WriteLine("\nID\t\tTRANS. DATE \tCUSTOMER NAME\tTOTAL AMOUNT\tBARCODE\tRECEIPT NO");

            foreach (var item in ListOfTransaction)
            {

                Console.WriteLine($"{i++}\t{item.Datetime.ToString("d")}\t{item.CustomerId}\t{item.BarCode}\t{item.ReceiptNo}\t{item.Quantity}\t{item.Total}");
            }
        }

        public double GetAllTransactionsAdmin()
        {
            double cumulativeSum = 0;
            foreach (var item in ListOfTransaction)
            {
                Console.WriteLine($"{i++}\t{item.Datetime.ToString("d")}\t{item.CustomerId}\t{item.BarCode}\t{item.ReceiptNo}\t{item.Quantity}\t{item.Total}\t{cumulativeSum += item.Total}");
            }
            return cumulativeSum;
        }
        // public void ReWriteToFile()
        // {
        //     File.WriteAllText(TransactionFilePath, string.Empty);
        //     using (var streamWriter = new StreamWriter(TransactionFilePath, append: true))
        //     {
        //         foreach (var item in ListOfTransaction)
        //         {
        //             streamWriter.WriteLine(item.WriteToFIle());
        //         }
        //     }
        // }
        // public void ReadFromFile()
        // {
        //     if (!File.Exists(TransactionFilePath))
        //     {
        //         var fileStream = new FileStream(TransactionFilePath, FileMode.CreateNew);
        //         fileStream.Close();
        //     }
        //     using (var streamReader = new StreamReader(TransactionFilePath))
        //     {
        //         while (streamReader.Peek() != -1)
        //         {
        //             var transactionManager = streamReader.ReadLine();
        //             ListOfTransaction.Add(Transactiona.ConvertToTransaction(transactionManager));
        //         }
        //     }
        // }
    }
}