using System;
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
            if (student == null)
                return null;

            IQueryable<Participation> participationList = _dbContext
                .Participations
                .Where(p => p.Student.Id == id);

            return new StudentProfileResponse()
            {
                Participation = participationList
                    .Select(p => new StudentParticipation
                    {
                        Place = p.Place,
                        SubjectName = p.Subject.Title,
                        Year = p.YearInfo.FullTitle
                    })
                    .ToArray(),
                StudentName = student.StudentName,
                //TODO: Fix, task AB#23
                //SchoolTitle = student.School.Title,
                StudentId = student.Id
            };
        }

        public StudentProfileResponse GetRandom()
        {
            StudentProfileResponse response = TemplateInstanceCreator.GetStudentProfileResponse();
            return response;
        }

        public StudentProfileResponse FindBySurname(string surname)
        {
            throw new NotImplementedException();
        }
    }
}