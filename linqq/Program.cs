
// var number = new List<int>(){1,2,3,4,5,6,7,8,9,10};
// var output = from x in number where x > 5 select x;
// foreach (var item in output)
// {
//     System.Console.WriteLine(item);
// }
// System.Console.WriteLine("thius ccode");
// var output2 = number.Where(number => number > 5).ToList();

// foreach (var item in output2)
// {
//     System.Console.WriteLine(item);
// }

// var total = (from numbers in output2 select numbers).Sum();
// System.Console.WriteLine(total);

System.Console.WriteLine("\n\nThe End");

var student = new List<Students>()
{
    new Students ("Jame Christ", "Mike","male",32),
    new Students ("Christopher Christ", "female","Racheal",65),
    new Students ("Simon", "Racheal","male",65),
    new Students ("Cramel", "Festus","female",25),
    new Students ("Great", "David","male",43),
    new Students ("Best", "Crescent","male",33)
};
string firstName = "";
string lastName = "";
string gender = "";
int age = 34;
var stud = new Students(firstName, lastName, gender, age);
var male = from x in student where x.Gender == "male" select x;
foreach (var item in male)
{
    System.Console.WriteLine($"{item.FirstName}\t {item.LastName} \t{item.Age}");
}

System.Console.WriteLine("\n\nstudents above 40 years");
var underage = from x in student where x.Age > 35 select x;

foreach (var item in underage)
{
    System.Console.WriteLine($"{item.FirstName}\t {item.LastName} \t{item.Age}");
}



// var student = new Students();