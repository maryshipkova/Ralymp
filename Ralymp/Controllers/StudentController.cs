using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Ralymp.Models;

namespace Ralymp.Controllers
{
    [Produces("application/json")]
    [Route("api/Student")]
    public class StudentController : Controller
    {
        [HttpGet("Get")]
        public ActionResult<Student> GenerateStudent()
        {
            Student student = Generate(0);
            return Ok(student);
        }

        [HttpGet("GetMany")]
        public ActionResult<Student[]> GenerateStudents(int count)
        {
            return Ok(Enumerable.Range(1, count).Select(Generate).ToArray());
        }

        private static Student Generate(int num)
        {
            return new Student()
            {
                FirstName = $"Test{num}",
                SecondName = $"Test{num}",
                ThirdName = $"Test{num}",
                GraduationYear = 2020,
                Id = -1,
                School = new School() { Id = -1, Title = "School"}
            };
        }
    }
}