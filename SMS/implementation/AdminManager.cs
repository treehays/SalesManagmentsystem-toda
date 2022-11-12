using MySql.Data.MySqlClient;
using SMS.interfaces;
using SMS.model;

namespace SMS.implementation
{
    public class AdminManager : IAdminManager
    {
        ITransactionManager _iTransactionManager = new TransactionManager();
        static String connString = "SERVER=localhost; User Id=root; Password=1234; DATABASE=sms";
        MySqlConnection connection = new MySqlConnection(connString);
        public void CreateAdmin(string firstName, string lastName, string email, string phoneNumber, string pin, string post)
        {
            var staffId = User.GenerateRandomId();
            var admin = new Admin(staffId, firstName, lastName, email, phoneNumber, pin, post);
            // ListOfAdmin.Add(admin);
            // using (var streamWriter = new StreamWriter(AdminFilePath, append: true))
            // {
            //     streamWriter.WriteLine(admin.WriteToFIle());
            // }

            try
            {
                using (var connection = new MySqlConnection(connString))
                {
                    connection.Open();
                    var queryCreateAdmin =
                        $"Insert into admin (staffId, firstname, lastname, email, phonenumber, pin, post) values ('{staffId}','{firstName}','{lastName}','{email}','{phoneNumber}','{pin}','{post}')";
                    var command = new MySqlCommand(queryCreateAdmin, connection);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                // ignored
            }
            Console.WriteLine($"Dear {firstName}, Registration Successful! \nYour Staff Identity Number is {admin.StaffId}, \nKeep it Safe.\n");
        }
        public void DeleteAdmin(string staffId)
        {
            var admin = GetAdmin(staffId);
            // Console.WriteLine(admin != null ? $"{admin.FirstName} {admin.LastName} Successfully deleted. " : "User not found.");
            if (admin != null)
            {
                try
                {
                    var deleteSuccesMsg = $"{admin.FirstName} {admin.LastName} Successfully deleted. ";
                    using (var command = new MySqlCommand($"DELETE From admin WHERE StaffId = '{staffId}'", connection))
                    {
                        connection.Close();
                        connection.Open();
                        var reader = command.ExecuteNonQuery();
                        System.Console.WriteLine(deleteSuccesMsg);
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
                Console.WriteLine("User not found.");
            }
        }
        public Admin GetAdmin(string staffId)
        {
            Admin admin = null;
            try
            {
                using (var command = new MySqlCommand($"select * From admin WHERE staffId = '{staffId}'", connection))
                {
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        admin = new Admin(reader["staffId"].ToString().ToUpper(), reader["firstName"].ToString(), reader["lastName"].ToString(), reader["email"].ToString(), reader["phonenumber"].ToString(), reader["Pin"].ToString(), reader["post"].ToString());
                        // Console.WriteLine($"{reader["id"]}  {reader["name"]}\t\t{reader["email"]}\t\t{reader["age"]}");
                    }
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                // return null;
            }
            return admin is not null && admin.StaffId.ToUpper() == staffId.ToUpper() ? admin : null;
        }
        public void GetAllAdmin()
        {
            try
            {
                using (var command = new MySqlCommand("select * From admin", connection))
                {
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        // Console.WriteLine($"{reader["id"]}  {reader["firstname"]}\t\t{reader["lastname"]}\t\t{reader["email"]}\t\t{reader["phonenumber"]}\t\t{reader["post"]}");
                        Console.WriteLine($"{reader["id"]}\t{reader["staffId"].ToString()}\t{reader["firstName"].ToString()}\t{reader["lastName"].ToString()}\t{reader["email"].ToString()}\t{reader["phonenumber"].ToString()}\t{reader["Pin"].ToString()}\t{reader["post"].ToString()}");
                        // Console.WriteLine($"{reader["id"]}  {reader["name"]}\t\t{reader["email"]}\t\t{reader["age"]}");
                    }
                }
            }
            catch (System.Exception)
            {
                // ignored
            }
        }
        public Admin GetAdmin(string staffId, string email)
        {
            Admin admin = null;
            try
            {
                using (var command = new MySqlCommand($"select * From staffs WHERE email = '{email}'", connection))
                {
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        admin = new Admin(reader["id"].ToString(), reader["firstName"].ToString(), reader["lastName"].ToString(), reader["email"].ToString(), reader["phonenumber"].ToString(), reader["pin"].ToString(), reader["post"].ToString());
                    }
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                // return null;
            }
            return admin is not null && admin.Email.ToUpper() == email.ToUpper() ? admin : null;
        }

        public Admin Login(string staffId, string pin)
        {
            Admin admin = null;
            try
            {
                using (var command = new MySqlCommand($"select * From admin WHERE StaffId = '{staffId}'", connection))
                {
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        admin = new Admin(reader["staffId"].ToString(), reader["firstName"].ToString(), reader["lastName"].ToString(), reader["email"].ToString(), reader["phonenumber"].ToString(), reader["Pin"].ToString(), reader["post"].ToString());
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

            return admin is not null && admin.StaffId.ToUpper() == staffId.ToUpper() && admin.Pin == pin ? admin : null;
        }
        public void UpdateAdmin(string staffId, string firstName, string lastName, string phoneNumber)
        {
            var admin = GetAdmin(staffId);
            if (admin != null)
            {
                try
                {
                    using (var connection = new MySqlConnection(connString))
                    {
                        var SuccesMsg = $"{admin.StaffId} Updated Successfully. ";
                        connection.Open();
                        var queryUpdateA = $"Update admin SET firstname = '{firstName}', lastName = '{lastName}'";
                        var command = new MySqlCommand(queryUpdateA, connection);
                        command.ExecuteNonQuery();
                        System.Console.WriteLine(SuccesMsg);

                    }
                }
                catch (System.Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }

        public void CreateDataBaseTable()
        {
            // staffId, firstName, lastName, email, phoneNumber, pin, post
            var AdminQuery = "CREATE TABLE attendant (ID int auto_increment NOT NULL, StaffId VARCHAR (25) NOT NULL UNIQUE ,FirstName varchar(255) NOT NULL , LastName varchar(255) NOT NULL , Email varchar(100) NOT NULL UNIQUE, PhoneNumber VARCHAR (25) NOT NULL UNIQUE, Pin VARCHAR (50) DEFAULT '0000', Post VARCHAR (50) DEFAULT 'Attendant', primary Key(id,StaffId))";
            try
            {
                using (var command = new MySqlCommand(AdminQuery, connection))
                {
                    connection.Open();
                    var result = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // ignored
            }


            // var AdminQuery = "CREATE TABLE Transaction (ID int auto_increment NOT NULL, Barcode VARCHAR (50) NOT NULL UNIQUE, productname varchar(255) NOT NULL , price DECIMAL(15,2) NOT NULL , productquantity int NOT NULL , primary Key(id, Barcode))";
            // try
            // {
            //     using (var command = new MySqlCommand(AdminQuery, connection))
            //     {
            //         connection.Open();
            //         var result = command.ExecuteNonQuery();
            //     }
            // }
            // catch (Exception ex)
            // {
            //     // ignored
            // }

            // var AttendantQuery = "CREATE TABLE IF NOT EXISTS attendant (ID int auto_increment, Name varchar(255),Position VARCHAR (250) DEFAULT 'worker', Email varchar(255),Age int ,PhoneNumber VARCHAR (100) UNIQUE, primary Key(id))";
            // try
            // {
            //     using (MySqlCommand command = new MySqlCommand(AttendantQuery, connection))
            //     {
            //         connection.Open();
            //         var result = command.ExecuteNonQuery();
            //     }
            // }
            // catch (Exception ex) { }


            // var ProductQuery = "CREATE TABLE IF NOT EXISTS product (ID int auto_increment, Name varchar(255),Position VARCHAR (250) DEFAULT 'worker', Email varchar(255),Age int ,PhoneNumber VARCHAR (100) UNIQUE, primary Key(id))";
            // try
            // {
            //     using (MySqlCommand command = new MySqlCommand(ProductQuery, connection))
            //     {
            //         connection.Open();
            //         var result = command.ExecuteNonQuery();
            //     }
            // }
            // catch (Exception ex) { }


            // var TransactionQuery = "CREATE TABLE IF NOT EXISTS transaction (ID int auto_increment, Name varchar(255),Position VARCHAR (250) DEFAULT 'worker', Email varchar(255),Age int ,PhoneNumber VARCHAR (100) UNIQUE, primary Key(id))";
            // try
            // {
            //     using (MySqlCommand command = new MySqlCommand(TransactionQuery, connection))
            //     {
            //         connection.Open();
            //         var result = command.ExecuteNonQuery();
            //     }
            // }
            // catch (Exception ex) { }


        }
    }
}