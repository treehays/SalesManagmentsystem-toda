using SMS.interfaces;
using SMS.model;

public class AdminMenu
{
    IUserManager _iAdminManager = new AdminManager();
    IUserManager _iAttendantManager = new AttendantManager();
    IProductManager _iProductManager = new ProductManager();
    ITransactionManager _iTransactionManager = new TransactionManager();
    private int _choice;



    public void RegisterAdminPage()
    {
        Console.WriteLine("\n\tHome >> Register >> Admin");
        Console.Write("\tEmail: ");
        var email = Console.ReadLine();
        var admin = _iAdminManager.GetUser(email);
        if (admin == null)
        {
            Console.Write("\tFirst name: ");
            var firstName = Console.ReadLine();
            Console.Write("\tLast name: ");
            var lastName = Console.ReadLine();
            Console.Write("\tPhone Number: ");
            var phoneNumber = Console.ReadLine();
            Console.Write("\tpin: ");
            var pin = Console.ReadLine();
            // Console.Write("\tUser Role: ");
            var userRole = 1;//int.Parse(Console.ReadLine());
            _iAdminManager.CreateUser(firstName, lastName, email, phoneNumber, pin, userRole);

        }
        else
        {
            Console.WriteLine("Email already exist...");
        }
        var mainMenu = new MainMenu();
        mainMenu.LoginMenu();
    }


    // private void LoginAdminMenu()
    // {
    //     Console.WriteLine("\tWelcome.\n\tEnter your Staff ID and Password to login ");
    //     Console.Write("\tStaff ID: ");
    //     var staffId = Console.ReadLine();
    //     Console.Write("\tPin: ");
    //     var pin = Console.ReadLine();
    //     // staffId = "ALD841804"; 
    //     // pin = "1234";
    //     var user = _iAdminManager.Login(staffId, pin);
    //     if (user != null)
    //     {
    //         Console.WriteLine($"Welcome {user.FirstName}, you've successfully Logged in!");
    //         AdminSubMenu(user);
    //     }
    //     else
    //     {
    //         Console.WriteLine("\nWrong Staff ID or Password!.");
    //         var mainMenu = new MainMenu();
    //         mainMenu.LoginMenu();
    //     }
    // }



