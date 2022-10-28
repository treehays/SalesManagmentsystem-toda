using SMS.model;

namespace SMS.interfaces
{
    public interface IAttendantManager
    {
        public void CreateAttendant(string firstName, string lastName, string email, string phoneNumber, string pin, string post);
        public Attendant GetAttendant(string staffId);
        public Attendant GetAttendant(string staffId, string email);
        public void UpdateAttendant(string StaffId, string firstName, string lastName, string phoneNumber);
        public void DeleteAttendant(string staffId);
        public Attendant Login(string staffId, string pin);
        public void ViewAttendant(string staffId);
        public void ViewAllAttendants();
    }
}