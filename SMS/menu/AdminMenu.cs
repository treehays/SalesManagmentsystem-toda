


public class AdminMenu
    {
        IAdminManager _iAdminManager = new AdminManager();
        IAttendantManager _iAttendantManager = new AttendantManager();
        IProductManager _iProductManager = new ProductManager();
        ITransactionManager _iTransactionManager = new TransactionManager();
        private int _choice;

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
            var pin =Console.ReadLine();
            // var staffId = "ADU864054"; 
            // var pin = "password";
            // // iAdminManager.Login(staffId,pin); waht is this doing not part of the code
            var admin = _iAdminManager.Login(staffId, pin);
            if (admin != null)
            {
                Console.WriteLine($"Welcome {admin.FirstName}, you've successfully Logged in!");
                AdminSubMenu();
            }
            else
            {
                Console.WriteLine("\nWrong Staff ID or Password!.");
                var mainMenu = new MainMenu();
                mainMenu.LoginMenu();
            }
        }

        public void AdminSubMenu()
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
            Console.WriteLine("\tEnter 1 to Manage Attendant.\n\tEnter 2 to Manage Products \n\tEnter 3 to Update My Details. \n\tEnter 4 to View sales Records.\n\tEnter 5 to check Wallet. \n\tEnter 6 to Logout.\n\tEnter 0 to Close.");
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
                    Console.WriteLine("Closed.");
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
                    UpdateAdminDetails();
                    AdminSubMenu();
                    // Update detail
                    break;
                case 4:
                    // View Sales Records
                    Console.WriteLine("\nID\t TRANS. DATE \tCUSTOMER NAME\tAMOUNT\tBARCODE\tRECEIPT NO\tQTY\tTOTAL\tBALANCE");

                    Console.WriteLine($"Current Wallet Balance: {_iTransactionManager.GetAllTransactionsAdmin()}");
                    // iTransactionManager.GetAllTransactionsAdmin();
                    AdminSubMenu();
                    break;
                case 5:
                    //Check Balance

                    Console.WriteLine($"Booked Balance: {_iTransactionManager.CalculateTotalSales()}");
                    AdminSubMenu();
                    break;
                case 6:
                    // logout
                    var mainMenu = new MainMenu();
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
            // Console.WriteLine("\nAZn Sales Management System. \nEnter valid option.");
            Console.WriteLine("\tEnter 1 to Create Attendant.\n\tEnter 2 to View all attendants. \n\tEnter 3 to Delete Attendant.\n\tEnter 4 to Logout.\n\tEnter 5 to go back \n Enter 0 to Close.");
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
                    Console.WriteLine("Closed.");
                    // return;
                    break;
                case 1:
                    // Create Attendant
                    var attendantMenu = new AttendantMenu();
                    attendantMenu.RegisterAttendantPage();
                    ManageAttendantSubMenu();
                    break;
                case 2:
                    Console.WriteLine("\nID\tSTAFF\tFIRST NAME\tLAST NAME\tEMAIL\tPHONE NO");
                    _iAttendantManager.ViewAllAttendants();
                    ManageAttendantSubMenu();
                    break;
                case 3:
                    // Delete Attendants
                    DeleteAttendantMenu();
                    ManageAttendantSubMenu();
                    break;
                case 4:
                    // logout
                    var mainMenu = new MainMenu();
                    mainMenu.LoginMenu();
                    break;
                case 5:
                    
                    AdminSubMenu();
                    break;
                default:
                    ManageAttendantSubMenu();
                    break;
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

        public void ManageProductSubMenu()
        {
            Console.WriteLine("\nAZ Sales Management System. \nEnter valid option.");
            Console.WriteLine("...>> Admin >> Manage Product >>");
            Console.WriteLine("Enter 1 to Add a product1. \nEnter 2 to Modify products detail. \nEnter 3  to View all Products. \nEnter 4 to Delete Product.\nEnter 5 to Go Back to Admin Menu\nEnter 6 to Logout.\nEnter 0 to Close.");

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
                    ManageProductSubMenu();
                    break;
                case 2:
                    // Modify product
                    Console.WriteLine("Modify Product Details.");
                    UpdateProductDetails();
                    ManageProductSubMenu();
                    break;
                case 3:
                    // View All products
                    // iAdminManager.DeleteAdmin();
                    Console.WriteLine("\nID\tPRODUCT NAME\tBARCODE\tPRICE\tQTY\t");
                    _iProductManager.ViewAllProduct();
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
                    var mainMenu = new MainMenu();
                    mainMenu.LoginMenu();
                    break;
                default:
                    ManageProductSubMenu();
                    break;
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
                Console.Write("Enter new quantity: ");
                int quantity = int.Parse(Console.ReadLine());
                _iProductManager.UpdateProduct(barCode, productName, price, quantity);
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

    }