    public void AdminSubMenu(User user)
    {
        // while (true)
        // {
        // int choice;
        // Console.Clear();
        Console.WriteLine(@"

################################################################################
####>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>####
####________________________________________________________________________####
####    Welcome to AZ Sales Management System. Enter valid option.          ####
####------------------------------------------------------------------------####
####>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>####
################################################################################");
        Console.WriteLine("\nHome >> Admin >>");
        // Console.WriteLine("\nAZ Sales Management System. \nEnter valid option.");
        Console.WriteLine("\tEnter 1 to Manage Attendant.\n\tEnter 2 to Manage Products.\n\tEnter 3 to Manage Inventory.  \n\tEnter 4 to View or Download sales Records.\n\tEnter 5 to Update Profile. \n\tEnter 6 to Update Password.\n\tEnter 7 to check Wallet Balance. \n\tEnter 8 to Logout.\n\tEnter 0 to Close.");
        bool chk;
        do
        {
            Console.Write("Enter Operation No: ");
            chk = int.TryParse(Console.ReadLine(), out _choice);
            Console.WriteLine(chk ? "" : "Invalid Input.");
        } while (!chk);

        switch (_choice)
        {
            case 0:
                //close program
                // System.Console.WriteLine("seen");
                // MainMenu.GoodBye();
                Console.WriteLine("Closing...");
                break;
            case 1:
                // Manage Attendant
                ManageAttendantSubMenu(user);

                break;
            case 2:
                // Manage Products 
                ManageProductSubMenu(user);

                break;
            case 3:
                // Manage Inventory
                ManageInventorySubMenu(user);
                break;
            case 4:
                // View Sales Record
                ViewSalesRecord(user);
                break;
            case 5:
                // Update detail
                UpdateAdminDetails(user);
                break;
            case 6:
                // Update password
                UpdateAdminPassword();
                break;
            case 7:
                // Check Wallet Balance
                Console.WriteLine($"Booked Balance: {_iTransactionManager.CalculateTotalSales()}");
                AdminSubMenu(user);
                break;
            case 8:
                // logout
                var mainMenu = new MainMenu();
                mainMenu.LoginMenu();
                break;
            default:
                break;
        }

        // break;
        // }
    }


    private void ManageAttendantSubMenu(User user)
    {
        while (true)
        {
            Console.WriteLine("\n...>> Admin >> Manage Attendants >>");
            // Console.WriteLine("\nAZn Sales Management System. \nEnter valid option.");
            Console.WriteLine("\tEnter 1 to Add new attendant.\n\tEnter 2 to view an attendant details.\n\tEnter 3 to View all attendants.\n\tEnter 4 to Update Attendant profile.\n\tEnter 5 to Reset Attendant password.  \n\tEnter 6 to Delete Attendant.\n\tEnter 7 to Logout.\n\tEnter 8 to go back \n\tEnter 0 to Close.");
            bool chk;
            do
            {
                Console.Write("Enter Operation No: ");
                chk = int.TryParse(Console.ReadLine(), out _choice);
                Console.WriteLine(chk ? "" : "Invalid Input.");
            } while (!chk);

            switch (_choice)
            {
                case 0:
                    //close
                    Console.WriteLine("Closed.");
                    MainMenu.GoodBye();
                    return;
                // break;
                case 1:
                    // Add new Attendant
                    var attendantMenu = new AttendantMenu();
                    attendantMenu.RegisterAttendantPage();
                    continue;
                case 2:
                    //view for attendant
                    ViewAnAttendant(user);
                    continue;
                case 3:
                    //view all attendant
                    Console.WriteLine("\nID\tSTAFF\tFIRST NAME\tLAST NAME\tEMAIL\tPHONE NO");
                    _iAttendantManager.GetAllUser();
                    continue;
                case 4:
                    //update attendant profile
                    UpdateAttendantDetails(user);
                    continue;
                case 5:
                    // reset attendant password
                    ResetAttendantPassword(user);
                    continue;
                case 6:
                    // Delete Attendants
                    DeleteAttendantMenu();
                    continue;
                case 7:
                    // logout
                    var mainMenu = new MainMenu();
                    mainMenu.LoginMenu();
                    break;
                case 8:
                    AdminSubMenu(user);
                    break;
                default:
                    continue;
            }

            break;
        }
    }


    private void ManageProductSubMenu(User user)
    {
        while (true)
        {
            Console.WriteLine("\nAZ Sales Management System. \nEnter valid option.");
            Console.WriteLine("...>> Admin >> Manage Product >>");
            Console.WriteLine("Enter 1 to Add a product. \nEnter 2 to Modify products detail. \nEnter 3 to View all Products. \nEnter 4 to Delete Product.\nEnter 5 to Go Back to Admin Menu\nEnter 6 to Logout.\nEnter 0 to Close.");

            bool chk;
            do
            {
                chk = int.TryParse(Console.ReadLine(), out _choice);
                Console.WriteLine(chk ? "" : "Invalid Input.");
            } while (!chk);

            switch (_choice)
            {
                case 0:
                    Console.WriteLine("Closed.");
                    // return;
                    break;
                case 1:
                    // Add Product
                    AddProduct();
                    continue;
                case 2:
                    // Modify product
                    Console.WriteLine("Modify Product Details.");
                    UpdateProductDetails();
                    continue;
                case 3:
                    // View All products
                    Console.WriteLine("\nID\tPRODUCT NAME\tBARCODE\tPRICE\tQTY\t");
                    _iProductManager.ViewAllProduct();
                    continue;
                case 4:
                    DeleteProductMenu();
                    continue;
                case 5:
                    AdminSubMenu(user);
                    break;
                case 6:
                    // logout
                    var mainMenu = new MainMenu();
                    mainMenu.LoginMenu();
                    break;
                default:
                    continue;
            }

            break;
        }
    }

    private void ManageInventorySubMenu(User user)
    {
        while (true)
        {
            Console.WriteLine("\nAZ Sales Management System. \nEnter valid option.");
            Console.WriteLine("...>> Admin >> Manage Inventory >>");
            Console.WriteLine("Enter 1 to Restock product. \nEnter 2 to View all products expected to be Reordered. \nEnter 3 to view Product lower than certain number.\nEnter 4 to Go Back to Admin Menu\nEnter 5 to Logout.\nEnter 0 to Close.");

            bool chk;
            do
            {
                chk = int.TryParse(Console.ReadLine(), out _choice);
                Console.WriteLine(chk ? "" : "Invalid Input.");
            } while (!chk);

            switch (_choice)
            {
                case 0:
                    Console.WriteLine("Closed.");
                    // return;
                    break;
                case 1:
                    // Restock product.
                    Console.WriteLine("Restock Product.");
                    RestockProduct();
                    continue;
                case 2:
                    // View all products expected to be Reordered. .
                    Console.WriteLine("List of products.");
                    SortedProductBy();
                    continue;
                case 3:
                    // view Product lower than certain number.
                    continue;
                case 4:
                    // Go Back to Admin Menu
                    AdminSubMenu(user);
                    break;
                case 5:
                    // logout
                    var mainMenu = new MainMenu();
                    mainMenu.LoginMenu();
                    break;
                default:
                    continue;
            }

            break;
        }
    }
    private void ViewAnAttendant(User user)
    {
        Console.Write("Staff id of the attendant : ");
        var staffId = Console.ReadLine();
        var attendant = _iAttendantManager.GetUser(staffId);
        if (attendant != null)
        {
            Console.WriteLine($"Staff ID: {attendant.StaffId}");
            Console.WriteLine($"Name: {attendant.FirstName} {attendant.LastName}");
            Console.WriteLine($"Email: {attendant.Email}");
            Console.WriteLine($"Phone Number: {attendant.PhoneNumber}");
            Console.WriteLine($"Post: {attendant.UserRole}");
        }
        else
        {
            Console.WriteLine("Attendant not found.");
            ManageAttendantSubMenu(user);
        }
    }

    private void ResetAttendantPassword(User user)
    {
        Console.WriteLine("Reset Attendant password.");
        Console.Write("Staff id of the attendant : ");
        var staffId = Console.ReadLine();
        var attendant = _iAttendantManager.GetUser(staffId);
        if (attendant != null)
        {
            Console.Write("Enter new Password: ");
            var pin = Console.ReadLine();
            _iAttendantManager.UpdateUserPassword(staffId, pin);
        }
        else
        {
            Console.WriteLine("Attendant not found.");
            ManageAttendantSubMenu(user);
        }
    }

    private void UpdateAttendantDetails(User user)
    {
        Console.WriteLine("\nWelcome.");
        Console.Write("Staff id of the attendant to be updated: ");
        var staffId = Console.ReadLine();
        var attendant = _iAttendantManager.GetUser(staffId);
        if (attendant != null)
        {
            Console.Write("First Name: ");
            var firstName = Console.ReadLine();
            Console.Write("Last Name: ");
            var lastName = Console.ReadLine();
            Console.Write("Phone Number: ");
            var phoneNumber = Console.ReadLine();
            _iAttendantManager.UpdateUser(attendant.StaffId, firstName, lastName, phoneNumber);
        }
        else
        {
            Console.WriteLine("Attendant not found.");
            ManageAttendantSubMenu(user);
        }

    }

    private void DeleteAttendantMenu()
    {
        Console.Write("Enter Staff ID of the Attendant.");
        var staffId = Console.ReadLine();
        _iAttendantManager.DeleteUser(staffId);
    }

    private void UpdateAdminDetails(User user)
    {
        Console.Write("Enter StaffId: ");
        var staffId = Console.ReadLine().Trim();
        Console.Write("Enter new admin first Name: ");
        var firstName = Console.ReadLine();
        Console.Write("Enter new admin last Name: ");
        var lastName = Console.ReadLine();
        Console.Write("Enter new PhoneNumber: ");
        var phoneNumber = Console.ReadLine();
        _iAdminManager.UpdateUser(staffId, firstName, lastName, phoneNumber);
        Console.WriteLine($"{staffId} successfully updated. ");
    }

    private void UpdateAdminPassword()
    {
        Console.Write("Enter StaffId: ");
        var staffId = Console.ReadLine().Trim();
        Console.Write("Enter Old Password: ");
        var pin = Console.ReadLine();
        var user = _iAdminManager.Login(staffId, pin);
        if (user != null)
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
            _iAdminManager.UpdateUserPassword(staffId, pin);
            AdminSubMenu(user);
        }
        else
        {
            Console.WriteLine("\nWrong staff Id or old Password!.");
            AdminSubMenu(user);
        }
    }

