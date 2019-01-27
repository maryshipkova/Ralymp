namespace Ralymp.Models.DatabaseTypes
{
    public class Teacher
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }

        public School School { get; set; }
    }
}