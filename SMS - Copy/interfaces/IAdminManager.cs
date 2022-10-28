using SMS.model;
namespace SMS.interfaces
{
    public interface IAdminManager
    {
        public void CreateAdmin(string firstName, string lastName, string email, string phoneNumber, string pin, string post);
        public Admin GetAdmin(string staffId);
        public Admin GetAdmin(string email, string phoneNumber);
        public void UpdateAdmin(string staffId, string firstName, string lastName, string phoneNumber);
        public void DeleteAdmin(string staffId);
        public Admin Login(string staffId, string pin);
    }
}