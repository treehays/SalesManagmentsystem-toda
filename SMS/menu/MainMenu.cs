
using SMS.interfaces;

public class MainMenu
{
    IUserManager _iAdminManager = new AdminManager();
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
####                  Welcome to AZ Sales Management System.                ####
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
            // Console.WriteLine("choice");
            // Console.WriteLine(_choice);
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
        // do
        // {
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

        // } while (_choice != 0);
    }



    public void LoginMenu()
    {
        Console.WriteLine("\tWelcome.\n\tEnter your Staff ID and Password to login ");
        Console.Write("\tStaff ID: ");
        var staffId = Console.ReadLine();
        Console.Write("\tPin: ");
        var pin = Console.ReadLine();
        // staffId = "ALD841804"; 
        // pin = "1234";
        var user = _iAdminManager.Login(staffId, pin);
        if (user != null)
        {
            if (user.UserRole == 1)
            {
                Console.WriteLine($"Welcome {user.FirstName}, you've successfully Logged in!");
                var adminMenu = new AdminMenu();
                adminMenu.AdminSubMenu(user);
            }
            else if (user.UserRole == 2)
            {
                Console.WriteLine($"Welcome {user.FirstName}, you've successfully Logged in!");
                var attendantMenu = new AttendantMenu();
                attendantMenu.AttendantSubMenu(user);

            }
            else
            {
                System.Console.WriteLine("Your account has been deactivated...");
            }

        }
        else
        {
            Console.WriteLine("\nWrong User details!.");
            AllMainMenu();
        }
    }

    // public void LoginMenu()
    // {
    //     do
    //     {
    //         Console.WriteLine("\n\tHome>> Login >> ");
    //         Console.WriteLine("\tEnter 1 for Admin.\n\tEnter 2 for Attendant. \n\tEnter 3 for Customer. \n\tEnter 4 to go back to Main Menu.\n\tEnter 0 to Close");
    //         bool chk;
    //         do
    //         {
    //             Console.Write("Enter Operation No: ");
    //             chk = int.TryParse(Console.ReadLine(), out _choice);
    //             Console.WriteLine(chk ? "" : "Invalid Input.");
    //         } while (!chk);
    //         switch (_choice)
    //         {
    //             case 1:
    //                 {
    //                     Console.WriteLine("\nHome >> Admin");
    //                     var adminMenu = new AdminMenu();
    //                     adminMenu.LoginAdminMenu();
    //                     break;
    //                 }
    //             case 2:
    //                 {
    //                     Console.WriteLine("\nMain Menu >> Login >> Attendant");
    //                     var attendantMenu = new AttendantMenu();
    //                     attendantMenu.LoginAttendantMenu();
    //                     break;
    //                 }
    //             case 3:
    //                 /* OUT OFF THE PROGRAM FOR SUSTOMER
    //             // Customer
    //             Console.WriteLine("\nMain Menu >> Login >> Customer");
    //             CustomerMenu customerMenu = new CustomerMenu();
    //             customerMenu.LoginCUstomerMenu();
    //             */
    //                 break;
    //             case 4:
    //                 AllMainMenu();
    //                 break;
    //             default:
    //                 Console.WriteLine("Invalid Input.\n");
    //                 LoginMenu();
    //                 break;
    //         }

    //     } while (_choice != 0);
    //     Console.WriteLine();
    // }


   public static void GoodBye()
    {
        System.Console.WriteLine("Good bye");
    }

}
