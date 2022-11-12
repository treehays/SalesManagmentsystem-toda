using MySql.Data.MySqlClient;
using SMS.interfaces;
using SMS.model;

namespace SMS.implementation
{
    public class TransactionManager : ITransactionManager
    {
        public int i = 0;
        static String connString = "SERVER=localhost; User Id=root; Password=1234; DATABASE=sms";
        IProductManager _iProductManager = new ProductManager();
        public void CreateTransaction(string barCode, int quantity, string customerId, double cashTender)
        {
            var product = _iProductManager.GetProduct(barCode);
            // var id = ListOfTransaction.Count() + 1;
            var receiptNo = "ref" + new Random(new Random().Next(10)).Next(2323, 1000000);
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
                try
                {
                    using (var connection = new MySqlConnection(connString))
                    {
                        connection.Open();
                        var queryCreate = $"Insert into transaction (receiptNo, barCode, quantity, total, customerId, dateTime, cashTender) values ('{receiptNo}', '{barCode}', '{quantity}', '{total}', '{customerId}', '{dateTime}', '{cashTender}')";
                        using (var command = new MySqlCommand(queryCreate, connection))
                        {
                            command.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }

                Console.WriteLine($"\n__________________________________________________________________________________________\nTransaction Date: {dateTime} \tReceipt No: {receiptNo} \nBarcode: {product.BarCode} \nPrice Per Unit: {product.Price} \nQuantity:{quantity} \nTotal: {product.Price * quantity}\nCustomer ID:{customerId}.\nCustomer Change: {xpectedChange}");
            }

        }
        public double CalculateTotalSales()
        {
            double totalSales = 0;
            // foreach (var item in ListOfTransaction)
            // {
            //     totalSales = item.Total + totalSales;
            // }
            return totalSales;
        }
        public void GetAllTransactions()
        {

            Console.WriteLine("\nID\t\tTRANS. DATE \tCUSTOMER NAME\tTOTAL AMOUNT\tBARCODE\tRECEIPT NO");
            try
            {
                using (var connection = new MySqlConnection(connString))
                {
                    connection.Open();
                    using (var command = new MySqlCommand("select * From transaction", connection))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader["receiptNo"]}\t{reader["barCode"].ToString()}\t{reader["quantity"].ToString()}\t{reader["total"].ToString()}\t{reader["customerId"].ToString()}\t{reader["dateTime"].ToString()}\t{reader["cashTender"].ToString()}");
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
        public double GetAllTransactionsAdmin()
        {
            double cumulativeSum = 0;
            // foreach (var item in ListOfTransaction)
            // {
            //     Console.WriteLine($"{i++}\t{item.Datetime.ToString("d")}\t{item.CustomerId}\t{item.BarCode}\t{item.ReceiptNo}\t{item.Quantity}\t{item.Total}\t{cumulativeSum += item.Total}");
            // }
            return cumulativeSum;
        }
    }
}