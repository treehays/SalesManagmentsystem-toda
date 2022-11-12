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
            try
            {
                using (var connection = new MySqlConnection(connString))
                {
                    connection.Open();
                    var queryCreate =
                        $"Insert into attendant (staffId, firstname, lastname, email, phonenumber, pin, post) values ('{staffId}','{firstName}','{lastName}','{email}','{phoneNumber}','{pin}','{post}')";
                    var command = new MySqlCommand(queryCreate, connection);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                // ignored
            }
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
                try
                {
                    var deleteSuccessMsg = $"{attendant.FirstName} {attendant.LastName} Successfully deleted. ";
                    using (var command = new MySqlCommand($"DELETE From attendant WHERE StaffId = '{staffId}'", connection))
                    {
                        connection.Close();
                        connection.Open();
                        var reader = command.ExecuteNonQuery();
                        System.Console.WriteLine(deleteSuccessMsg);
                    }
                }
                catch (System.Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                    // ignored
                }
            }
            else
            {
                Console.WriteLine("Attendant not found.");
            }
        }
        public Attendant GetAttendant(string staffId)
        {
            Attendant attendant = null;
            try
            {
                using (var command = new MySqlCommand($"select * From attendant WHERE staffId = '{staffId}'", connection))
                {
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        attendant = new Attendant(reader["staffId"].ToString().ToUpper(), reader["firstName"].ToString(), reader["lastName"].ToString(), reader["email"].ToString(), reader["phonenumber"].ToString(), reader["Pin"].ToString(), reader["post"].ToString());
                        // Console.WriteLine($"{reader["id"]}  {reader["name"]}\t\t{reader["email"]}\t\t{reader["age"]}");
                    }
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                // return null;
            }
            return attendant is not null && attendant.StaffId.ToUpper() == staffId.ToUpper() ? attendant : null;
        }
        public Attendant GetAttendant(string staffId, string email)
        {
            Attendant attendant = null;
            try
            {
                using (var command = new MySqlCommand($"select * From attendant WHERE email = '{email}'", connection))
                {
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        attendant = new Attendant(reader["staffId"].ToString(), reader["firstName"].ToString(), reader["lastName"].ToString(), reader["email"].ToString(), reader["phonenumber"].ToString(), reader["Pin"].ToString(), reader["post"].ToString());
                    }
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                // return null;
            }
            return attendant is not null && attendant.Email.ToUpper() == email.ToUpper() ? attendant : null;
        }
/*
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
                        // Console.WriteLine($"{reader["id"]}  {reader["firstname"]}\t\t{reader["lastname"]}\t\t{reader["email"]}\t\t{reader["phonenumber"]}\t\t{reader["post"]}");
                        // Console.WriteLine($"{reader["id"]}\t{reader["staffId"].ToString()}\t{reader["firstName"].ToString()}\t{reader["lastName"].ToString()}\t{reader["email"].ToString()}\t{reader["phonenumber"].ToString()}\t{reader["Pin"].ToString()}\t{reader["post"].ToString()}");
                        Console.WriteLine($"{reader["id"]}\t{reader["staffId"].ToString()}\t{reader["firstName"].ToString()}\t{reader["lastName"].ToString()}\t{reader["email"].ToString()}\t{reader["phonenumber"].ToString()}\t{reader["post"].ToString()}");
                        // Console.WriteLine($"{reader["id"]}  {reader["name"]}\t\t{reader["email"]}\t\t{reader["age"]}");
                    }
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                // ignored
            }
        }
*/
        public Attendant Login(string staffId, string pin)
        {
            Attendant attendant = null;
            try
            {
                using (var command = new MySqlCommand($"select * From attendant WHERE StaffId = '{staffId}'", connection))
                {
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        attendant = new Attendant(reader["staffId"].ToString(), reader["firstName"].ToString(), reader["lastName"].ToString(), reader["email"].ToString(), reader["phonenumber"].ToString(), reader["Pin"].ToString(), reader["post"].ToString());
                        // Console.WriteLine($"{reader["id"]}  {reader["name"]}\t\t{reader["email"]}\t\t{reader["age"]}");
                        // Console.WriteLine($"{reader["id"]}  {reader["firstname"]}\t\t{reader["lastname"]}\t\t{reader["email"]}\t\t{reader["phonenumber"]}\t\t{reader["post"]}");
                    }
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                // ignored
            }

            return attendant is not null && attendant.StaffId.ToUpper() == staffId.ToUpper() && attendant.Pin == pin ? attendant : null;
        }
        public void UpdateAttendant(string staffId, string firstName, string lastName, string phoneNumber)
        {
            var attendant = GetAttendant(staffId);
            if (attendant != null)
            {
                try
                {
                    using (var connection = new MySqlConnection(connString))
                    {
                        var SuccessMsg = $"{attendant.StaffId} Updated Successfully. ";
                        connection.Open();
                        var queryUpdateA = $"Update attendant SET firstname = '{firstName}', lastName = '{lastName}'";
                        var command = new MySqlCommand(queryUpdateA, connection);
                        command.ExecuteNonQuery();
                        System.Console.WriteLine(SuccessMsg);
                    }
                }
                catch (System.Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Attendant not found.");
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
