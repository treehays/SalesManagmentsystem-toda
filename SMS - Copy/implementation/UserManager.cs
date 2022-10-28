using SMS.interfaces;
using SMS.model;

namespace SMS.implementation
{
    public class UserManager : IUserManager
    {
        public void CreateUser(string staffId, string pin, string role)
        {
            // User user = new User(lastName,lastName,email,phoneNumber,pin);
        }

        public User GetUser(string userId)
        {
            throw new NotImplementedException();
        }

        public User LoginUser(string userId, string pin)
        {
            throw new NotImplementedException();
        }
    }
}