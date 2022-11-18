
using MySql.Data.MySqlClient;
using SMS.model;

public class AttendantManager : IAttendantManager
    {
            static String connString = "SERVER=localhost; User Id=root; Password=1234; DATABASE=sms";
        public void CreateAttendant(string firstName, string lastName, string email, string phoneNumber, string pin, string post)
        {
            var staffId = User.GenerateRandomId();
            var attendant = new Attendant(staffId, firstName, lastName, email, phoneNumber, pin, post);
            try
            {
                using (var connection = new MySqlConnection(connString))
                {
                    connection.Open();
                    var queryCreate =
                        $"Insert into attendant (staffId, firstname, lastname, email, phonenumber, pin, post) values ('{staffId}','{firstName}','{lastName}','{email}','{phoneNumber}','{pin}','{post}')";
                    using (var command = new MySqlCommand(queryCreate, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine($"Attendant Creation was Successful! \nThe Staff Identity Number is {attendant.StaffId} and pint {pin}, \nKeep it Safe.");
        }
        public void DeleteAttendant(string staffId)
        {
            var attendant = GetAttendant(staffId);
            if (attendant != null)
            {
                try
                {
                    using (var connection = new MySqlConnection(connString))
                    {
                        var deleteSuccessMsg = $"{attendant.FirstName} {attendant.LastName} Successfully deleted. ";
                        connection.Open();
                        using (var command = new MySqlCommand($"DELETE From attendant WHERE StaffId = '{staffId}'", connection))
                        {
                            var reader = command.ExecuteNonQuery();
                            Console.WriteLine(deleteSuccessMsg);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
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
                using (var connection = new MySqlConnection(connString))
                {
                    connection.Open();
                    using (var command = new MySqlCommand($"SELECT * From attendant WHERE staffId = '{staffId}'", connection))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            attendant = new Attendant(reader["staffId"].ToString().ToUpper(), reader["firstName"].ToString(), reader["lastName"].ToString(), reader["email"].ToString(), reader["phonenumber"].ToString(), reader["Pin"].ToString(), reader["post"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return attendant is not null && attendant.StaffId.ToUpper() == staffId.ToUpper() ? attendant : null;
        }
        public Attendant GetAttendant(string staffId, string email)
        {
            Attendant attendant = null;
            try
            {
                using (var connection = new MySqlConnection(connString))
                {
                    connection.Open();
                    using (var command = new MySqlCommand($"SELECT * From attendant WHERE email = '{email}'", connection))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            attendant = new Attendant(reader["staffId"].ToString(), reader["firstName"].ToString(), reader["lastName"].ToString(), reader["email"].ToString(), reader["phonenumber"].ToString(), reader["Pin"].ToString(), reader["post"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return attendant is not null && attendant.Email.ToUpper() == email.ToUpper() ? attendant : null;
        }
        public Attendant Login(string staffId, string pin)
        {
            Attendant attendant = null;
            try
            {
                using (var connection = new MySqlConnection(connString))
                {
                    connection.Open();
                    using (var command = new MySqlCommand($"SELECT * From attendant WHERE StaffId = '{staffId}'", connection))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            attendant = new Attendant(reader["staffId"].ToString(), reader["firstName"].ToString(), reader["lastName"].ToString(), reader["email"].ToString(), reader["phonenumber"].ToString(), reader["Pin"].ToString(), reader["post"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
                        var queryUpdateA = $"Update attendant SET firstname = '{firstName}', lastName = '{lastName}' where staffId = '{staffId}'";
                        using (var command = new MySqlCommand(queryUpdateA, connection))
                        {
                            command.ExecuteNonQuery();
                            Console.WriteLine(SuccessMsg);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
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
                using (var connection = new MySqlConnection(connString))
                {
                    connection.Open();
                    using (var command = new MySqlCommand("SELECT * From attendant", connection))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader["staffID"]}\t{reader["firstName"]}\t{reader["lastName"]}\t{reader["email"]}\t{reader["phonenumber"]}\t{reader["pin"]}\t{reader["post"]}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }