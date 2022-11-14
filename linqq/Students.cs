    public class Students
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender{get;set;}
        public int Age { get; set; }
        public Students(string firstName, string lastName,string gender, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Gender=gender;
            Age = age;
        }
    }
