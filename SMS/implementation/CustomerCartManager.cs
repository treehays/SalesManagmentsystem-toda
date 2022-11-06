using System.Collections.Generic;
using SMS.interfaces;
using SMS.model;
using SMS.implementation;

namespace SMS.implementation
{
    public class CustomerCartManager : ICustomerCartManager
    {
        List<CustomerCart> _listOfCustomerCart = new List<CustomerCart>();
        IProductManager _iProductManager = new ProductManager();
        public void AddToCart(string barCode, int quantity)
        {
            var product = _iProductManager.GetProduct(barCode);

            var customerCart = new CustomerCart(barCode, quantity);
            _listOfCustomerCart.Add(customerCart);
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