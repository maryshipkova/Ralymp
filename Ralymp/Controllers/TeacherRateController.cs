using System;
using Microsoft.AspNetCore.Mvc;
using Ralymp.Models.ResponseTypes;
using Ralymp.Tools;

namespace Ralymp.Controllers
{
    [Route("api/[controller]")]
    public class TeacherRateController : Controller
    {
        [HttpGet("[action]")]
        public ActionResult<TeacherRateRow[]> GetRandomResultList(int? count)
        {
            if (count == null)
            {
                count = 1;
            }

            try
            {
                TeacherRateRow[] rows = TemplateInstanceCreator.GetTeacherRateRow(count.Value);
                return Ok(rows);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}