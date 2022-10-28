namespace SMS.model
{
    public class Admin : User
    {
        public string Post { get; set; }
        // public double Wallet { get; set; }
        public Admin(int id, string firstName, string lastName, string staffId, string email, string phoneNumber, string pin, string post) : base(id, firstName, lastName, staffId, email, phoneNumber, pin)
        {
            Post = post;
            // Wallet = wallet;
        }

        public string WriteToFIle()
        {
            return $"{Id}%%%%%{FirstName}%%%%%{LastName}%%%%%{StaffId}%%%%%{Email}%%%%%{PhoneNumber}%%%%%{Pin}%%%%%{Post}";
        }

        public static Admin ConvertToAdmin(string adminAllFromText)
        {
            string[] adminConvert = adminAllFromText.Split("%%%%%");
            return new Admin(int.Parse(adminConvert[0]), adminConvert[1], adminConvert[2], adminConvert[3], adminConvert[4], adminConvert[5], adminConvert[6], adminConvert[7]);
        }
    }
}