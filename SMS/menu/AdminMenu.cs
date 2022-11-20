


public class AdminMenu
{
    IAdminManager _iAdminManager = new AdminManager();
    IAttendantManager _iAttendantManager = new AttendantManager();
    IProductManager _iProductManager = new ProductManager();
    ITransactionManager _iTransactionManager = new TransactionManager();
    private int _choice;


    public void AdminSubMenu(Admin admin)
    {
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

                Console.WriteLine("Closing...");
                break;
            case 1:
                // Manage Attendant
                ManageAttendantSubMenu(admin);

                break;
            case 2:
                // Manage Products 
                ManageProductSubMenu(admin);

                break;
            case 3:
                // Manage Inventory
                ManageInventorySubMenu(admin);
                AdminSubMenu(admin);
                break;
            case 4:
                // View Sales Record
                System.Console.WriteLine("\n\tEnter 1 to view on Console.\n\tEnter 2 to generate report on SpreedSheet..\n\tEnter 3 to view report on browser.");
                bool chec;
                do
                {
                    Console.Write("Enter Operation No: ");
                    chec = int.TryParse(Console.ReadLine(), out _choice);
                    Console.WriteLine(chec ? "" : "Invalid Input.");

                } while (!chk);
                if (_choice == 1)
                {
                    Console.WriteLine("\nID\t TRANS. DATE \t\t\tCUSTOMER NAME\tAMOUNT\tBARCODE\tRECEIPT NO\tQTY\tTOTAL\tBALANCE");
                    _iTransactionManager.GetAllTransactions();
                }
                else if (_choice == 2)
                {
                    Console.WriteLine("Generating the report to spreed sheet....");
                     var datedNow = FileDate();
                    _iTransactionManager.ViewTransactionAsExcel(datedNow);
                    AdminSubMenu(admin);
                }
                else if (_choice == 3)
                {
                    Console.WriteLine("Generating the report to your browser....");
                     var datedNow = FileDate();
                    _iTransactionManager.ViewTransactionAsHTML(datedNow);
                    AdminSubMenu(admin);
                }
                // iTransactionManager.GetAllTransactionsAdmin();
                AdminSubMenu(admin);
                break;
            case 5:
                // Update detail
                UpdateAdminDetails();
                AdminSubMenu(admin);
                break;
            case 6:
                // Update password
                UpdateAdminPassword();
                AdminSubMenu(admin);
                break;
            case 7:
                // Check Wallet Balance
                Console.WriteLine($"Booked Balance: {_iTransactionManager.CalculateTotalSales()}");
                AdminSubMenu(admin);
                break;
            case 8:
                // logout
                var mainMenu = new MainMenu();
                mainMenu.LoginMenu();
                break;
            default:
                AdminSubMenu(admin);
                break;
        }
    }


    public void ManageAttendantSubMenu(Admin admin)
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
                // return;
                break;
            case 1:
                // Add new Attendant
                var attendantMenu = new AttendantMenu();
                attendantMenu.RegisterAttendantPage();
                ManageAttendantSubMenu(admin);
                break;
            case 2:
                //view for attendan
                ViewAnAttendant(admin);
                ManageAttendantSubMenu(admin);
                break;
            case 3:
                //view all attendant
                Console.WriteLine("\nID\tSTAFF\tFIRST NAME\tLAST NAME\tEMAIL\tPHONE NO");
                _iAttendantManager.ViewAllAttendants();
                ManageAttendantSubMenu(admin);
                break;
            case 4:
                //update attendant profile
                UpdateAttendantDetails(admin);
                ManageAttendantSubMenu(admin);
                break;
            case 5:
                // reset attendant password
                ResetAttendantPassword(admin);
                ManageAttendantSubMenu(admin);
                break;
            case 6:
                // Delete Attendants
                DeleteAttendantMenu();
                ManageAttendantSubMenu(admin);
                break;
            case 7:
                // logout
                var mainMenu = new MainMenu();
                mainMenu.LoginMenu();
                break;
            case 8:
                AdminSubMenu(admin);
                break;
            default:
                ManageAttendantSubMenu(admin);
                break;
        }
    }


    public void ManageProductSubMenu(Admin admin)
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
                ManageProductSubMenu(admin);
                break;
            case 2:
                // Modify product
                Console.WriteLine("Modify Product Details.");
                UpdateProductDetails();
                ManageProductSubMenu(admin);
                break;
            case 3:
                // View All products
                // iAdminManager.DeleteAdmin();
                Console.WriteLine("\nID\tPRODUCT NAME\tBARCODE\tPRICE\tQTY\t");
                _iProductManager.ViewAllProduct();
                ManageProductSubMenu(admin);
                break;
            case 4:
                DeleteProductMenu();
                ManageProductSubMenu(admin);
                break;
            case 5:
                AdminSubMenu(admin);
                break;
            case 6:
                // logout
                var mainMenu = new MainMenu();
                mainMenu.LoginMenu();
                break;
            default:
                ManageProductSubMenu(admin);
                break;
        }
    }

    public void ManageInventorySubMenu(Admin admin)
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
                ManageInventorySubMenu(admin);
                break;
            case 2:
                // View all products expected to be Reordered. .
                System.Console.WriteLine("List of products.");
                SortedProductBy();
                ManageInventorySubMenu(admin);
                break;
            case 3:
                // view Product lower than certain number.
                ManageInventorySubMenu(admin);
                break;
            case 4:
                // Go Back to Admin Menu
                AdminSubMenu(admin);
                break;
            case 5:
                // logout
                var mainMenu = new MainMenu();
                mainMenu.LoginMenu();
                break;
            default:
                ManageInventorySubMenu(admin);
                break;
        }
    }
    public void RegisterAdminPage()
    {
        Console.WriteLine("\n\tHome >> Register >> Admin");
        // Console.WriteLine("Welcome...");
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
        _iAdminManager.CreateAdmin(firstName, lastName, email, phoneNumber, pin, post);
        var mainMenu = new MainMenu();
        mainMenu.LoginMenu();
    }

    public void LoginAdminMenu()
    {
        Console.WriteLine("\tWelcome.\n\tEnter your Staff ID and Password to login ");
        Console.Write("\tStaff ID: ");
        var staffId = Console.ReadLine();
        Console.Write("\tPin: ");
        var pin = Console.ReadLine();
        // staffId = "ALD841804"; 
        // pin = "1234";
        // // iAdminManager.Login(staffId,pin); waht is this doing not part of the code
        var admin = _iAdminManager.Login(staffId, pin);
        if (admin != null)
        {
            Console.WriteLine($"Welcome {admin.FirstName}, you've successfully Logged in!");
            AdminSubMenu(admin);
        }
        else
        {
            Console.WriteLine("\nWrong Staff ID or Password!.");
            var mainMenu = new MainMenu();
            mainMenu.LoginMenu();
        }
    }

    public void ViewAnAttendant(Admin admin)
    {
        Console.Write("Staff id of the attendant : ");
        var staffId = Console.ReadLine();
        var attendant = _iAttendantManager.GetAttendant(staffId);
        if (attendant != null)
        {
            Console.WriteLine($"Staff ID: {attendant.StaffId}");
            Console.WriteLine($"Name: {attendant.FirstName} {attendant.LastName}");
            Console.WriteLine($"Email: {attendant.Email}");
            Console.WriteLine($"Phone Number: {attendant.PhoneNumber}");
            Console.WriteLine($"Post: {attendant.Post}");
        }
        else
        {
            Console.WriteLine("Attendant not found.");
            ManageAttendantSubMenu(admin);
        }
    }

    public void ResetAttendantPassword(Admin admin)
    {
        Console.WriteLine("Reset Attendant password.");
        Console.Write("Staff id of the attendant : ");
        var staffId = Console.ReadLine();
        var attendant = _iAttendantManager.GetAttendant(staffId);
        if (attendant != null)
        {
            Console.Write("Enter new Password: ");
            string pin = Console.ReadLine();
            _iAttendantManager.UpdateAttendantPassword(staffId, pin);
        }
        else
        {
            Console.WriteLine("Attendant not found.");
            ManageAttendantSubMenu(admin);
        }
    }
    public void UpdateAttendantDetails(Admin admin)
    {
        Console.WriteLine("\nWelcome.");
        Console.Write("Staff id of the attendant to be updated: ");
        var staffId = Console.ReadLine();
        var attendant = _iAttendantManager.GetAttendant(staffId);
        if (attendant != null)
        {
            Console.Write("First Name: ");
            var firstName = Console.ReadLine();
            Console.Write("Last Name: ");
            var lastName = Console.ReadLine();
            Console.Write("Phone Number: ");
            var phoneNumber = Console.ReadLine();
            _iAttendantManager.UpdateAttendant(attendant.StaffId, firstName, lastName, phoneNumber);
        }
        else
        {
            Console.WriteLine("Attendant not found.");
            ManageAttendantSubMenu(admin);
        }

    }

    public void DeleteAttendantMenu()
    {
        Console.Write("Enter Staff ID of the Attendant.");
        var staffId = Console.ReadLine();
        _iAttendantManager.DeleteAttendant(staffId);
    }

    public void UpdateAdminDetails()
    {
        Console.Write("Enter StaffId: ");
        string staffId = Console.ReadLine().Trim();
        var admin = _iAdminManager.GetAdmin(staffId);
        if (admin != null)
        {
            Console.Write("Enter new admin first Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter new admin last Name: ");
            string lastName = Console.ReadLine();
            Console.Write("Enter new PhoneNumber: ");
            string phoneNumber = Console.ReadLine();
            _iAdminManager.UpdateAdmin(staffId, firstName, lastName, phoneNumber);
            Console.WriteLine($"{staffId} successfully updated. ");
        }
        else
        {
            Console.WriteLine($"{staffId} not found");
        }
    }
    public void UpdateAdminPassword()
    {
        Console.Write("Enter Staffid: ");
        string staffId = Console.ReadLine().Trim();
        Console.Write("Enter Old Password: ");
        string pin = Console.ReadLine();
        var admin = _iAdminManager.Login(staffId, pin);
        if (admin != null)
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
            _iAdminManager.UpdateAdminPassword(staffId, pin);
            AdminSubMenu(admin);
        }
        else
        {
            Console.WriteLine("\nWrong staff Id or old Password!.");
            var mainMenu = new MainMenu();
            AdminSubMenu(admin);
        }
    }
    public void AddProduct()
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
    public void SortedProductBy()
    {
        Console.WriteLine("\nID\tPRODUCT NAME\tBARCODE\tPRICE\tQTY\t");
        System.Console.Write("Enter reorder point: ");
        int quantity = int.Parse(Console.ReadLine());
        _iProductManager.SortedProductByQuantity(quantity);
    }
    public void RestockProduct()
    {
        Console.Write("Enter product Barcode: ");
        string barCode = Console.ReadLine().Trim();
        var product = _iProductManager.GetProduct(barCode);
        if (product != null)
        {
            Console.Write("How many to be added: ");
            int quantity = int.Parse(Console.ReadLine());
            _iProductManager.RestockProduct(barCode, quantity);
        }
        else
        {
            Console.WriteLine($"{barCode} not found");
        }
    }
    public void UpdateProductDetails()
    {
        Console.Write("Enter product Barcode: ");
        string barCode = Console.ReadLine().Trim();
        var product = _iProductManager.GetProduct(barCode);
        if (product != null)
        {
            Console.Write("Enter new product Name: ");
            string productName = Console.ReadLine();
            Console.Write("Enter new price Name: ");
            decimal price = decimal.Parse(Console.ReadLine());
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

    public void DeleteProductMenu()
    {
        Console.Write("Enter Product BarCode: ");
        var barCode = Console.ReadLine();
        _iProductManager.DeleteProduct(barCode);

    }

    private string FileDate()
    {
        var dateSave = string.Join("", DateTime.Now.ToShortDateString().Split('/'));
        var dateSave1 = string.Join("", DateTime.Now.ToShortTimeString().Split(':')).Remove(4);
        return dateSave + dateSave1;
    }
}

