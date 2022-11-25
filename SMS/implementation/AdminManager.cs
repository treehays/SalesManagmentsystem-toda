
using MySql.Data.MySqlClient;
using SMS.model;
public class AdminManager : IAdminManager
{
    ITransactionManager _iTransactionManager = new TransactionManager();
    private static String ConnString = "SERVER=localhost; User Id=root; Password=1234; DATABASE=sms";
    public void CreateAdmin(string firstName, string lastName, string email, string phoneNumber, string pin, string post)
    {
        var staffId = User.GenerateRandomId();
        var admin = new Admin(staffId, firstName, lastName, email, phoneNumber, pin, post);
        try
        {
            using (var connection = new MySqlConnection(ConnString))
            {
                connection.Open();
                var queryCreate =
                    $"Insert into admin (staffId, firstname, lastname, email, phoneNumber, pin, post) values ('{staffId}','{firstName}','{lastName}','{email}','{phoneNumber}','{pin}','{post}')";

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
                using (var connection = new MySqlConnection(ConnString))
                {
                    connection.Open();
                    using (var command = new MySqlCommand($"DELETE From admin WHERE StaffId = '{staffId}'", connection))
                    {
                        command.ExecuteNonQuery();
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
            Console.WriteLine("User not found.");
        }
    }
    public Admin GetAdmin(string staffId)
    {
        Admin admin = null;
        try
        {
            using (var connection = new MySqlConnection(ConnString))
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
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return admin is not null && admin.StaffId.ToUpper() == staffId.ToUpper() ? admin : null;
    }
    public void GetAllAdmin()
    {
        try
        {
            using (var connection = new MySqlConnection(ConnString))
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
            using (var connection = new MySqlConnection(ConnString))
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
            using (var connection = new MySqlConnection(ConnString))
            {
                connection.Open();
                using (var command = new MySqlCommand($"select * From admin WHERE StaffId = '{staffId}'", connection))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        admin = new Admin(reader["staffId"].ToString(), reader.GetString(2), reader["lastName"].ToString(), reader["email"].ToString(), reader["phonenumber"].ToString(), reader["Pin"].ToString(), reader["post"].ToString());
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
    public void UpdateAdminPassword(string staffId, string pin)
    {
        try
        {
            using (var connection = new MySqlConnection(ConnString))
            {
                const string successMsg = $"password successfully updated. ";
                connection.Open();
                var queryUpdateA = $"Update admin SET pin = '{pin}'where staffId = '{staffId}'";
                using (var command = new MySqlCommand(queryUpdateA, connection))
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine(successMsg);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    public void UpdateAdmin(string staffId, string firstName, string lastName, string phoneNumber)
    {
        try
        {
            using (var connection = new MySqlConnection(ConnString))
            {
                var successMsg = $"{staffId} Updated Successfully. ";
                connection.Open();
                var queryUpdateA = $"Update admin SET firstName = '{firstName}', lastName = '{lastName}',phoneNumber = '{phoneNumber}' where staffId = '{staffId}'";
                using (var command = new MySqlCommand(queryUpdateA, connection))
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine(successMsg);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}