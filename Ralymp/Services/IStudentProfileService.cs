using Ralymp.Models.ResponseTypes;

namespace Ralymp.Services
{
    public interface IStudentProfileService
    {
        StudentProfileResponse Find(int id);
        StudentProfileResponse GetRandom();
        StudentProfileResponse FindBySurname(string surname);
    }
}