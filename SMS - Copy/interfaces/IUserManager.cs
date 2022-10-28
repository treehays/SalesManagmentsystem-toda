using SMS.model;

namespace SMS.interfaces
{
    public interface IUserManager
    {
         
         public void CreateUser (string userId, string pin, string role);
         public User LoginUser (string userId, string pin);
         public User GetUser (string userId);
    }
}