    private void ViewSalesRecord(User user)
    {
        bool chec = false;
        Console.WriteLine("\n\tEnter 1 to view on Console.\n\tEnter 2 to generate report on SpreedSheet..\n\tEnter 3 to view report on browser.");
        do
        {
            Console.Write("Enter Operation No: ");
            chec = int.TryParse(Console.ReadLine(), out _choice);
            Console.WriteLine(chec ? "" : "Invalid Input.");
        } while (!chec);

        switch (_choice)
        {
            case 1:
                Console.WriteLine("\nID\t TRANS. DATE \t\t\tCUSTOMER NAME\tAMOUNT\tBARCODE\tRECEIPT NO\tQTY\tTOTAL\tBALANCE");
                _iTransactionManager.GetAllTransactions();
                break;
            case 2:
                {
                    Console.WriteLine("Generating the report to spreed sheet....");
                    var datedNow = FileDate();
                    _iTransactionManager.ViewTransactionAsExcel(datedNow);
                    AdminSubMenu(user);
                    break;
                }
            case 3:
                {
                    Console.WriteLine("Generating the report to your browser....");
                    var datedNow = FileDate();
                    _iTransactionManager.ViewTransactionAsHtml(datedNow);
                    AdminSubMenu(user);
                    break;
                }
        }

    }

