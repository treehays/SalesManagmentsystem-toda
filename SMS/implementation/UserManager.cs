using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SMS.interfaces;
using SMS.model;

namespace SMS.implementation
{
    public class UserManager : IUserManager
    {
        

        public void CreateUser(string firstName, string lastName, string email, string phoneNumber, string pin, int userRole)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(string staffId)
        {
            throw new NotImplementedException();
        }

        public void GetAllUser()
        {
            throw new NotImplementedException();
        }

        public User GetUser(string staffId)
        {
            throw new NotImplementedException();
        }

        public User GetUser(string staffId, string email)
        {
            throw new NotImplementedException();
        }

        public User Login(string staffId, string pin)
        {
            throw new NotImplementedException();
        }

        public User Login(string staffId, string pin, int userRole)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(string staffId, string firstName, string lastName, string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public void UpdateUserPassword(string staffId, string pin)
        {
            throw new NotImplementedException();
        }
    }
}