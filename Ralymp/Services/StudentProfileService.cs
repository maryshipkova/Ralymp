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
            Student student = _dbContext
                .Student
                .IncludeProperty()
                .First(s => s.Id == id);

            return student == null ? null : new StudentProfileResponse(student);
        }

        public StudentProfileResponse GetRandom()
        {
            return TemplateInstanceCreator.GetStudentProfileResponse();
        }

        public List<StudentProfileResponse> FindByString(string substring)
        {
            List<Student> students = _dbContext
                .Student
                .IncludeProperty()
                .Where(s => s.StudentName.Contains(substring))
                .ToList();

            return students.Select(s => new StudentProfileResponse(s)).ToList();
        }
    }
}