
using MySql.Data.MySqlClient;
using SMS.interfaces;
using SMS.model;

public class AttendantManager : IUserManager
{
    private readonly static String ConnString = "SERVER=localhost; User Id=root; Password=1234; DATABASE=sms";
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
                    $"Insert into user (staffId, firstName, lastname, email, phonenumber, pin, userRole) values ('{staffId}','{firstName}','{lastName}','{email}','{phoneNumber}','{pin}','{userRole}')";
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
        Console.WriteLine($"Attendant Creation was Successful! \nThe Staff Identity Number is {user.StaffId} and pint {pin}, \nKeep it Safe.");
    }
    public void DeleteUser(string staffId)
    {
        var user = GetUser(staffId);
        if (user != null)
        {
            try
            {
                using (var connection = new MySqlConnection(ConnString))
                {
                    var deleteSuccessMsg = $"{user.FirstName} {user.LastName} Successfully deleted. ";
                    connection.Open();
                    using (var command = new MySqlCommand($"DELETE From user WHERE StaffId = '{staffId.Trim()}' and userRole = 2", connection))
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
            Console.WriteLine("Attendant not found.");
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
                using (var command = new MySqlCommand($"SELECT * From user WHERE staffId = '{staffId.Trim()}' and userRole = 2", connection))
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
    public User GetUser(string staffId, string email)
    {
        User user = null;
        try
        {
            using (var connection = new MySqlConnection(ConnString))
            {
                connection.Open();
                using (var command = new MySqlCommand($"SELECT * From user WHERE email = '{email.Trim()}' and userRole = 2", connection))
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
    public User Login(string staffId, string pin)
    {
        User user = null;
        try
        {
            using (var connection = new MySqlConnection(ConnString))
            {
                connection.Open();
                using (var command = new MySqlCommand($"SELECT * From user WHERE StaffId = '{staffId.Trim()}' and userRole = 2", connection))
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
        return user is not null && user.StaffId.ToUpper() == staffId.ToUpper() && user.Pin == pin ? user : null;
    }
    public void UpdateUserPassword(string staffId, string pin)
    {
        try
        {
            using (var connection = new MySqlConnection(ConnString))
            {
                var successMsg = $"password successfully updated. ";
                connection.Open();
                var queryUpdateA = $"Update user SET pin = '{pin}'where staffId = '{staffId.Trim()}'";
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
        var user = GetUser(staffId.Trim());
        if (user != null)
        {
            try
            {
                using (var connection = new MySqlConnection(ConnString))
                {
                    var successMsg = $"{user.StaffId} Updated Successfully. ";
                    connection.Open();
                    var queryUpdateA = $"Update user SET firstname = '{firstName}', lastName = '{lastName}' where staffId = '{staffId}'";
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
        else
        {
            Console.WriteLine("Attendant not found.");
        }
    }
    public void GetAllUser()
    {
        try
        {
            using (var connection = new MySqlConnection(ConnString))
            {
                connection.Open();
                using (var command = new MySqlCommand("SELECT * From user where userRole = 2", connection))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["staffID"]}\t{reader["firstName"]}\t{reader["lastName"]}\t{reader["email"]}\t{reader["phonenumber"]}\t{reader["pin"]}\t{reader["userRole"]}");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    // public void GetAllUser()
    // {
    //     throw new NotImplementedException();
    // }
}