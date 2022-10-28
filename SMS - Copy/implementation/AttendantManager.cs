using SMS.interfaces;
using SMS.model;
namespace SMS.implementation
{
    public class AttendantManager : IAttendantManager
    {
        public void CreateAttendant(string firstName, string lastName, string email, string phoneNumber, string pin, string post)
        {
            int id = Attendant.listOfAttendant.Count() + 1;
            // string staffId = "AT" + new Random(id).Next(100000).ToString();
            Attendant attendant = new Attendant(firstName, lastName,email, phoneNumber, pin, post);
            //    Verifying Attendant of Email
            if (GetAttendant(attendant.StaffId,email) == null)
            {
                Attendant.listOfAttendant.Add(attendant);
                Console.WriteLine($"Attendant Creation was Successful! \nThe Staff Identity Number is {attendant.StaffId} and pint {pin}, \nKeep it Safe.");
            }
            else
            {
                Console.WriteLine("Attendant already exist. \nKindly Go to Update to Update the Attendant Details");
            }

            // End
        }
        public void DeleteAttendant(string staffId)
        {
            Attendant attendant = GetAttendant(staffId);
            if (attendant != null)
            {
                Console.WriteLine($"{attendant.FirstName} {attendant.LastName} Successfully deleted. ");
                Attendant.listOfAttendant.Remove(attendant);
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }
        public Attendant GetAttendant(string staffId)
        {
            foreach (var item in Attendant.listOfAttendant)
            {
                if (item.StaffId == staffId)
                {
                    return item;
                }
            }
            return null;
        }
        public Attendant GetAttendant(string staffId, string email)
        {
            foreach (var item in Attendant.listOfAttendant)
            {
                if (item.StaffId.ToLower() == staffId.ToLower() || item.Email.ToLower() == email.ToLower())
                {
                    return item;
                }
            }
            return null;
        }
        public void ViewAttendant(string staffId)
        {
            foreach (var item in Attendant.listOfAttendant)
            {
                Console.WriteLine($"{item.FirstName}\t{item.LastName}\t{item.Email}\t{item.StaffId}\t{item.Post}");
            }
        }
        public Attendant Login(string staffId, string pin)
        {
            foreach (var item in Attendant.listOfAttendant)
            {
                if (item.StaffId.ToLower() == staffId.ToLower() && item.Pin == pin)
                {
                    return item;
                }
            }
            return null;
        }
        public void UpdateAttendant(string staffId, string firstName, string lastName, string phoneNumber)
        {
            Attendant attendant = GetAttendant(staffId);
            if (attendant != null)
            {
                attendant.FirstName = firstName;
                attendant.LastName = lastName;
                attendant.PhoneNumber = phoneNumber;
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }
        public void ViewAllAttendants()
        {
            foreach (var item in Attendant.listOfAttendant)
            {
                Console.WriteLine($"Staff Id: {item.StaffId} {item.LastName} {item.FirstName} {item.Email} {item.PhoneNumber}");
            }
        }
    }
}