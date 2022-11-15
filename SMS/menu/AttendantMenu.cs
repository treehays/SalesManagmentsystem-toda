
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
    public void DeleteProduct()
    {
        Console.Write("\tEnter the Barcode of the Product to be deleted: ");
        var barCode = Console.ReadLine();
        _iProductManager.DeleteProduct(barCode);
    }
    public void LoginAttendantMenu()
    {
        Console.WriteLine("\nWelcome.\nEnter your Staff ID and Password to login ");
        Console.Write("\tStaff ID: ");
        var staffId = "APT899298";//Console.ReadLine();
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
            Console.WriteLine("\tEnter 1 to Record Sales.\n\tEnter 2 to view all products.\n\tEnter 3 to Update My Details. \n\tEnter 4 to View history.\n\tEnter 5 to Logout.\n\tEnter 0 to Close.");
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
                MakeProductPayment();
                AttendantSubMenu(attendant);
            }
            else if (choice == 2)
            {
                Console.WriteLine("\nID\tPRODUCT NAME\tBARCODE\t\tPRICE\t\tQTY\t");
                _iProductManager.ViewAllProduct();
            }
            else if (choice == 3)
            {
                // Update detail
                UpdateAttendantDetails(attendant);
            }
            else if (choice == 4)
            {
                //View Transaction History
                // View Sales Sales Records
                Console.WriteLine("\nID\tSTAFF\tFIRST NAME\tLAST NAME\tEMAIL\tPHONE NO");

                _iTransactionManager.GetAllTransactions();
            }
            else if (choice == 5)
            {
                // logout
                // LoginAttendantMenu();
                var mainMenu = new MainMenu();
                mainMenu.LoginMenu();
            }
        } while (choice != 0);
    }
    public void UpdateAttendantDetails(Attendant attendant)
    {
        Console.WriteLine("\nWelcome.\nEnter D");
        Console.Write("First Name: ");
        var firstName = Console.ReadLine();
        Console.Write("Last Name: ");
        var lastName = Console.ReadLine();
        Console.Write("Phone Number: ");
        var phoneNumber = Console.ReadLine();
        _iAttendantManager.UpdateAttendant(attendant.StaffId, firstName, lastName, phoneNumber);

    }
    public void MakeProductPayment()
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
        Console.WriteLine($"Amount to be Paid: {quantity * product.Price}");
        Console.Write("Cash Tender: ");
        decimal cashTender;
        while (!decimal.TryParse(Console.ReadLine(), out cashTender))
        {
            Console.WriteLine("wrong input.. Try again.");
        }
        _iTransactionManager.CreateTransaction(barCode, quantity, customerId, cashTender);
    }
}
