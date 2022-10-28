namespace SMS.model
{
    public class Attendant : User
    {
        public string Post { get; set; }
        public string StaffId {get;set;}
        public static List<Attendant> listOfAttendant = new List<Attendant>();

        public Attendant(string firstName, string lastName, string email, string phoneNumber, string pin, string post) : base(firstName, lastName, email, phoneNumber, pin)
        {
            Post = post;
            StaffId = AttendantIdGenerator();
        }
        private string AttendantIdGenerator()
        {
            return "AT"+new Random().Next(10000,99999).ToString();
        }
    }
}