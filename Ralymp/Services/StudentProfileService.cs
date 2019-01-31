using System;
using Ralymp.Models.ResponseTypes;
using Ralymp.Tools;

namespace Ralymp.Services
{
    public class StudentProfileService : IStudentProfileService
    {
        public StudentProfileResponse Find(int id)
        {
            throw new NotImplementedException();
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