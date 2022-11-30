// using MySql.Data.MySqlClient;
// using System.Diagnostics;

var mainMenu = new MainMenu();
mainMenu.AllMainMenu();

// static void GoodBye()
// {
System.Console.WriteLine("Good bye");
// }



/*
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Specify your gender");
        // var gender = (Gender)int.Parse(Console.ReadLine());
        // var genders = Enum.Parse(typeof(Gender), Console.ReadLine());
        var gender = (int)Gender.male;
        System.Console.WriteLine(gender);
    }
}
 public enum Gender
 {
    male,
    female,
    amaphrodite
 }
*/

// var refs = Guid.NewGuid();
// string newaa = refs.ToString().Remove(11);
// System.Console.WriteLine(newaa);
// var ip = new TransactionManager();
// ip.ViewTransactionAsHTML();
// var dateSaved = DateTime.Now.ToShortDateString().Split('/');
// var dateSave=string.Join("",DateTime.Now.ToShortDateString().Split('/'));
// var dateSave1=string.Join("",DateTime.Now.ToShortTimeString().Split(':')).Remove(4);
// var fileDate = dateSave+dateSave1;
// System.Console.WriteLine(fileDate);
// TreeH();

/*
// working for me

static void TreeH()
{
    // string _FullUrl1 = @"C:\Users\Treehays\Documents\CLH\New folder\Sales-Managment-system-a9f7f5c5c01ade0e51bd3f89aa2856667084fafc\SMS\outFile.csv";
    string _FullUrl1 = @"file:///C:/Users/Treehays/Documents/CLH/New%20folder/Sales-Managment-system-a9f7f5c5c01ade0e51bd3f89aa2856667084fafc/SMS/outFile.csv";
    var prc = new ProcessStartInfo(@"C:\Program Files\Microsoft Office\root\Office16\EXCEL.EXE");
    prc.Arguments = _FullUrl1;
    Process.Start(prc);
}

*/




//  static void DataSetToExcel(DataSet dataSet, string filePath)
//     {
//         using (ExcelPackage pck = new ExcelPackage())
//         {
//             foreach (DataTable dataTable in dataSet.Tables)
//             {
//                 ExcelWorksheet workSheet = pck.Workbook.Worksheets.Add(dataTable.TableName);
//                 workSheet.Cells["A1"].LoadFromDataTable(dataTable, true);
//             }

//             pck.SaveAs(new FileInfo(filePath));
//         }
//     }


// AdminMenu asss = new AdminMenu ();
// asss.UpdateAdminPassword();

// IAdminManager asss = new AdminManager();
// System.Console.WriteLine(asss.CheckWalletBalance());
// using System.Diagnostics;

// System.Console.WriteLine("\nPress 1 for 'The minion'\npress 2 for Baby SHark");
// var choice = 0;
// choice = int.Parse(Console.ReadLine());
// if (choice == 1)
// {
//     Movies();
// }




// else if (choice == 2)
// {
// // TreeH();
// // }
// static void TreeH()
// {
//     string _FullUrl1 = @"file:///C:/Users/Treehays/Documents/CLH/New%20folder/Sales-Managment-system-a9f7f5c5c01ade0e51bd3f89aa2856667084fafc/SMS/outFile.csv.html";
//     var prc = new ProcessStartInfo(@"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe");
//     prc.Arguments = _FullUrl1;
//     Process.Start(prc);
// }
// static void Movies()
// {
//     // string _FullUrl1 = @"https://www.youtube.com/watch?v=PYnWKSXXyIk&ab_channel=DevNami";
//     string _FullUrl = @"https://www.youtube.com/watch?v=6DxjJzmYsXo";
//     var prc = new ProcessStartInfo(@"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe");
//     prc.Arguments = _FullUrl;
//     Process.Start(prc);
// }
/*
var ConString ="SERVER=localhost; User Id=root; Password=1234; DATABASE=sms";
using (MySqlConnection connection = new MySqlConnection(ConString))
{
    MySqlCommand cmd = new MySqlCommand("create table Student (id int, name VARCHAR(250), email VARCHAR(100), Number int)", connection);
    // MySqlCommand cmd = new MySqlCommand("insert into Student values (105, 'Ramesh', 'Ramesh@dotnettutorial.net', '1122334455')", connection);
    connection.Open();
    int rowsAffected = cmd.ExecuteNonQuery();
    Console.WriteLine("Inserted Rows = " + rowsAffected);
    //Set to CommandText to the update query. We are reusing the command object, 
    //instead of creating a new command object
    cmd.CommandText = "insert into Student values (105, 'Ramesh', 'Ramesh@dotnettutorial.net', '1122334455')";
    rowsAffected = cmd.ExecuteNonQuery();
    cmd.CommandText = "update Student set Name = 'Ramesh Changed' where Id = 105";
    rowsAffected = cmd.ExecuteNonQuery();
    Console.WriteLine("Updated Rows = " + rowsAffected);
    //Set to CommandText to the delete query. We are reusing the command object, 
    //instead of creating a new command object
    cmd.CommandText = "insert into Student values (15, 'Ram4esh', '4Ramesh@dotnettutorial.net', '41122334455')";

    rowsAffected = cmd.ExecuteNonQuery();
    Console.WriteLine("Deleted Rows = " + rowsAffected);
}
*/

