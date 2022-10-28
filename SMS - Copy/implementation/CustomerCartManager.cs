using SMS.interfaces;
using SMS.model;
using SMS.implementation;

namespace SMS.implementation
{
    public class CustomerCartManager : ICustomerCartManager
    {
        IProductManager iProductManager = new ProductManager();
        public void AddToCart(string barCode, int quantity)
        {
            Product product = iProductManager.GetProduct(barCode);

            CustomerCart customerCart = new CustomerCart(barCode, quantity);
           CustomerCart.listOfCustomerCart.Add(customerCart);
        }

        public void RemoveFromCart(string barCode)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCart(string barCode, int quantity)
        {
            throw new System.NotImplementedException();
        }
    }
}