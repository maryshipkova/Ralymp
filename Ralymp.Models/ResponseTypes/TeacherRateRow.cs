using Ralymp.Models.InterimTypes;

namespace Ralymp.Models.ResponseTypes
{
    public class TeacherRateRow
    {
        public string TeacherName { get; set; }
        public string SchoolTitle { get; set; }
        public TeacherParticipation[] Participations { get; set; }  
    }
}