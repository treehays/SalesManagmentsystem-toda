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
            // int id = listOfAttendant.Count() + 1;
            string staffId = User.GenerateRandomId();
            // string staffId = "AT" + new Random(id).Next(100000).ToString();
            Attendant attendant = new Attendant(staffId, firstName, lastName, email, phoneNumber, pin, post);
            //    Verifying Attendant Email
            if (GetAttendant(attendant.StaffId, email) == null)
            {
                listOfAttendant.Add(attendant);
                try
                {
                    using (var connection = new MySqlConnection(connString))
                    {
                        connection.Open();
                        string queryCreateAttendant = $"Insert into attendant (staffid, firstname, lastname, email, phonenumber, pin, post) values ('{staffId}','{firstName}','{lastName}','{email}','{phoneNumber}','{pin}','{post}')";
                        var command = new MySqlCommand(queryCreateAttendant, connection);
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex) { }
                // using (StreamWriter streamWriter = new StreamWriter(attendantFilePath, append: true))
                // {
                //     streamWriter.WriteLine(attendant.WriteToFIle());
                // }
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
                listOfAttendant.Remove(attendant);
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }
        public Attendant GetAttendant(string staffId)
        {
            foreach (var item in listOfAttendant)
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
            foreach (var item in listOfAttendant)
            {
                if (item.StaffId == staffId || item.Email == email)
                {
                    return item;
                }
            }
            return null;
        }
        public void ViewAttendant(string staffId)
        {
            try
            {
                using (MySqlCommand command = new MySqlCommand("select * From staffs", connection))
                {
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["id"]}  {reader["name"]}\t\t{reader["email"]}\t\t{reader["age"]}");
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
            try
            {
                MySqlCommand command = new MySqlCommand($"select * From staffs WHERE staffId = {staffId}", connection);
                var reader = command.ExecuteReader();
                connection.Open();
                while (reader.Read())
                {
                    Attendant attendant = new Attendant(reader["id"].ToString(), reader["firstName"].ToString(), reader["lastName"].ToString(), reader["email"].ToString(), reader["iphone"].ToString(), reader["pin"].ToString(), reader["post"].ToString());
                    if (reader["staffId"].ToString().ToUpper() == staffId.ToUpper() && reader["pin"].ToString() == pin)
                    {
                        connection.Close();
                        return attendant;
                    }
                    else
                    {
                        connection.Close();
                        return null;
                    }
                    // Console.WriteLine($"{reader["id"]}  {reader["name"]}\t\t{reader["email"]}\t\t{reader["age"]}");
                }
            }
            catch (System.Exception)
            { }
            finally
            {
                connection.Close();
            }

            // foreach (var item in listOfAttendant)
            // {
            //     if (item.StaffId.ToUpper() == staffId.ToUpper() && item.Pin == pin)
            //     {
            //         return item;
            //     }
            // }
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

            try
            {
                using (MySqlCommand command = new MySqlCommand("select * From attendant", connection))
                {
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["id"]}  {reader["name"]}\t\t{reader["email"]}\t\t{reader["age"]}");
                    }
                }
            }
            catch (System.Exception)
            { }


            // foreach (var item in listOfAttendant)
            // {
            //     Console.WriteLine($"{item.StaffId} {item.LastName} {item.FirstName} {item.Email} {item.PhoneNumber}");
            // }
        }
        // public void ReWriteToFile()
        // {
        //     File.WriteAllText(attendantFilePath, string.Empty);
        //     using (StreamWriter streamWriter = new StreamWriter(attendantFilePath, append: true))
        //     {
        //         foreach (var item in listOfAttendant)
        //         {
        //             streamWriter.WriteLine(item.WriteToFIle());
        //         }
        //     }
        // }
        // public void ReadFromFile()
        // {
        //     if (!File.Exists(attendantFilePath))
        //     {
        //         FileStream fileStream = new FileStream(attendantFilePath, FileMode.CreateNew);
        //         fileStream.Close();
        //     }
        //     using (StreamReader streamReader = new StreamReader(attendantFilePath))
        //     {
        //         while (streamReader.Peek() != -1)
        //         {
        //             // if (streamReader.Peek() == -1)
        //             // {
        //             string attendantManager = streamReader.ReadLine();
        //             listOfAttendant.Add(Attendant.ConvertToAttendant(attendantManager));
        //             // }
        //         }
        //     }
        // }
    }
}