    private void AddProduct()
    {
        Console.Write("Product Name: ");
        var productName = Console.ReadLine();
        Console.Write("Barcode(Product ID): ");
        var barCode = Console.ReadLine();
        Console.Write("Price: ");
        decimal price;
        while (!decimal.TryParse(Console.ReadLine(), out price))
        {
            Console.WriteLine("wrong input.. Try again.");
        }
        Console.Write("Quantity: ");

        int productQuantity;
        while (!int.TryParse(Console.ReadLine(), out productQuantity))
        {
            Console.WriteLine("wrong input.. Try again.");
        }
        _iProductManager.CreateProduct(barCode, productName, price, productQuantity);
    }

    private void SortedProductBy()
    {
        Console.WriteLine("\nID\tPRODUCT NAME\tBARCODE\tPRICE\tQTY\t");
        Console.Write("Enter reorder point: ");
        var quantity = int.Parse(Console.ReadLine());
        _iProductManager.SortedProductByQuantity(quantity);
    }

    private void RestockProduct()
    {
        Console.Write("Enter product Barcode: ");
        var barCode = Console.ReadLine().Trim();
        var product = _iProductManager.GetProduct(barCode);
        if (product != null)
        {
            Console.Write("How many to be added: ");
            var quantity = int.Parse(Console.ReadLine());
            _iProductManager.RestockProduct(barCode, quantity);
        }
        else
        {
            Console.WriteLine($"{barCode} not found");
        }
    }

    private void UpdateProductDetails()
    {
        Console.Write("Enter product Barcode: ");
        var barCode = Console.ReadLine().Trim();
        var product = _iProductManager.GetProduct(barCode);
        if (product != null)
        {
            Console.Write("Enter new product Name: ");
            var productName = Console.ReadLine();
            Console.Write("Enter new price Name: ");
            var price = decimal.Parse(Console.ReadLine());
            // Console.Write("Enter new quantity: ");
            // int quantity = int.Parse(Console.ReadLine());
            _iProductManager.UpdateProduct(barCode, productName, price);
            Console.WriteLine($"{barCode} successfully updated.");
        }
        else
        {
            Console.WriteLine($"{barCode} not found");
        }
    }

    private void DeleteProductMenu()
    {
        Console.Write("Enter Product BarCode: ");
        var barCode = Console.ReadLine();
        _iProductManager.DeleteProduct(barCode);

    }

    private static string FileDate()
    {
        var dateSave = string.Join("", DateTime.Now.ToShortDateString().Split('/'));
        var dateSave1 = string.Join("", DateTime.Now.ToShortTimeString().Split(':')).Remove(4);
        return dateSave + dateSave1;
    }
}

