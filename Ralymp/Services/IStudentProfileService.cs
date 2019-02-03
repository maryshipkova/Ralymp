using System.Collections.Generic;
using Ralymp.Models.ResponseTypes;

namespace Ralymp.Services
{
    public interface IStudentProfileService
    {
        StudentProfileResponse Find(int id);
        StudentProfileResponse GetRandom();
        List<StudentProfileResponse> FindByString(string substring);
    }
}