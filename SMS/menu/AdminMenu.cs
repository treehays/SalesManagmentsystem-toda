using SMS.implementation;
using SMS.interfaces;
using SMS.model;

namespace SMS.menu
{
    public class AdminMenu
    {
        IAdminManager iAdminManager = new AdminManager();
        IAttendantManager iAttendantManager = new AttendantManager();
        IProductManager iProductManager = new ProductManager();
        ITransactionManager iTransactionManager = new TransactionManager();
        public void RegisterAdminPage()
        {
            Console.WriteLine("Welcome...");
            Console.Write("First name: ");
            string firstName = Console.ReadLine();
            Console.Write("Last name: ");
            string lastName = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Phone Number: ");
            string phoneNumber = Console.ReadLine();
            Console.Write("pin: ");
            string pin = Console.ReadLine();
            Console.Write("Post: ");
            string post = Console.ReadLine();
            iAdminManager.CreateAdmin(firstName, lastName, email, phoneNumber, pin, post);
            // LoginAdminMenu();
            MainMenu mainMenu = new MainMenu();
            mainMenu.LoginMenu();
        }
        public void DeleteAttendantMenu()
        {
            Console.Write("Enter Staff ID of the Attendant.");
            string staffId = Console.ReadLine();
            iAttendantManager.DeleteAttendant(staffId);
        }
        public void LoginAdminMenu()
        {
            Console.WriteLine("Welcome.\nEnter your Staff ID and Password to login ");
            Console.Write("Staff ID: ");
            string staffId = Console.ReadLine();
            Console.Write("Pin: ");
            string pin = Console.ReadLine();
            // iAdminManager.Login(staffId,pin); waht is this doing not part of the code
            Admin admin = iAdminManager.Login(staffId, pin);
            if (admin != null)
            {
                Console.WriteLine($"Welcome {admin.FirstName}, you've successfully Logged in!");
                AdminSubMenu();
            }
            else
            {
                Console.WriteLine($"Wrong Staff ID or Password!.");
                MainMenu mainMenu = new MainMenu();
                mainMenu.LoginMenu();
            }
        }
        public void AdminSubMenu()
        {
            int choice;
            // Console.Clear();
            Console.WriteLine("\nMain Menu >> Login >> Admin >>");
            Console.WriteLine("\nAZ Sales Management System. \nEnter valid option.");
            Console.WriteLine("Enter 1 to Manage Attendant.\nEnter 2 to Manage Products \nEnter 3 to Update My Details. \nEnter 4 to View sales Records.\nEnter 5 to check Wallet. \nEnter 6 to Logout.\nEnter 0 to Close.");
            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                // Console.Clear();
                Console.WriteLine("Invalid Input\n");
                AdminSubMenu();
            }
            switch (choice)
            {
                case 0:
                    System.Console.WriteLine("Closed.");
                    break;
                case 1:
                    // Manage Attendant
                    ManageAttendantSubMenu();

                    break;
                case 2:
                    // Manage Products 
                    ManageProductSubMenu();

                    break;
                case 3:
                    // Update detail
                    break;
                case 4:
                    // View Sales Records
                    Console.WriteLine("\nID\t TRANS. DATE \tCUSTOMER NAME\tAMOUNT\tBARCODE\tRECEIPT NO\tQTY\tTOTAL\tBALANCE");

                    Console.WriteLine($"Current Wallet Ballance: {iTransactionManager.GetAllTransactionsAdmin()}");
                    // iTransactionManager.GetAllTransactionsAdmin();
                    break;
                case 5:
                    //Check Balance

                    Console.WriteLine($"Booked Balance: {iTransactionManager.CalculateTotalSales()}");
                    break;
                case 6:
                    // logout
                    MainMenu mainMenu = new MainMenu();
                    mainMenu.LoginMenu();
                    break;
                default:
                    AdminSubMenu();
                    break;
            }
        }
        public void ManageAttendantSubMenu()
        {
            Console.WriteLine("\n...>> Admin >> Manage Attendants >>");
            Console.WriteLine("\nAZn Sales Management System. \nEnter valid option.");
            Console.WriteLine("Enter 1 to Create Attendant.\nEnter 2 to View all attendants. \nEnter 3 to Delete Attendant.\nEnter 4 to Logout.\nEnter 0 to Close.");

            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                // Console.Clear();
                Console.WriteLine("Invalid Input\n");
                AdminSubMenu();
            }
            switch (choice)
            {
                case 0:
                    Console.WriteLine("Closed.");
                    return;
                // break;
                case 1:
                    // Create Attendant
                    AttendantMenu attendantMenu = new AttendantMenu();
                    attendantMenu.RegisterAttendantPage();
                    AdminSubMenu();
                    break;
                case 2:
                    Console.WriteLine("\nID\tSTAFF\tFIRST NAME\tLAST NAME\tEMAIL\tPHONE NO");
                    iAttendantManager.ViewAllAttendants();
                    AdminSubMenu();
                    break;
                case 3:
                    // Delete Attendants
                    DeleteAttendantMenu();
                    break;
                case 4:
                    // logout
                    MainMenu mainMenu = new MainMenu();
                    mainMenu.LoginMenu();
                    break;
                default:
                    ManageAttendantSubMenu();
                    break;
            }
        }
        public void DeleteProductMenu()
        {
            Console.Write("Enter Product BarCode: ");
            string barCode = Console.ReadLine();
            iProductManager.DeleteProduct(barCode);
        }
        public void AddProduct()
        {
            Console.Write("Product Name: ");
            string productName = Console.ReadLine();
            Console.Write("Barcode(Product ID): ");
            string barCode = Console.ReadLine();
            Console.Write("Price: ");
            double price;
            while (!double.TryParse(Console.ReadLine(), out price))
            {
                System.Console.WriteLine("wrong input.. Try again.");
            }
            Console.Write("Quantity: ");

            int ProductQuantity;
            while (!int.TryParse(Console.ReadLine(), out ProductQuantity))
            {
                System.Console.WriteLine("wrong input.. Try again.");
            }
            iProductManager.CreateProduct(barCode, productName, price, ProductQuantity);
        }
        public void ManageProductSubMenu()
        {
            Console.WriteLine("\n...>> Admin >> Manage Product >>");
            Console.WriteLine("\nAZ Sales Management System. \nEnter valid option.");
            Console.WriteLine("Enter 1 to Add a product1. \nEnter 3  to View all Products. \nEnter 4 to Delete Product.\nEnter 5 to Go Back to Admin Menu\nEnter 6 to Logout.\nEnter 0 to Close.");
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                // Console.Clear();
                Console.WriteLine("Invalid Input\n");
                ManageProductSubMenu();
            }
            switch (choice)
            {
                case 0:
                    System.Console.WriteLine("Closed.");
                    return;
                // break;
                case 1:
                    // Add Product
                    AddProduct();
                    ManageProductSubMenu();
                    break;
                // case 2:
                // Modify product
                //  Console.WriteLine("Attendant Details.");
                // AttendantManager attendantManager = new AttendantManager();
                // attendantManager.ViewAttendant(attendant.StaffId);

                // break;
                case 3:
                    // View All products
                    // iAdminManager.DeleteAdmin();
                    Console.WriteLine("\nID\tPRODUCT NAME\tBARCODE\tPRICE\tQTY\t");
                    iProductManager.ViewAllProduct();
                    ManageProductSubMenu();

                    break;
                case 4:
                    DeleteProductMenu();
                    ManageProductSubMenu();
                    break;
                case 5:
                    AdminSubMenu();

                    break;
                case 6:
                    // logout
                    MainMenu mainMenu = new MainMenu();
                    mainMenu.LoginMenu();
                    break;
                default:
                    ManageProductSubMenu();
                    break;
            }
        }
    }
}
