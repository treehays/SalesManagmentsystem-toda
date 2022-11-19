
public class AttendantMenu
{
    IAttendantManager _iAttendantManager = new AttendantManager();
    ITransactionManager _iTransactionManager = new TransactionManager();
    IProductManager _iProductManager = new ProductManager();
    public void RegisterAttendantPage()
    {
        // Console.WriteLine("\nEnter Valid Details..");
        Console.WriteLine("\nRegister Attendant..");
        Console.Write("\tFirst name: ");
        var firstName = Console.ReadLine();
        Console.Write("\tLast name: ");
        var lastName = Console.ReadLine();
        Console.Write("\tEmail: ");
        var email = Console.ReadLine();
        Console.Write("\tPhone Number: ");
        var phoneNumber = Console.ReadLine();
        Console.Write("\tpin: ");
        var pin = Console.ReadLine();
        Console.Write("\tPost: ");
        var post = Console.ReadLine();
        _iAttendantManager.CreateAttendant(firstName, lastName, email, phoneNumber, pin, post);
    }
    // public void DeleteProduct()
    // {
    //     Console.Write("\tEnter the Barcode of the Product to be deleted: ");
    //     var barCode = Console.ReadLine();
    //     _iProductManager.DeleteProduct(barCode);
    // }
    public void LoginAttendantMenu()
    {
        Console.WriteLine("\nWelcome.\nEnter your Staff ID and Password to login ");
        Console.Write("\tStaff ID: ");
        var staffId = "APD310646";//Console.ReadLine();
        Console.Write("\tPin: ");
        var pin = "pin";//Console.ReadLine();
        var attendant = _iAttendantManager.Login(staffId, pin);
        if (attendant != null)
        {
            Console.WriteLine($"Welcome {attendant.FirstName}, you've successfully Logged in!");
            AttendantSubMenu(attendant);
        }
        else
        {
            Console.WriteLine("Wrong Email or Password!.");
        }
    }
    public void AttendantSubMenu(Attendant attendant)
    {
        int choice;
        do
        {
            // Console.Clear();
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
            if (choice == 1)
            {
                // Record Sales
                MakeProductPayment(attendant);
                AttendantSubMenu(attendant);
            }
            else if (choice == 2)
            {
                //view all products
                Console.WriteLine("\nID\tPRODUCT NAME\tBARCODE\t\tPRICE\t\tQTY\t");
                _iProductManager.ViewAllProduct();
            }
            else if (choice == 3)
            {
                // Update profile
                UpdateAttendantDetails(attendant);
            }
            else if (choice == 4)
            {
                //change password
                UpdateAttendantPassword(attendant);
            }
            else if (choice == 5)
            {
                //View Transaction History
                // View Sales Sales Records
                Console.WriteLine("\nID\tSTAFF\tFIRST NAME\tLAST NAME\tEMAIL\tPHONE NO");

                _iTransactionManager.GetAllTransactions();
            }
            else if (choice == 6)
            {
                // logout
                // LoginAttendantMenu();
                var mainMenu = new MainMenu();
                mainMenu.LoginMenu();
            }
        } while (choice != 0);
    }
    public void UpdateAttendantPassword(Attendant attendant)
    {
        Console.Write("Enter Staffid: ");
        string staffId = Console.ReadLine().Trim();
        Console.Write("Enter Old Password: ");
        string pin = Console.ReadLine();
        attendant = _iAttendantManager.Login(staffId, pin);
        if (attendant != null)
        {
            bool isSame = true;
            while (isSame)
            {
                Console.WriteLine("\nEnter a matching Password.");
                Console.Write("Enter new Password: ");
                pin = Console.ReadLine();
                Console.Write("Re-Enter new Password: ");
                string rePin = Console.ReadLine();
                isSame = pin == rePin ? false : true;
            }
            _iAttendantManager.UpdateAttendantPassword(staffId, pin);
            AttendantSubMenu(attendant);
        }
        else
        {
            Console.WriteLine("\nWrong staff Id or old Password!.");
            var mainMenu = new MainMenu();
            AttendantSubMenu(attendant);
        }
    }

    public void UpdateAttendantDetails(Attendant attendant)
    {
        Console.WriteLine("\nWelcome.");
        Console.Write("First Name: ");
        var firstName = Console.ReadLine();
        Console.Write("Last Name: ");
        var lastName = Console.ReadLine();
        Console.Write("Phone Number: ");
        var phoneNumber = Console.ReadLine();
        _iAttendantManager.UpdateAttendant(attendant.StaffId, firstName, lastName, phoneNumber);

    }
    public void MakeProductPayment(Attendant attendant)
    {
        // Customer Details
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
            _iTransactionManager.CreateTransaction( attendant.StaffId + "\tAttendant Name: " + attendant.FirstName,barCode, quantity, customerId, cashTender);
        }
        else
        {
            System.Console.WriteLine($"Out of stock!!!. \nStock remaining: {product.ProductQuantity}");
        }

    }
}