/*using MySql.Data.MySqlClient;
using SMS.interfaces;
using SMS.model;

namespace SMS.implementation
{
    public class AttendantManager : IAttendantManager
    {
        public static List<Attendant> ListOfAttendant = new List<Attendant>();
        // public string AttendantFilePath = @"./Files/attendant.txt";
        static String connString = "SERVER=localhost; User Id=root; Password=1234; DATABASE=sms";
        MySqlConnection connection = new MySqlConnection(connString);
        public void CreateAttendant(string firstName, string lastName, string email, string phoneNumber, string pin, string post)
        {
            // var id = ListOfAttendant.Count() + 1;
            // string staffId = "AT" + new Random(id).Next(100000).ToString();
            string staffId = User.GenerateRandomId();
            var attendant = new Attendant(staffId, firstName, lastName, email, phoneNumber, pin, post);
            //    Verifying Attendant Email
            if (GetAttendant(attendant.StaffId, email) == null)
            {
                ListOfAttendant.Add(attendant);
                // using (var streamWriter = new StreamWriter(AttendantFilePath, append: true))
                // {
                //     streamWriter.WriteLine(attendant.WriteToFIle());
                // }

                try
                {
                    using (var connection = new MySqlConnection(connString))
                    {
                        connection.Open();
                        string queryCreateAttendant = $"Insert into attendant (staffid, firstname, lastname, email, phonenumber, pin, post) values ('{staffId}','{firstName}','{lastName}','{email}','{phoneNumber}','{pin}','{post}')";
                        var command = new MySqlCommand(queryCreateAttendant, connection);
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex) { }
                Console.WriteLine($"Attendant Creation was Successful! \nThe Staff Identity Number is {attendant.StaffId} and pint {pin}, \nKeep it Safe.");
            }
            else
            {
                Console.WriteLine("Attendant already exist. \nKindly Go to Update to Update the Attendant Details");
            }
        }

        // End
    }
    public void DeleteAttendant(string staffId)
    {
        var attendant = GetAttendant(staffId);
        if (attendant.StaffId != null)
        {
            Console.WriteLine($"{attendant.FirstName} {attendant.LastName} Successfully deleted. ");
            ListOfAttendant.Remove(attendant);
        }
        else
        {
            Console.WriteLine("User not found.");
        }
    }
    public Attendant GetAttendant(string staffId)
    {
        try
        {
            MySqlCommand command = new MySqlCommand($"select * From staffs WHERE staffId = {staffId}", connection);

            var reader = command.ExecuteReader();
            connection.Open();
            while (reader.Read())
            {
                Console.WriteLine($"{reader["id"]}  {reader["name"]}\t\t{reader["email"]}\t\t{reader["age"]}");
            }
            Attendant attendant = new Attendant(reader["id"].ToString(), reader["firstName"].ToString(), reader["lastName"].ToString(), reader["email"].ToString(), reader["iphone"].ToString(), reader["pin"].ToString(), reader["post"].ToString());
        }
        catch (System.Exception)
        { }/////////////        }
    }
    public Attendant GetAttendant(string staffId, string email)
    {
        foreach (var item in ListOfAttendant)
        {
            if (item.StaffId == staffId || item.Email == email)
            {
                return item;
            }
        }
        return null;
    }
    public void ViewAttendant(string staffId)
    {


        try
        {
            using (MySqlCommand command = new MySqlCommand("select * From staffs", connection))
            {
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["id"]}  {reader["name"]}\t\t{reader["email"]}\t\t{reader["age"]}");
                }
            }
        }
        catch (System.Exception)
        { }

        // foreach (var item in ListOfAttendant)
        // {
        //     Console.WriteLine($"{item.FirstName}\t{item.LastName}\t{item.Email}\t{item.StaffId}\t{item.Post}");
        // }
    }
    public Attendant Login(string staffId, string pin)
    {
        foreach (var item in ListOfAttendant)
        {
            if (item.StaffId.ToUpper() == staffId.ToUpper() && item.Pin == pin)
            {
                return item;
            }
        }
        return null;
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
            using (MySqlCommand command = new MySqlCommand("select * From attendant", connection))
            {
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["id"]}  {reader["name"]}\t\t{reader["email"]}\t\t{reader["age"]}");
                }
            }
        }
        catch (System.Exception)
        { }

        // foreach (var item in ListOfAttendant)
        // {
        //     Console.WriteLine($"{item.StaffId} {item.LastName} {item.FirstName} {item.Email} {item.PhoneNumber}");
        // }
    }
    // public void ReWriteToFile()
    // {
    //     File.WriteAllText(AttendantFilePath, string.Empty);
    //     using (var streamWriter = new StreamWriter(AttendantFilePath, append: true))
    //     {
    //         foreach (var item in ListOfAttendant)
    //         {
    //             streamWriter.WriteLine(item.WriteToFIle());
    //         }
    //     }
    // }
    // public void ReadFromFile()
    // {
    //     if (!File.Exists(AttendantFilePath))
    //     {
    //         var fileStream = new FileStream(AttendantFilePath, FileMode.CreateNew);
    //         fileStream.Close();
    //     }
    //     using (var streamReader = new StreamReader(AttendantFilePath))
    //     {
    //         while (streamReader.Peek() != -1)
    //         {
    //             // if (streamReader.Peek() == -1)
    //             // {
    //                 var attendantManager = streamReader.ReadLine();
    //                 ListOfAttendant.Add(Attendant.ConvertToAttendant(attendantManager));
    //             // }
    //         }
    //     }
    // }
}
}
*/