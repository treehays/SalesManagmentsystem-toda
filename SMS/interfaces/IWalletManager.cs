    public interface IWalletManager
    {
        void CreateWallet();
        void GetTotalWalletTransaction();
        decimal CalculateRemainingBalance(); 
    }