namespace SMS.menu
{
    public class MainMenu
    {
        public int choice;
        public void AllMainMenu()
        {
            do
            {
                // Console.Clear();
                Console.WriteLine("\n>>Main Menu");
                Console.WriteLine("Welcome..\nAZ Sales Management System. \nEnter valid option.");
                Console.WriteLine("Enter 1 to Register.\nEnter 2 to Login.\n0 to Close.");
                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    // Console.Clear();
                    Console.WriteLine("Invalid Input\n");
                    AllMainMenu();
                }

                if (choice == 1)
                {
                    // Register
                    RegistrationMenu();
                }
                else if (choice == 2)
                {
                    // Login
                    Console.WriteLine("\nMain Menu >> Login >> ");
                    LoginMenu();
                }
                else
                {
                    // Invalid Choice
                    // Console.Clear();
                    Console.WriteLine("Invalid Input.\n");
                }
            } while (choice != 0);

        }
        public void RegistrationMenu()
        {

            do
            {
                Console.WriteLine("\nMain Menu >> Register >>");
                // Console.WriteLine("Enter 1 for Admin.\nEnter 2 for Attendant. \nEnter 3 for Customer. \nEnter 4 to go back.");
                Console.WriteLine("Enter 1 Go back to Main Menu. or \nEnter Your OneTime Registration Code for  Newly Employed Manager..");
                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    // Console.Clear();
                    Console.WriteLine("Invalid Input\n");
                    RegistrationMenu();
                }
                if (choice == 2546)
                {
                    // Admin
                    Console.WriteLine("\nMain Menu >> Register >> Admin");
                    AdminMenu adminMenu = new AdminMenu();
                    adminMenu.RegisterAdminPage();
                }
                // else if (choice == 2)
                // // {
                // //     // Attendant
                // //     Console.WriteLine("\nMain Menu >> Register >> Attendant >>");
                // //     AttendantMenu attendantMenu = new AttendantMenu();
                // //     attendantMenu.RegisterAttendantPage();
                // // }
                // // else if (choice == 3)
                // // {
                // //     /*
                // //     // Customer
                // //     Console.WriteLine("\nMain Menu >> Register >> Customer >>");
                // //     CustomerMenu customerMenu = new CustomerMenu();
                // //     customerMenu.RegisterCustomerPage();
                // //     */
                // // }
                else if (choice == 1)
                {
                    // Go Back
                    AllMainMenu();
                }
                else
                {
                    // Invalid Choice
                    // Console.Clear();
                    Console.WriteLine("Invalid Input.\n");
                    RegistrationMenu();
                }

            } while (choice != 0);
        }
        public void LoginMenu()
        {
            do
            {
                Console.WriteLine("\nMain Menu >> Login >> ");
                Console.WriteLine("Enter 1 for Admin.\nEnter 2 for Attendant. \nEnter 3 for Customer. \nEnter 4 to go back to Main Menu.\nEnter 0 to Close");
                // Console.WriteLine("Enter 1 for Admin.\nEnter 2 for Attendant. \nEnter 3 for Customer. \nEnter 4 to go back to Main Menu.\nEnter 0 to Close");
                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    // Console.Clear();
                    Console.WriteLine("Invalid Input\n");
                    LoginMenu();
                }
                if (choice == 1)
                {
                    // Admin
                    Console.WriteLine("\nMain Menu >> Login >> Admin");
                    AdminMenu adminMenu = new AdminMenu();
                    adminMenu.LoginAdminMenu();
                }
                else if (choice == 2)
                {
                    // Attendant
                    Console.WriteLine("\nMain Menu >> Login >> Attendant");
                    AttendantMenu attendantMenu = new AttendantMenu();
                    attendantMenu.LoginAttendantMenu();
                }
                else if (choice == 3)
                {
                    /* OUT OFF THE PROGRAM FOR SUSTOMER
                    // Customer
                    Console.WriteLine("\nMain Menu >> Login >> Customer");
                    CustomerMenu customerMenu = new CustomerMenu();
                    customerMenu.LoginCUstomerMenu();
                    */
                }
                else if (choice == 4)
                {
                    // Go Back
                    AllMainMenu();
                }
                else
                {
                    // Invalid Choice
                    // Console.Clear();
                    Console.WriteLine("Invalid Input.\n");
                    LoginMenu();
                }

            } while (choice != 0);
            Console.WriteLine("Closed");
        }
    }
}
