using System.Collections.Generic;
using System.Linq;
using Ralymp.DataAccessLayer;
using Ralymp.Models.DatabaseTypes;
using Ralymp.Models.InterimTypes;
using Ralymp.Models.ResponseTypes;
using Ralymp.Tools;

namespace Ralymp.Services
{
    public class StudentProfileService : IStudentProfileService
    {
        private readonly RalympDbContext _dbContext;

        public StudentProfileService(RalympDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public StudentProfileResponse Find(int id)
        {
            Student student = _dbContext.Student.Find(id);
            return student == null ? null : GenerateStudentProfile(student);
        }

        public StudentProfileResponse GetRandom()
        {
            return TemplateInstanceCreator.GetStudentProfileResponse();
        }

        public List<StudentProfileResponse> FindByString(string substring)
        {
            List<Student> students = _dbContext
                .Student
                .Where(s => s.StudentName.Contains(substring))
                .ToList();

            return students.Select(GenerateStudentProfile).ToList();
        }

        private StudentProfileResponse GenerateStudentProfile(Student student)
        {
            List<Participation> participationList = _dbContext
                .Participations
                .Where(p => p.Student.Id == student.Id)
                .ToList();


            var profile = new StudentProfileResponse
            {
                StudentName = student.StudentName,
                //TODO: Fix, task AB#23
                //SchoolTitle = student.School?.Title,
                StudentId = student.Id,
                Participation = participationList
                    .Select(p => new StudentParticipation
                    {
                        Place = p.Place, SubjectName = p?.Subject?.Title, Year = p?.YearInfo?.FullTitle
                    })
                    .ToArray()
            };

            return profile;
        }
    }
}