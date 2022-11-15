
using SMS.model;

public class Admin : User
    {
        public string Post { get; set; }
        // public decimal Wallet { get; set; }
        public Admin(string staffId, string firstName, string lastName, string email, string phoneNumber, string pin, string post) : base(staffId, firstName, lastName, email, phoneNumber, pin)
        {
            Post = post;
        }
       
    }
