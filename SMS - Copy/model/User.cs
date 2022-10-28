namespace SMS.model
{
    public class User
    {
        // public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Pin { get; set; }
        // public string StaffId {get;set;}
        public User(string firstName, string lastName, string email, string phoneNumber, string pin)
        {
            
            // Id = id;
            FirstName = firstName;
            LastName = lastName;
            // StaffId = staffId;
            Email = email;
            PhoneNumber = phoneNumber;
            Pin = pin;

        }
    }
}