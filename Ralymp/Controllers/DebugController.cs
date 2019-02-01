using System;
using Microsoft.AspNetCore.Mvc;
using Ralymp.DataAccessLayer;
using Ralymp.Models.DatabaseTypes;

namespace Ralymp.Controllers
{
    [Route("api/[controller]")]
    public class DebugController : Controller
    {
        private readonly RalympDbContext _dbContext;

        public DebugController(RalympDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("[action]")]
        public ActionResult<Student> CallDatabase()
        {
            try
            {
                Student result = _dbContext.Student.Find(1);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}