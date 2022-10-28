namespace SMS.interfaces
{
    public interface ICustomerCartManager
    {
        public void AddToCart(string barCode, int quantity);
        public void RemoveFromCart(string barCode);
        public void UpdateCart(string barCode, int quantity);

    }
}