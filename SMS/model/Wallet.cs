
public class Wallet
{
    public int Id { get; set; }
    public decimal WalletRemainingBalance { get; set; }
    public decimal WalletTotal { get; set; }
    public decimal WalletWithdrawal { get; set; }

    public Wallet(int id, decimal walletTotal, decimal walletWithdrawal, decimal walletRemainingBalance)
    {
        Id = id;
        WalletTotal = walletTotal;
        WalletWithdrawal = walletWithdrawal;
        WalletRemainingBalance = WalletWithdrawal;
    }
}