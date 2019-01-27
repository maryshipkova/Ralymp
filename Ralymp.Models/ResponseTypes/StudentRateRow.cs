using Ralymp.Models.InterimTypes;

namespace Ralymp.Models.ResponseTypes
{
    public class StudentRateRow
    {
        //TODO: Form or graduation year

        public string StudentName { get; set; }
        public string SchoolTitle { get; set; }
        public StudentParticipation[] Participation { get; set; }
    }
}
