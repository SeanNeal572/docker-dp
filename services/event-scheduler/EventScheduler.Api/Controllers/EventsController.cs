using EventScheduler.Core.Commands;
using EventScheduler.Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EventScheduler.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventsController(IEventRepository eventRepository) : Controller
    {
        [HttpGet(Name = "GetEvents")]
        public IActionResult GetEvents()
        {
            var events = eventRepository.GetEvents();
            return Ok(events);
        }

        [HttpPost(Name = "SaveEvent")]
        public IActionResult SaveEvent([FromBody] SaveEventCommand saveCommand)
        {
            var id = eventRepository.SaveEvent(saveCommand);
            return Created($"event/{id}", null);
        }
    }
}
