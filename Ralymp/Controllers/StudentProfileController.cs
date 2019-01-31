using System;
using Microsoft.AspNetCore.Mvc;
using Ralymp.Models.ResponseTypes;
using Ralymp.Services;

namespace Ralymp.Controllers
{
    [Route("api/[controller]")]
    public class StudentProfileController : Controller
    {
        private readonly IStudentProfileService _studentProfileService;

        public StudentProfileController()
        {
            _studentProfileService = new StudentProfileService();
        }

        [HttpGet("[action]")]
        public ActionResult<StudentProfileResponse> GetRandomProfile()
        {
            try
            {
                StudentProfileResponse response = _studentProfileService.GetRandom();
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("[action]")]
        public ActionResult<StudentProfileResponse> Find(int? id)
        {
            try
            {
                if (id == null)
                {
                    return BadRequest($"Missed {nameof(id)} argument");
                }

                StudentProfileResponse response = _studentProfileService.Find(id.Value);

                if (response == null)
                {
                    return NotFound($"Can't find student with id={id}");
                }

                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("[action]")]
        public ActionResult<StudentProfileResponse> FindByUsername(string username)
        {
            try
            {
                if (username == null)
                {
                    return BadRequest($"Missed {nameof(username)} argument");
                }

                StudentProfileResponse response = _studentProfileService.FindBySurname(username);

                if (response == null)
                {
                    return NotFound($"Can't find student with id={username}");
                }

                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}