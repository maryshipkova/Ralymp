using System.Linq;
using Ralymp.Models.DatabaseTypes;
using Ralymp.Models.InterimTypes;

namespace Ralymp.Models.ResponseTypes
{
    public class StudentProfileResponse
    {
        public StudentProfileResponse()
        {
            
        }

        public StudentProfileResponse(Student student)
        {
            StudentName = student.StudentName;
            SchoolTitle = student.School.Title;
            StudentId = student.Id;
            Participation = student
                .ParticipationList
                .Select(p => new StudentParticipation(p))
                .ToArray();
        }

        public int StudentId { get; set; }

        public string StudentName { get; set; }
        public string SchoolTitle { get; set; }
        public StudentParticipation[] Participation { get; set; }
        public SubjectCategoryRow[] CategoryRows { get; set; }

        public int TotalWinsOnMunicipalStage { get; set; }
        public int TotalWinsOnRegionStage { get; set; }
        public int TotalWinsOnCountryStage { get; set; }
    }
}