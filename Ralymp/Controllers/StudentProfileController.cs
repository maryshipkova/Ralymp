using System;
using Microsoft.AspNetCore.Mvc;
using Ralymp.Models.ResponseTypes;
using Ralymp.Tools;

namespace Ralymp.Controllers
{
    [Route("api/[controller]")]
    public class StudentProfileController : Controller
    {
        // GET
        [HttpGet("[action]")]
        public ActionResult<StudentProfileResponse[]> GetRandomProfile()
        {
            try
            {
                StudentProfileResponse response = TemplateInstanceCreator.GetStudentProfileResponse();
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}