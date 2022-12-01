
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
        var staffId = Console.ReadLine().Trim();
        Console.Write("\tPin: ");
        var pin = Console.ReadLine();
        // staffId = "ALD841804"; 
        // pin = "1234";
        var user = _iAdminManager.Login(staffId, pin);
        if (user != null)
        {
            switch (user.UserRole)
            {
                case 1:
                {
                    Console.WriteLine($"Welcome {user.FirstName}, you've successfully Logged in!");
                    var adminMenu = new AdminMenu();
                    adminMenu.AdminSubMenu(user);
                    break;
                }
                case 2:
                {
                    Console.WriteLine($"Welcome {user.FirstName}, you've successfully Logged in!");
                    var attendantMenu = new AttendantMenu();
                    attendantMenu.AttendantSubMenu(user);
                    break;
                }
                default:
                    Console.WriteLine("Your account has been deactivated...");
                    break;
            }
        }
        else
        {
            Console.WriteLine("\nWrong User details!.");
            AllMainMenu();
        }
    }

   public static void GoodBye()
    {
        Console.WriteLine("Good bye");
    }

}
