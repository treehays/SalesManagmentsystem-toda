
using SMS.Enum;
using SMS.interfaces;
using SMS.model;

public class AttendantMenu
{
    IUserManager _iAttendantManager = new AttendantManager();
    ITransactionManager _iTransactionManager = new TransactionManager();
    IProductManager _iProductManager = new ProductManager();
    public void RegisterAttendantPage()
    {
        Console.WriteLine("\nRegister Attendant..");
        Console.Write("\tEmail: ");
        var email = Console.ReadLine();
        var attendant = _iAttendantManager.GetUser(email);
        if (attendant == null)
        {
            Console.Write("\tFirst name: ");
            var firstName = Console.ReadLine();
            Console.Write("\tLast name: ");
            var lastName = Console.ReadLine();
            Console.Write("\tPhone Number: ");
            var phoneNumber = Console.ReadLine();
            Console.Write("\tpin: ");
            var pin = Console.ReadLine();
            // Console.Write("\tuser role: ");
            var userRole = (int)Staffs.Attendant;//Convert.ToInt32(Console.ReadLine());
            _iAttendantManager.CreateUser(firstName, lastName, email, phoneNumber, pin, userRole);
        }
    }

    // private void LoginAttendantMenu()
    // {
    //     Console.WriteLine("\nWelcome.\nEnter your Staff ID and Password to login ");
    //     Console.Write("\tStaff ID: ");
    //     var staffId = Console.ReadLine();
    //     Console.Write("\tPin: ");
    //     var pin = Console.ReadLine();
    //     // staffId = "APD310646"; 
    //     // pin = "pin";
    //     var attendant = _iAttendantManager.Login(staffId, pin);
    //     if (attendant != null)
    //     {
    //         Console.WriteLine($"Welcome {attendant.FirstName}, you've successfully Logged in!");
    //         AttendantSubMenu(attendant);
    //     }
    //     else
    //     {
    //         Console.WriteLine("Wrong Email or Password!.");
    //     }
    // }

    public void AttendantSubMenu(User user)
    {
        int choice;
        do
        {
            Console.WriteLine("\n...Logged >> Attendant >>");
            Console.WriteLine("AZ Sales Management System. \nEnter valid option.");
            Console.WriteLine("\tEnter 1 to Record Sales.\n\tEnter 2 to view all products.\n\tEnter 3 to Update Profile.\n\tEnter 4 to change password \n\tEnter 5 to View Sales history.\n\tEnter 6 to Logout.\n\tEnter 0 to Close.");
            bool chk;
            do
            {
                Console.Write("Enter Operation No: ");
                chk = int.TryParse(Console.ReadLine(), out choice);
                Console.WriteLine(chk ? "" : "Invalid Input.");
            } while (!chk);
            switch (choice)
            {
                case 1:
                    // Record Sales
                    _iProductManager.InventoryQuantityAlert();
                    MakeProductPayment(user);
                    AttendantSubMenu(user);
                    break;
                case 2:
                    //view all products
                    Console.WriteLine("\nID\tPRODUCT NAME\tBARCODE\t\tPRICE\t\tQTY\t");
                    _iProductManager.ViewAllProduct();
                    break;
                case 3:
                    // Update profile
                    UpdateAttendantDetails(user);
                    break;
                case 4:
                    //change password
                    UpdateAttendantPassword(user);
                    break;
                case 5:
                    // View Sales Sales Records
                    Console.WriteLine("\nID\tSTAFF\tFIRST NAME\tLAST NAME\tEMAIL\tPHONE NO");

                    _iTransactionManager.GetAllTransactions();
                    break;
                case 6:
                    {
                        // logout
                        var mainMenu = new MainMenu();
                        mainMenu.LoginMenu();
                        break;
                    }
            }
        } while (choice != 0);
    }

    private void UpdateAttendantPassword(User user)
    {
        Console.Write("Enter Old Password: ");
        var pin = Console.ReadLine();
        if (user.Pin == pin)
        {
            var isSame = true;
            while (isSame)
            {
                Console.WriteLine("\nEnter a matching Password.");
                Console.Write("Enter new Password: ");
                pin = Console.ReadLine();
                Console.Write("Re-Enter new Password: ");
                var rePin = Console.ReadLine();
                isSame = pin != rePin;
            }
            _iAttendantManager.UpdateUserPassword(user.StaffId, pin);
            AttendantSubMenu(user);
        }
        else
        {
            Console.WriteLine("\nWrong staff Id or old Password!.");
            AttendantSubMenu(user);
        }
    }

    private void UpdateAttendantDetails(User user)
    {
        Console.WriteLine("\nWelcome.");
        Console.Write("First Name: ");
        var firstName = Console.ReadLine();
        Console.Write("Last Name: ");
        var lastName = Console.ReadLine();
        Console.Write("Phone Number: ");
        var phoneNumber = Console.ReadLine();
        _iAttendantManager.UpdateUser(user.StaffId, firstName, lastName, phoneNumber);

    }

    private void MakeProductPayment(User user)
    {
        Console.WriteLine("...Logged >> Attendant >> Payment Page");
        Console.Write("CustomerName: ");
        var customerId = Console.ReadLine();
        Console.Write("Enter Product Barcode: ");
        var barCode = Console.ReadLine();
        Console.Write("Quantity: ");
        int quantity;
        while (!int.TryParse(Console.ReadLine(), out quantity))
        {
            Console.WriteLine("wrong input.. Try again.");
        }
        var product = _iProductManager.GetProduct(barCode);
        if (product.ProductQuantity >= quantity)
        {
            Console.WriteLine($"Amount to be Paid: {quantity * product.Price}");
            Console.Write("Cash Tender: ");
            decimal cashTender;
            while (!decimal.TryParse(Console.ReadLine(), out cashTender))
            {
                Console.WriteLine("wrong input.. Try again.");
            }
            _iTransactionManager.CreateTransaction(user.StaffId + "\\" + user.FirstName, barCode, quantity, customerId, cashTender);
        }
        else
        {
            Console.WriteLine($"Out of stock!!!. \nStock remaining: {product.ProductQuantity}");
        }

    }
}
