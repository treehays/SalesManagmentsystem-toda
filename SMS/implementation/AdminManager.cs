
using MySql.Data.MySqlClient;
using SMS.interfaces;
using SMS.model;
public class AdminManager : IUserManager
{
    readonly ITransactionManager _iTransactionManager = new TransactionManager();
    private static String ConnString = "SERVER=localhost; User Id=root; Password=1234; DATABASE=sms";
    public void CreateUser(string firstName, string lastName, string email, string phoneNumber, string pin, int userRole)
    {
        var staffId = User.GenerateRandomId();
        var user = new User(staffId, firstName, lastName, email, phoneNumber, pin, userRole);
        try
        {
            using (var connection = new MySqlConnection(ConnString))
            {
                connection.Open();
                var queryCreate =
                    $"Insert into user (staffId, firstname, lastname, email, phoneNumber, pin, UserRole) values ('{staffId}','{firstName}','{lastName}','{email}','{phoneNumber}','{pin}','{userRole}')";

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
        Console.WriteLine($"Dear {firstName}, Registration Successful! \nYour Staff Identity Number is {user.StaffId}, \nKeep it Safe.\n");
    }
    public void DeleteUser(string staffId)
    {
        var user = GetUser(staffId);
        if (user != null)
        {
            try
            {
                var deleteSuccessMsg = $"{user.FirstName} {user.LastName} Successfully deleted. ";
                using (var connection = new MySqlConnection(ConnString))
                {
                    connection.Open();
                    using (var command = new MySqlCommand($"DELETE From user WHERE StaffId = '{staffId}'", connection))
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
    public User GetUser(string staffId)
    {
        User user = null;
        try
        {
            using (var connection = new MySqlConnection(ConnString))
            {
                connection.Open();
                using (var command = new MySqlCommand($"select * From user WHERE staffId = '{staffId}'", connection))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        user = new User(reader["staffId"].ToString().ToUpper(), reader["firstName"].ToString(), reader["lastName"].ToString(), reader["email"].ToString(), reader["phonenumber"].ToString(), reader["Pin"].ToString(), Convert.ToInt32(reader["userRole"]));
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return user is not null && user.StaffId.ToUpper() == staffId.ToUpper() ? user : null;
    }
    public void GetAllUser()
    {
        try
        {
            using (var connection = new MySqlConnection(ConnString))
            {
                connection.Open();
                using (var command = new MySqlCommand("select * From user", connection))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["id"]}\t{reader["staffId"].ToString()}\t{reader["firstName"].ToString()}\t{reader["lastName"].ToString()}\t{reader["email"].ToString()}\t{reader["phonenumber"].ToString()}\t{reader["userRole"].ToString()}");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    public User GetUser(string staffId, string email)
    {
        User user = null;
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
                        user = new User(reader["staffId"].ToString(), reader["firstName"].ToString(), reader["lastName"].ToString(), reader["email"].ToString(), reader["phonenumber"].ToString(), reader["Pin"].ToString(), Convert.ToInt32(reader["userRole"]));
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return user is not null && user.Email.ToUpper() == email.ToUpper() ? user : null;
    }
    public int UserRoleById(User user)
    {
        
        if (true)
        {
            
        }
        return 0;
    }

    public User Login(string staffId, string pin)
    {
        User user = null;
        try
        {
            using (var connection = new MySqlConnection(ConnString))
            {
                connection.Open();
                using (var command = new MySqlCommand($"select * From user WHERE StaffId = '{staffId}'", connection))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        user = new User(reader["staffId"].ToString(), reader.GetString(2), reader["lastName"].ToString(), reader["email"].ToString(), reader["phonenumber"].ToString(), reader["Pin"].ToString(), Convert.ToInt32(reader["userRole"]));
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return user is not null && user.StaffId.ToUpper() == staffId.ToUpper() && user.Pin == pin ? user : null;
    }
    public void UpdateUserPassword(string staffId, string pin)
    {
        try
        {
            using (var connection = new MySqlConnection(ConnString))
            {
                const string successMsg = $"password successfully updated. ";
                connection.Open();
                var queryUpdateA = $"Update user SET pin = '{pin}'where staffId = '{staffId}'";
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
    public void UpdateUser(string staffId, string firstName, string lastName, string phoneNumber)
    {
        try
        {
            using (var connection = new MySqlConnection(ConnString))
            {
                var successMsg = $"{staffId} Updated Successfully. ";
                connection.Open();
                var queryUpdateA = $"Update user SET firstName = '{firstName}', lastName = '{lastName}',phoneNumber = '{phoneNumber}' where staffId = '{staffId}'";
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