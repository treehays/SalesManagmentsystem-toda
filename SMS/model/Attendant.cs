namespace SMS.model
{
    public class Attendant : User
    {
        public string Post { get; set; }
        public Attendant(string staffId, string firstName, string lastName, string email, string phoneNumber, string pin, string post) : base(staffId, firstName, lastName, email, phoneNumber, pin)
        {
            Post = post;
        }
        // public string WriteToFIle()
        // {
        //     return $"{Id}%%%%%{StaffId}%%%%%{FirstName}%%%%%{LastName}%%%%%{Email}%%%%%{PhoneNumber}%%%%%{Pin}%%%%%{Post}";
        // }

        // public static Attendant ConvertToAttendant(string attendantAllFromText)
        // {
        //     var attendantConvert = attendantAllFromText.Split("%%%%%");
        //     return new Attendant(int.Parse(attendantConvert[0]), attendantConvert[1], attendantConvert[2], attendantConvert[3], attendantConvert[4], attendantConvert[5], attendantConvert[6], attendantConvert[6]);
        // }
    }
}