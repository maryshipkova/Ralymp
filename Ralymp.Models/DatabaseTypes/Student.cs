namespace Ralymp.Models.DatabaseTypes
{
    public class Student
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }

        public int GraduationYear { get; set; }

        public School School { get; set; }
    }
}