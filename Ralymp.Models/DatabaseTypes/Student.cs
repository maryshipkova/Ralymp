using System.Collections;
using System.Collections.Generic;

namespace Ralymp.Models.DatabaseTypes
{
    public class Student
    {
        public int Id { get; set; }

        public string StudentName { get; set; }
        public int GraduationYear { get; set; }
        public School School { get; set; }

        public ICollection<Participation> ParticipationList { get; set; }
    }
}