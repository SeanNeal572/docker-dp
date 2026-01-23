using EventScheduler.Core.Commands;
using EventScheduler.Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EventScheduler.Api.Controllers
{
    [ApiController]
    [Route("[controller]/{id:int}")]
    public class EventController(IEventRepository eventRepository) : Controller
    {
        [HttpGet(Name = "GetEvent")]
        public IActionResult GetEvent(int id)
        {
            var eventById = eventRepository.GetEventById(id);
            return eventById == null ? NotFound() : Ok(eventById);
        }

        [HttpDelete(Name = "DeleteEvent")]
        public IActionResult DeleteEvent(int id)
        {
            var deleted = eventRepository.DeleteEvent(id);
            return deleted ? Ok() : NotFound();
        }

        [HttpPost(Name = "UpdateEvent")]
        public IActionResult UpdateEvent(int id, [FromBody] UpdateEventCommand updateCommand)
        {
            var updated = eventRepository.UpdateEvent(id, updateCommand);
            return updated ? Ok() : NotFound();
        }
    }
}
