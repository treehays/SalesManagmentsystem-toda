
    public class MainMenu
    {
        private int _choice;
        public void AllMainMenu()
        {
            do
            {
                // Console.Clear();
                Console.WriteLine(@"
################################################################################
####>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>####
####________________________________________________________________________####
####    Welcome to AZ Sales Management System. Enter valid option.          ####
####------------------------------------------------------------------------####
####>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>####
################################################################################");
                Console.WriteLine("\tHome>>");
                Console.WriteLine("\tEnter 1 to Sign Up.\n\tEnter 2 to Login.\n\tEnter 0 to Close.");
                bool chk;
                do
                {
                    Console.Write("Enter Operation No: ");
                    chk = int.TryParse(Console.ReadLine(), out _choice);
                    Console.WriteLine(chk ? "" : "Invalid Input.");
                } while (!chk);
                switch (_choice)
                {
                    case 1:
                        RegistrationMenu();
                        break;
                    case 2:
                        Console.WriteLine("\nMain Menu >> Login >> ");
                        LoginMenu();
                        break;
                    default:
                        Console.Write("Invalid Input.");
                        break;
                }
            } while (_choice != 0);
        }

        private void RegistrationMenu()
        {
            do
            {
                Console.WriteLine("\nHome >> Register >>");
                Console.WriteLine("\tEnter 1 Go back to Go Home. or \n\tEnter Your OneTime Registration Code for  Newly Employed Manager..");
                bool chk;
                do
                {
                    Console.Write("Enter Operation No: ");
                    chk = int.TryParse(Console.ReadLine(), out _choice);
                    Console.WriteLine(chk ? "" : "Invalid Input.");

                } while (!chk);
                switch (_choice)
                {
                    case 2546:
                    {
                        var adminMenu = new AdminMenu();
                        adminMenu.RegisterAdminPage();
                        break;
                    }
                    case 1:
                        AllMainMenu();
                        break;
                    default:
                        Console.WriteLine("Invalid Input.\n");
                        RegistrationMenu();
                        break;
                }

            } while (_choice != 0);
        }
        public void LoginMenu()
        {
            do
            {
                Console.WriteLine("\n\tHome>> Login >> ");
                Console.WriteLine("\tEnter 1 for Admin.\n\tEnter 2 for Attendant. \n\tEnter 3 for Customer. \n\tEnter 4 to go back to Main Menu.\n\tEnter 0 to Close");
                bool chk;
                do
                {
                    Console.Write("Enter Operation No: ");
                    chk = int.TryParse(Console.ReadLine(), out _choice);
                    Console.WriteLine(chk ? "" : "Invalid Input.");
                } while (!chk);
                switch (_choice)
                {
                    case 1:
                    {
                        Console.WriteLine("\nHome >> Admin");
                        var adminMenu = new AdminMenu();
                        adminMenu.LoginAdminMenu();
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine("\nMain Menu >> Login >> Attendant");
                        var attendantMenu = new AttendantMenu();
                        attendantMenu.LoginAttendantMenu();
                        break;
                    }
                    case 3:
                        /* OUT OFF THE PROGRAM FOR SUSTOMER
                    // Customer
                    Console.WriteLine("\nMain Menu >> Login >> Customer");
                    CustomerMenu customerMenu = new CustomerMenu();
                    customerMenu.LoginCUstomerMenu();
                    */
                        break;
                    case 4:
                        AllMainMenu();
                        break;
                    default:
                        Console.WriteLine("Invalid Input.\n");
                        LoginMenu();
                        break;
                }

            } while (_choice != 0);
            Console.WriteLine();
        }
    }