/*
using (var connection = new MySqlConnection("SERVER=localhost; User Id=root; Password=1234; DATABASE=sms"))
{
    var queryCreate =
        $"Insert into testing (name,email,age) values ('my name4','4rmailSalmple@gmail.com',45)";
    var queryCreateTable =
        $"Insert into testing (name,email,age) values ('my name3','3mailSle@gmail.com',48)";

    var command = new MySqlCommand(queryCreateTable, connection);
    connection.Open();

    var write = command.ExecuteNonQuery();
    System.Console.WriteLine($"adding table {write}");

    command.CommandText = queryCreate;
    System.Console.WriteLine($"adding first {write}");

}*/
// var adminManager = new AdminManager();
// adminManager.CreateAdmin("firstName1","lastName1","email1","phoneNumber1","pin1","post1");

// var mainMenu = new MainMenu();
// mainMenu.AllMainMenu();
// var adminManager = new AdminManager();
// adminManager.ReadFromFile();
// adminManager.CreateDataBaseTable();
// var adminMenu = new AdminMenu();
// adminMenu.LoginAdminMenu(); 

// string staffId = "AUI988844";
// string firstName = "ChangedFirst";
// string lastName = "ChangedLast";
// string phoneNumber = "909898989";
// var adminManager = new AdminManager();
// adminManager.UpdateAdmin(staffId,firstName,lastName,phoneNumber);

// adminManager.GetAllAdmin();
// System.Console.WriteLine("enter staff id: ");
// string staffId ="AXY344973";// Console.ReadLine();
// adminManager.DeleteAdmin(staffId);
// adminMenu.ManageAttendantSubMenu();
// }

// public string GenerateRandomId()
// {
//     string alphabet = "abcdefghijklmnopqrstuvwxyz".ToUpper();
//     int r1 = new Random().Next(25);
//     int r2 = new Random().Next(25);
//     string staffId = $"A{alphabet[r1]}{alphabet[r2]}" + new Random().Next(1100000).ToString();
//     return staffId;
// }


// Console.Write("Enter integer: ");
// int a ;//= int.Parse(Console.ReadLine());

// FileStream fileStream = File.Create( @"./Files/admin.txt");
// fileStream.Close();

// FileStream fileStream1 = new FileStream( @"./admin.txt", FileMode.CreateNew);

// string dirPath = @"C:\Users\Treehays\Documents\CLH\CreatedJustNow\anotherFolder";
// string filePath = @"C:\Users\Treehays\Documents\CLH\CreatedJustNow\anotherFolder\thisIsmyfil.txt";



// Directory.Delete(dirPath);
// DirectoryInfo directoryInfo = new DirectoryInfo(dirPath);
// directoryInfo.Create();
// FileInfo




// File.WriteAllText(filePath,"weyigkdwwdkfnwkj");
// FileInfo fileInfo = new FileInfo(filePath);
// FileStream fileStream = new FileStream(filePath, FileMode.CreateNew);
// StreamWriter streamWriter = new StreamWriter(filePath,append: true);
// string dghs = "dhgndslkjfslkfsmf;sknf";

// char[] f = { 'd', 'd' };
// streamWriter.WriteLine(f);
// streamWriter.Close();
// StreamReader streamReader = new StreamReader(filePath);
// Console.WriteLine(streamReader.ReadLine());
// Console.WriteLine(streamReader.ReadLine());
// Console.WriteLine(streamReader.ReadLine());
// Console.WriteLine(streamReader.ReadLine());
// Console.WriteLine(streamReader.ReadLine());
// Console.WriteLine(streamReader.ReadLine());
// Console.WriteLine(streamReader.ReadToEnd());
// streamReader.ReadLine();
// StreamWriter writer = new StreamWriter(filePath);
// writer.WriteLine("Welcome to the Bank");
// writer.Close();



// System.Console.WriteLine(Directory.Exists(dirPath));

/*
File
Fileinfo
directory
directoryinfo
streamwriter
streamReading
textreader 
textwriter
BinaryWrit

*/

// string a = "w";
// string b = "a";
// string c = a+b;
// System.Console.WriteLine(a+b);

// DateTime dv = DateTime.Parse("2022/11/29");
// DateTime che = DateTime.UtcNow;
// System.Console.WriteLine(DateTime.Now.Day);
// System.Console.WriteLine(che);
// // System.Console.WriteLine(che-dv.Day);
// System.Console.WriteLine((dv-che).Days+1);
// decimal cashTender1;
// while (!decimal.TryParse(Console.ReadLine(), out cashTender1))
// {
//     System.Console.WriteLine("wrong input.. Try again.");
// }
// string x = "1212";
// bool dd;
// string wrd = x.ToString();
// for (int i = wrd.Length-1; i >= 0; i--)
// {

// System.Console.Write(x.ToCharArray().Reverse());


