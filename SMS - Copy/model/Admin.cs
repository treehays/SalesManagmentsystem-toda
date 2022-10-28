namespace SMS.model
{
    public class Admin : User
    {
        public static List<Admin> listOfAdmin = new List<Admin>();
        public string StaffId { get; set; }
        public string Post { get; set; }
        

        // public double Wallet { get; set; }
        public Admin(string staffId, string firstName, string lastName, string email, string phoneNumber, string pin, string post) : base(firstName, lastName, email, phoneNumber, pin)
        {
            Post = post;
            StaffId = StaffIdGenerator();
        }
        private string StaffIdGenerator()
        {
            return "AD"+new Random().Next(10000,99999).ToString();
        }
    }
}