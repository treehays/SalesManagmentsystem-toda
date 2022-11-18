
using MySql.Data.MySqlClient;
using SMS.model;
public class AdminManager : IAdminManager
    {
        ITransactionManager _iTransactionManager = new TransactionManager();
        static String connString = "SERVER=localhost; User Id=root; Password=1234; DATABASE=sms";
        public void CreateAdmin(string firstName, string lastName, string email, string phoneNumber, string pin, string post)
        {
            var staffId = User.GenerateRandomId();
            var admin = new Admin(staffId, firstName, lastName, email, phoneNumber, pin, post);
            try
            {
                using (var connection = new MySqlConnection(connString))
                {
                    connection.Open();
                    var queryCreate =
                        $"Insert into admin (staffId, firstname, lastname, email, phonenumber, pin, post) values ('{staffId}','{firstName}','{lastName}','{email}','{phoneNumber}','{pin}','{post}')";

                    using (var command = new MySqlCommand(queryCreate, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // ignored
            }
            Console.WriteLine($"Dear {firstName}, Registration Successful! \nYour Staff Identity Number is {admin.StaffId}, \nKeep it Safe.\n");
        }
        public void DeleteAdmin(string staffId)
        {
            var admin = GetAdmin(staffId);
            if (admin != null)
            {
                try
                {
                    var deleteSuccessMsg = $"{admin.FirstName} {admin.LastName} Successfully deleted. ";
                    using (var connection = new MySqlConnection(connString))
                    {
                        connection.Open();
                        using (var command = new MySqlCommand($"DELETE From admin WHERE StaffId = '{staffId}'", connection))
                        {
                            var reader = command.ExecuteNonQuery();
                            Console.WriteLine(deleteSuccessMsg);
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }
        public Admin GetAdmin(string staffId)
        {
            Admin admin = null;
            try
            {
                using (var connection = new MySqlConnection(connString))
                {
                    connection.Open();
                    using (var command = new MySqlCommand($"select * From admin WHERE staffId = '{staffId}'", connection))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            admin = new Admin(reader["staffId"].ToString().ToUpper(), reader["firstName"].ToString(), reader["lastName"].ToString(), reader["email"].ToString(), reader["phonenumber"].ToString(), reader["Pin"].ToString(), reader["post"].ToString());
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return admin is not null && admin.StaffId.ToUpper() == staffId.ToUpper() ? admin : null;
        }
        public void GetAllAdmin()
        {
            try
            {
                using (var connection = new MySqlConnection(connString))
                {
                    connection.Open();
                    using (var command = new MySqlCommand("select * From admin", connection))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader["id"]}\t{reader["staffId"].ToString()}\t{reader["firstName"].ToString()}\t{reader["lastName"].ToString()}\t{reader["email"].ToString()}\t{reader["phonenumber"].ToString()}\t{reader["post"].ToString()}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
        public Admin GetAdmin(string staffId, string email)
        {
            Admin admin = null;
            try
            {
                using (var connection = new MySqlConnection(connString))
                {
                    connection.Open();
                    using (var command = new MySqlCommand($"select * From attendant WHERE email = '{email}'", connection))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            admin = new Admin(reader["staffId"].ToString(), reader["firstName"].ToString(), reader["lastName"].ToString(), reader["email"].ToString(), reader["phonenumber"].ToString(), reader["Pin"].ToString(), reader["post"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return admin is not null && admin.Email.ToUpper() == email.ToUpper() ? admin : null;
        }
        public Admin Login(string staffId, string pin)
        {
            Admin admin = null;
            try
            {
                using (var connection = new MySqlConnection())
                {
                    connection.Open();
                    using (var command = new MySqlCommand($"select * From admin WHERE StaffId = '{staffId}'", connection))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            admin = new Admin(reader["staffId"].ToString(),reader.GetString(2), reader["lastName"].ToString(), reader["email"].ToString(), reader["phonenumber"].ToString(), reader["Pin"].ToString(), reader["post"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return admin is not null && admin.StaffId.ToUpper() == staffId.ToUpper() && admin.Pin == pin ? admin : null;
        }
        public void UpdateAdmin(string staffId, string firstName, string lastName, string phoneNumber)
        {
            // var admin = GetAdmin(staffId);
            // if (admin != null)
            // {
                try
                {
                    using (var connection = new MySqlConnection(connString))
                    {
                        var SuccessMsg = $"{staffId} Updated Successfully. ";
                        connection.Open();
                        var queryUpdateA = $"Update admin SET firstName = '{firstName}', lastName = '{lastName}',phoneNumber = '{phoneNumber}' where staffId = '{staffId}'";
                        using (var command = new MySqlCommand(queryUpdateA, connection))
                        {
                           var yes = command.ExecuteNonQuery();
                            Console.WriteLine(SuccessMsg);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            // }
            // else
            // {
            //     Console.WriteLine("User not found.");
            // }
        }
        public void CreateDataBaseTable()
        {
            var AdminQuery = "CREATE TABLE attendant (ID int auto_increment NOT NULL, StaffId VARCHAR (25) NOT NULL UNIQUE ,FirstName varchar(255) NOT NULL , LastName varchar(255) NOT NULL , Email varchar(100) NOT NULL UNIQUE, PhoneNumber VARCHAR (25) NOT NULL UNIQUE, Pin VARCHAR (50) DEFAULT '0000', Post VARCHAR (50) DEFAULT 'Attendant', primary Key(id,StaffId))";
            try
            {
                using (var connection = new MySqlConnection(connString))
                {
                    connection.Open();
                    using (var command = new MySqlCommand(AdminQuery, connection))
                    {
                        var result = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }