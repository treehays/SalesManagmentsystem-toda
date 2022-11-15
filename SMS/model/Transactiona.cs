
public class Transactiona
{
    public string ReceiptNo { get; set; }
    // public int Id { get; set; }
    public string CustomerId { get; set; }
    public int Quantity { get; set; }
    public decimal Total { get; set; }
    public string BarCode { get; set; }
    public DateTime Datetime { get; set; }
    public decimal CashTender { get; set; }
    public Transactiona(string receiptNo, string barCode, int quantity, decimal total, string customerId, DateTime datetime, decimal cashTender)
    {
        ReceiptNo = receiptNo;
        CashTender = cashTender;
        BarCode = barCode;
        Quantity = quantity;
        CustomerId = customerId;
        Total = total;
        Datetime = datetime;

    }
}