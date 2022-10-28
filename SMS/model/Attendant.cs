namespace SMS.model
{
    public class Attendant : User
    {
        public string Post { get; set; }
        public Attendant(int id, string firstName, string lastName, string staffId, string email, string phoneNumber, string pin, string post) : base(id, firstName, lastName, staffId, email, phoneNumber, pin)
        {
            Post = post;
        }
        public string WriteToFIle()
        {
            return $"{Id}%%%%%{FirstName}%%%%%{LastName}%%%%%{StaffId}%%%%%{Email}%%%%%{PhoneNumber}%%%%%{Pin}%%%%%{Post}";
        }

        public static Attendant ConvertToAttendant(string attendantAllFromText)
        {
            string[] attendantConvert = attendantAllFromText.Split("%%%%%");
            return new Attendant(int.Parse(attendantConvert[0]), attendantConvert[1], attendantConvert[2], attendantConvert[3], attendantConvert[4], attendantConvert[5], attendantConvert[6], attendantConvert[7]);
        }
    }
}