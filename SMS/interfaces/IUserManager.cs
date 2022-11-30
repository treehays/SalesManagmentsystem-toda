using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SMS.model;

namespace SMS.interfaces
{
    public interface IUserManager
    {
        void CreateUser(string firstName, string lastName, string email, string phoneNumber, string pin, int userRole);
        User GetUser(string staffId);
        User GetUser(string staffId, string email);
        void GetAllUser();
        void UpdateUser(string staffId, string firstName, string lastName, string phoneNumber);
        void DeleteUser(string staffId);
        User Login(string staffId, string pin);
        void UpdateUserPassword(string staffId, string pin);
        // int UserRoleById(User user);




       // void CreateAttendant(string firstName, string lastName, string email, string phoneNumber, string pin, string post);
       // Attendant GetAttendant(string staffId);
        //Attendant GetAttendant(string staffId, string email);
        //void UpdateAttendant(string staffId, string firstName, string lastName, string phoneNumber);
       // void DeleteAttendant(string staffId);
        //Attendant Login(string staffId, string pin);
        //void ViewAllAttendants();
        //void UpdateAttendantPassword(string staffId, string pin);

    }
}