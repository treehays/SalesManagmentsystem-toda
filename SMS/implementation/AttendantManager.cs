using MySql.Data.MySqlClient;
using SMS.interfaces;
using SMS.model;
namespace SMS.implementation
{
    public class AttendantManager : IAttendantManager
    {
        public static List<Attendant> listOfAttendant = new List<Attendant>();
        // public string attendantFilePath = @"./Files/attendant.txt";
        static String connString = "SERVER=localhost; User Id=root; Password=1234; DATABASE=sms";
        MySqlConnection connection = new MySqlConnection(connString);
        public void CreateAttendant(string firstName, string lastName, string email, string phoneNumber, string pin, string post)
        {
            var staffId = User.GenerateRandomId();
            var attendant = new Attendant(staffId, firstName, lastName, email, phoneNumber, pin, post);
            //    Verifying Attendant Email
            // if (GetAttendant(staffId, email) == null)
            // {
                listOfAttendant.Add(attendant);
                try
                {
                    // using (var connection = new MySqlConnection(connString))
                    // {
                    //     connection.Open();
                    //     var queryCreateAttendant = 
                    //         $"Insert into attendant (staffid, firstname, lastname, email, phonenumber, pin, post) values ('{staffId}','{firstName}','{lastName}','{email}','{phoneNumber}','{pin}','{post}')";
                    //     var command = new MySqlCommand(queryCreateAttendant, connection);
                    //     command.ExecuteNonQuery();
                    // }

                    using (var connection = new MySqlConnection(connString))
                    {
                        connection.Open();
                        var queryCreateAdmin =
                            $"Insert into attendant (staffId, firstname, lastname, email, phonenumber, pin, post) values ('{staffId}','{firstName}','{lastName}','{email}','{phoneNumber}','{pin}','{post}')";
                        var command = new MySqlCommand(queryCreateAdmin, connection);
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex) { }
                Console.WriteLine($"Attendant Creation was Successful! \nThe Staff Identity Number is {attendant.StaffId} and pint {pin}, \nKeep it Safe.");
            // }
            // else
            // {
            //     Console.WriteLine("Attendant already exist. \nKindly Go to Update to Update the Attendant Details");
            // }
        }
        public void DeleteAttendant(string staffId)
        {
            var attendant = GetAttendant(staffId);
            if (attendant != null)
            {
                Console.WriteLine($"{attendant.FirstName} {attendant.LastName} Successfully deleted. ");
                listOfAttendant.Remove(attendant);
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }
        public Attendant GetAttendant(string staffId)
        {
            Attendant attendant = null;
            try
            {
                using (var command = new MySqlCommand($"select * From attendant WHERE staffId = {staffId}", connection))
                {
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        attendant = new Attendant(reader["staffID"].ToString(), reader["firstName"].ToString(), reader["lastName"].ToString(), reader["email"].ToString(), reader["phonenumber"].ToString(), reader["pin"].ToString(), reader["post"].ToString());
                        // Console.WriteLine($"{reader["id"]}  {reader["name"]}\t\t{reader["email"]}\t\t{reader["age"]}");
                    }
                }
            }
            catch (System.Exception)
            {
                // return null;
            }
            return attendant.StaffId == staffId ? attendant : null;
        }
        public Attendant GetAttendant(string staffId, string email)
        {
            Attendant attendant = null;
            try
            {
                using (var command = new MySqlCommand($"select * From attendant WHERE staffId = {staffId}", connection))
                {
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        attendant = new Attendant(reader["staffID"].ToString(), reader["firstName"].ToString(), reader["lastName"].ToString(), reader["email"].ToString(), reader["phonenumber"].ToString(), reader["pin"].ToString(), reader["post"].ToString());
                        // Console.WriteLine($"{reader["id"]}  {reader["name"]}\t\t{reader["email"]}\t\t{reader["age"]}");
                    }
                }
            }
            catch (System.Exception)
            {
                // return null;
            }
            return attendant.StaffId == staffId ? attendant : null;
        }
        public void ViewAttendant(string staffId)
        {
            try
            {
                using (var command = new MySqlCommand("select * From attendant", connection))
                {
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["staffID"]}\t{reader["firstName"]}\t{reader["lastName"]}\t{reader["email"]}\t{reader["phonenumber"]}\t{reader["pin"]}\t{reader["post"]}");
                    }
                }
            }
            catch (System.Exception)
            { }

            // foreach (var item in listOfAttendant)
            // {
            //     Console.WriteLine($"{item.FirstName}\t{item.LastName}\t{item.Email}\t{item.StaffId}\t{item.Post}");
            // }
        }
        public Attendant Login(string staffId, string pin)
        {
            Attendant attendant = null;
            try
            {
                using (var command = new MySqlCommand($"SELECT * From attendant WHERE staffId = {staffId}", connection))
                {
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        attendant = new Attendant(reader["staffid"].ToString(), reader["firstName"].ToString(), reader["lastName"].ToString(), reader["email"].ToString(), reader["iphone"].ToString(), reader["pin"].ToString(), reader["post"].ToString());
                        // Console.WriteLine($"{reader["id"]}  {reader["name"]}\t\t{reader["email"]}\t\t{reader["age"]}");
                    }
                }
            }
            catch (System.Exception)
            {
                // ignored
            }

            return attendant.Email.ToUpper() == staffId.ToUpper() && attendant.Pin.ToString() == pin ? attendant : null;
        }
        public void UpdateAttendant(string staffId, string firstName, string lastName, string phoneNumber)
        {
            var attendant = GetAttendant(staffId);
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

            try
            {
                using (var command = new MySqlCommand("select * From attendant", connection))
                {
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["staffID"]}\t{reader["firstName"]}\t{reader["lastName"]}\t{reader["email"]}\t{reader["phonenumber"]}\t{reader["pin"]}\t{reader["post"]}");
                        // Console.WriteLine($"{reader["id"]}  {reader["name"]}\t\t{reader["email"]}\t\t{reader["age"]}");
                    }
                }
            }
            catch (System.Exception)
            {
                // ignored
            }
        }
    }
}
