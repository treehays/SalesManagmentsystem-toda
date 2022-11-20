
using System.Diagnostics;
using MySql.Data.MySqlClient;

public class TransactionManager : ITransactionManager
{
    public int i = 0;
    private readonly static String connString = "SERVER=localhost; User Id=root; Password=1234; DATABASE=sms";
    IProductManager _iProductManager = new ProductManager();
    public void CreateTransaction(string staffId, string barCode, int quantity, string customerId, decimal cashTender)
    {
        var product = _iProductManager.GetProduct(barCode);
        // var id = ListOfTransaction.Count() + 1;
        // var receiptNo = "ref" + new Random(new Random().Next(10)).Next(2323, 1000000);
        var receiptNo = GenerateRandomRefNO();
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
                    var queryCreate = $"Insert into transaction (staffId,barcode,productname,price,quantity,receiptno,total,customerid,cashtender,datetimes) values ('{staffId}','{barCode}','{product.ProductName}', '{product.Price}', '{quantity}','{receiptNo}', '{total}', '{customerId}', '{cashTender}','{dateTime}')";
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
            UpdateInventoryQuantity(product, quantity, barCode);
            Console.WriteLine($"\n_________________________________________________________________________________________________\n_________________________________________________________________________________________________\nTransaction Date: {dateTime} \tReceipt No: {receiptNo} \nBarcode: {product.BarCode}\t\t\t\t\tATTENDANT ID{staffId}\n_________________________________________________________________________________________________\n_________________________________________________________________________________________________ \nPrice Per Unit: {product.Price} \nQuantity:{quantity} \nTotal: {product.Price * quantity}\nCustomer ID:{customerId}.\nCustomer Change: {xpectedChange}");
        }

    }
    private static void UpdateInventoryQuantity(Product product, int quantity, string barCode)
    {
        try//updating inventory
        {
            using (var connection = new MySqlConnection(connString))
            {
                connection.Open();
                var queryCreate = $"Update product SET productQuantity = {product.ProductQuantity - quantity} where barcode = '{barCode}'";
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
    }
    public decimal CalculateTotalSales()
    {
        decimal walletBalance = 0;
        try
        {
            using (var connection = new MySqlConnection(connString))
            {
                connection.Open();
                using (var command = new MySqlCommand($"SELECT sum(total) FROM transaction", connection))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        walletBalance = Convert.ToDecimal(reader[0]);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return walletBalance;

    }

    
    public void GenerateTransactionCSV(string datedNow)
    {

        try
        {
            using (var connection = new MySqlConnection(connString))
            {
                connection.Open();
                using (var command = new MySqlCommand("select * From transaction", connection))
                {
                    string dateSaved = DateTime.Now.ToString();//to be used,,the Menu can be accepting date as parameters and sending itto this place in order to have same date
                    var reader = command.ExecuteReader();
                    var outLines = new List<string>();//saving to list
                    outLines.Add("id,dateTimes,recieptNo,barCode,productName,price,Quantity,total,customerId");
                    while (reader.Read())
                    {
                        // Console.WriteLine($"{reader["id"].ToString()}\t{reader["barCode"].ToString()}\t{reader["productName"].ToString()}\t{(decimal)(reader["price"])}\t{Convert.ToInt32((reader["productQuantity"]))}");
                        outLines.Add($"{reader["staffId"].ToString().Remove(10)},{reader["id"].ToString()},{reader["dateTimes"].ToString()},{reader["receiptNo"].ToString()},{reader["barCode"].ToString()},{reader["productName"].ToString()},{(decimal)(reader["price"])},{Convert.ToInt32((reader["Quantity"]))},{(decimal)(reader["total"])},{reader["customerId"].ToString()}");
                    }
                    File.WriteAllLines($"./File/AZtransact"+datedNow.Trim()+".csv", outLines.ToArray());
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }


    public void GenerateTransactionHTML(string datedNow)
    {

        try
        {
            using (var connection = new MySqlConnection(connString))
            {
                connection.Open();
                using (var command = new MySqlCommand("select * From transaction", connection))
                {
                    string dateSaved = DateTime.Now.ToString();//to be used,,the Menu can be accepting date as parameters and sending itto this place in order to have same date
                    var reader = command.ExecuteReader();
                    var outLines = new List<string>();//saving to list
                    outLines.Add(@"<style>table, th, td {border: 1px solid black;border-collapse: collapse;}</style> <table style=""width: 100%""><tr><th>headin</th><th>headin</th><th>headin</th><th>headin</th><th>headin</th><th>headin</th><th>headin</th></tr>");
                    while (reader.Read())
                    {
                        // Console.WriteLine($"{reader["id"].ToString()}\t{reader["barCode"].ToString()}\t{reader["productName"].ToString()}\t{(decimal)(reader["price"])}\t{Convert.ToInt32((reader["productQuantity"]))}");
                        outLines.Add($"<tr><td>{reader["staffId"].ToString().Remove(10)}</td><td>{reader["id"].ToString()}</td><td>{reader["dateTimes"].ToString()}</td><td>{reader["receiptNo"].ToString()}</td><td>{reader["barCode"].ToString()}</td><td>{reader["productName"].ToString()}</td><td>{(decimal)(reader["price"])}</td><td>{Convert.ToInt32((reader["Quantity"]))}</td><td>{(decimal)(reader["total"])}</td><td>{reader["customerId"].ToString()}</td></tr>");
                    }
                    outLines.Add("</table>");
                    File.WriteAllLines($"./File/AZtransact"+datedNow.Trim()+".html", outLines.ToArray());
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void ViewTransactionAsExcel(string datedNow)
    {
       
        GenerateTransactionCSV(datedNow);
        string csvPath = $"file:///C:/Users/Treehays/Documents/CLH/New%20folder/Sales-Managment-system-a9f7f5c5c01ade0e51bd3f89aa2856667084fafc/SMS/File/AZtransact"+datedNow.Trim()+".csv";
        var prc = new ProcessStartInfo(@"C:\Program Files\Microsoft Office\root\Office16\EXCEL.EXE");
        prc.Arguments = csvPath;
        Process.Start(prc);
    }

    public void ViewTransactionAsHTML(string datedNow)
    {
       
        GenerateTransactionHTML(datedNow);
        string csvPath = $@"file:///C:/Users/Treehays/Documents/CLH/New%20folder/Sales-Managment-system-a9f7f5c5c01ade0e51bd3f89aa2856667084fafc/SMS/File/AZtransact"+datedNow.Trim()+".html";
        // var prc = new ProcessStartInfo(@"C:\Program Files\Google\Chrome\Application\chrome.exe");
        var prc = new ProcessStartInfo(@"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe");
        prc.Arguments = csvPath;
        Process.Start(prc);
    }

    public void GetAllTransactions()
    {

        // Console.WriteLine("\nID\t\tTRANS.DATE \tCUSTOMER NAME\tTOTAL AMOUNT\tBARCODE\tRECEIPT NO");
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
                        Console.WriteLine($"{reader["barcode"]}\t{reader["productName"]}\t{reader["price"]}\t{reader["quantity"]}\t{reader["receiptno"]}\t{reader["total"]}\t{reader["customerid"]}\t{reader["cashtender"]}\t{reader["datetimes"]}");
                        // Console.WriteLine($"{reader["receiptNo"]}\t{reader["barCode"].ToString()}\t{reader["quantity"].ToString()}\t{reader["total"].ToString()}\t{reader["customerId"].ToString()}\t{reader["dateTime"].ToString()}\t{reader["cashTender"].ToString()}");
                    }
                }
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
    private static string GenerateRandomRefNO()
    {
        var refs = Guid.NewGuid();
        string productRefNo = "A" + refs.ToString().Remove(11);
        return productRefNo;
    }
    // public decimal GetAllTransactionsAdmin()
    // {
    //     decimal cumulativeSum = 0;
    //     // foreach (var item in ListOfTransaction)
    //     // {
    //     //     Console.WriteLine($"{i++}\t{item.Datetime.ToString("d")}\t{item.CustomerId}\t{item.BarCode}\t{item.ReceiptNo}\t{item.Quantity}\t{item.Total}\t{cumulativeSum += item.Total}");
    //     // }
    //     return cumulativeSum;
    // }
}
