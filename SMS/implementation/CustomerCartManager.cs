
    public class CustomerCartManager : ICustomerCartManager
    {
        List<CustomerCart> _listOfCustomerCart = new List<CustomerCart>();
        IProductManager _iProductManager = new ProductManager();
        public void AddToCart(string barCode, int quantity)
        {
            _iProductManager.GetProduct(barCode);

            var customerCart = new CustomerCart(barCode, quantity);
            _listOfCustomerCart.Add(customerCart);
        }

        public void RemoveFromCart(string barCode)
        {
            throw new NotImplementedException();
        }

        public void UpdateCart(string barCode, int quantity)
        {
            throw new NotImplementedException();
        }
    }