using EventScheduler.Db.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventScheduler.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DevController(IAppDbContext dbContext) : Controller
    {
        [HttpPost("/test-connection", Name = "TestConnection")]
        public IActionResult TestConnection()
        {
            return dbContext.Database.CanConnect()
                ? Ok(new { Message = "Successfully connected to database" })
                : StatusCode(500, new { Message = "Failed to connect to database" });
        }

        [HttpPost("/migrate", Name = "Migrate")]
        public IActionResult Migrate()
        {
            try
            {
                dbContext.Database.Migrate();
                return Ok(new { Message = "Successfully ran migrations" });
            }
            catch
            {
                return StatusCode(500, new { Message = "Failed to run migrations" });
            }

        }
    }
}
