namespace dotnetlinq;
class Program
{
    static void Main(string[] args)
    {
        var listOfStudents = new List<Student>(){
            new Student(){Id=1,Name="Abdulsalam Ahmad A", Gender="Male",Age=24},
            new Student(){Id=2,Name="Haleem Oyrtunji", Gender="Male",Age=12},
            new Student(){Id=3,Name="Charles Barbage", Gender="Female",Age=18},
            new Student(){Id=4,Name="Christ Mathew", Gender="Male",Age=21},
            new Student(){Id=5,Name="Methylaroe Mathew", Gender="Male",Age=71},
            new Student(){Id=6,Name="Rinsayoluwa Jalulr", Gender="Female",Age=53},
            new Student (){Id=7,Name="crocodied Simoas",Gender="Male",Age=32}

        };




        // Console.WriteLine("Hello, World!");
        // var listNum = ListofNumber();
        // var querrySyn = from x in listNum where x >5 select x;
        // IEnumerable<int> alsoQquerrySyn = from x in listNum where x >5 select x;
        // var meth = listNum.Where(x => x > 5).ToArray();
        // var sumFIlter = listNum.Where(x => x > 5).Sum();
        // // var i = 1;
        // System.Console.WriteLine("Sum of all numbers is {0} y",sumFIlter);
        // foreach (var item in querrySyn)
        // {
        //     System.Console.WriteLine(item *1);
        // }
    }
    static List<int> ListofNumber()
    {
        var listOfNumbers = new List<int>() { 6, 4, 1, 8, 2, 7, 1, 11, 3, 9 };
        return listOfNumbers;
    }
}
public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Gender { get; set; }
    public int Age { get; set; }
}
