using Ralymp.Models.DatabaseTypes;

namespace Ralymp.Models.InterimTypes
{
    public class StudentParticipation
    {
        public StudentParticipation()
        {
            
        }

        public StudentParticipation(Participation participation)
        {
            SubjectName = participation.Subject.Title;
            Place = participation.Place;
            Year = participation.YearInfo.FullTitle;
        }

        public string SubjectName { get; set; }
        public int Place { get; set; }
        public string Year { get; set; }
    }
}
