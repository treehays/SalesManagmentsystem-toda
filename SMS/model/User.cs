namespace SMS.model
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Pin { get; set; }
        public string StaffId;
        public User(int id, string firstName, string lastName, string staffId, string email, string phoneNumber, string pin)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            StaffId = staffId;
            Email = email;
            PhoneNumber = phoneNumber;
            Pin = pin;
        }
    }
}