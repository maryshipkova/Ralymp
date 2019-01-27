using System;
using Microsoft.AspNetCore.Mvc;
using Ralymp.Models.ResponseTypes;
using Ralymp.Tools;

namespace Ralymp.Controllers
{
    [Route("api/[controller]")]
    public class StudentRateController : Controller
    {
        [HttpGet("[action]")]
        public ActionResult<StudentRateRow[]> GetRandomResultList(int? count)
        {
            if (count == null)
            {
                count = 1;
            }

            try
            {
                StudentRateRow[] rows = TemplateInstanceCreator.GetStudentRateRow(count.Value);
                return Ok(rows);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}