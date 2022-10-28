using SMS.model;
using SMS.interfaces;
namespace SMS.implementation
{
    public class AdminManager : IAdminManager
    {
        public void CreateAdmin(string firstName, string lastName, string email, string phoneNumber, string pin, string post)
        {
            int id = Admin.listOfAdmin.Count() + 1;

            string staffId = "AZ" + new Random(id).Next(1100000).ToString();
            Admin admin = new Admin(staffId, firstName, lastName, email, phoneNumber, pin, post);
            //    Verifying Attendant of Email
            if (GetAdmin(email,phoneNumber) == null)
            {
                Admin.listOfAdmin.Add(admin);
                Console.WriteLine($"Dear {firstName}, Registration Successful! \nYour Staff Identity Number is {admin.StaffId}, \nKeep it Safe.\n");
            }
            else
            {
                Console.WriteLine("Attendant already exist. \nKindly Go to Update to Update the Attendant Details");
            }

            // End
        }
        public void DeleteAdmin(string staffId)
        {
            Admin admin = GetAdmin(staffId);
            if (admin != null)
            {
                Console.WriteLine($"{admin.FirstName} {admin.LastName} Successfully deleted. ");
                Admin.listOfAdmin.Remove(admin);
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }
        public Admin GetAdmin(string staffId)
        {
            foreach (var item in Admin.listOfAdmin)
            {
                if (item.StaffId == staffId)
                {
                    return item;
                }
            }
            return null;
        }
        public Admin GetAdmin(string email, string phoneNumber)
        {
            foreach (var item in Admin.listOfAdmin)
            {
                if (item.Email.ToLower() == email.ToLower() || item.PhoneNumber.ToLower() == phoneNumber.ToLower())
                {
                    return item;
                }
            }
            return null;
        }
        public Admin Login(string staffId, string pin)
        {
            foreach (var item in Admin.listOfAdmin)
            {
                if (item.StaffId.ToLower() == staffId.ToLower() && item.Pin == pin)
                {
                    return item;
                }
            }
            return null;
        }
        public void UpdateAdmin(string staffId, string firstName, string lastName, string phoneNumber)
        {
            Admin admin = GetAdmin(staffId);
            if (admin != null)
            {
                admin.FirstName = firstName;
                admin.LastName = lastName;
                admin.PhoneNumber = phoneNumber;
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }
    }
}