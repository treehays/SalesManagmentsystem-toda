using SMS.model;

public class Attendant : User
{
    public string Post { get; set; }
    public Attendant(string staffId, string firstName, string lastName, string email, string phoneNumber, string pin, string post) : base(staffId, firstName, lastName, email, phoneNumber, pin)
    {
        Post = post;
    }

}