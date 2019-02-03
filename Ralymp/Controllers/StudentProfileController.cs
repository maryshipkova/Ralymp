using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Ralymp.Models.ResponseTypes;
using Ralymp.Services;

namespace Ralymp.Controllers
{
    [Route("api/[controller]")]
    public class StudentProfileController : Controller
    {
        private readonly IStudentProfileService _studentProfileService;

        public StudentProfileController(IStudentProfileService studentProfileService)
        {
            _studentProfileService = studentProfileService;
        }

        [HttpGet("[action]")]
        public ActionResult<StudentProfileResponse> GetRandomProfile()
        {
            StudentProfileResponse response = _studentProfileService.GetRandom();
            return Ok(response);
        }

        [HttpGet("[action]")]
        public ActionResult<StudentProfileResponse> Find(int? id)
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

        [HttpGet("[action]")]
        public ActionResult<List<StudentProfileResponse>> FindByName(string name)
        {
            if (name == null)
            {
                return BadRequest($"Missed {nameof(name)} argument");
            }

            List<StudentProfileResponse> response = _studentProfileService.FindByString(name);

            return Ok(response);
        }
    }
}