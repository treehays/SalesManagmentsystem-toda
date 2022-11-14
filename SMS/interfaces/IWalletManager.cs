namespace SMS.interfaces
{
    public interface IWalletManager
    {
        void CreateWallet();
        void GetTotalWalletTransaction();
        decimal CalculateRemainingBalance(); 
    }
}